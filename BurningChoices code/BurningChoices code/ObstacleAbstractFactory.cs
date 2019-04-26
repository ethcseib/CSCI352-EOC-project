/*Description: This is our abstract factory implementation. It is used to create in- game obstacles like walls, items and doors*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace BurningChoices_code
{
    class MakeObstacle
    {
        public GenObstacle MakeWall(Image charac, Canvas canvas, string pic, Image wall)
        {
            return new Wall(charac, canvas, pic, wall);
        }

         public GenObstacle MakeDoor(Image charac, Canvas canvas, string pic, Image door)
        {
            return new Door(charac, canvas, pic, door);
        }

        public GenObstacle MakeItem(Image charac, Canvas canvas, string pic, Image item)
        {
            return new Item(charac, canvas, pic, item);
        }

        public GenObstacle MakeNPC(Image charac, Canvas canvas, string pic, Image npc)
        {
            return new NPC(charac, canvas, pic, npc);
        }
    }

    abstract class GenObstacle
    {
        /*<Summary> An abstract class for obstacles to inherit from. The goal for it for the most part is to define tracking functionality for all obstacles. />*/
        public static Image ClosestObstacle;//used in tracking the closest obstacle to the player
        //could possibly create an accessor for ClosestObstacle so it can't be openly modified

        protected static List<GenObstacle> GenObs = new List<GenObstacle>();//holds every object instance of a new obstacle.
        protected bool IsCollideable = true;
        public bool collideable
        {
            get { return IsCollideable; }
        }

        protected List<Point> ObsPoints;//holds the (x, y) coordinates for the obstacles

        
        static protected bool CollisionHappened = false;
        public bool CollisionStatus
        {
            get { return CollisionHappened; }
        }

        protected Image obs;//the obstacle image

        static protected Image character;
        protected Canvas canvas;

        public GenObstacle()
        {
            ObsPoints = new List<Point>();
        }

        public void CreateObs(string picture, Image ImgObj)
        {
            /*<Summary> Creates an obstacle of the type that will be specified by the class that calls the function and it also gives the obstacles an image and adds them to a tracking list />*/

            BitmapImage x = new BitmapImage();
            obs = ImgObj;

            x.BeginInit();
            x.UriSource = new Uri(picture, UriKind.RelativeOrAbsolute);
            x.EndInit();
            
            obs.Source = x;

            obs.Height = ImgObj.Height;
            obs.Width = ImgObj.Width;
            
            obs.Stretch = Stretch.Fill;
            obs.StretchDirection = StretchDirection.Both;

            Canvas.SetBottom(obs, Canvas.GetTop(obs) + obs.Height);
            Canvas.SetRight(obs, Canvas.GetLeft(obs) + obs.Width);

            SetPoints();//adds obs's points to a list for collision checking and tracking
            GenObs.Add(this);//Hold every new obstacle created for collision checking
        }

        protected void SetPoints()
        {
            /*<Summary> Gathers the coordinates of each obstacle within its respective Canvas object they will be used for tracking and collision testing />*/

            for (int x = Convert.ToInt32(Canvas.GetLeft(obs)); x <= Convert.ToInt32(Canvas.GetLeft(obs) + obs.Width); x++)
            {
                
                for (int y = Convert.ToInt32(Canvas.GetTop(obs)); y <= Convert.ToInt32(Canvas.GetTop(obs) + obs.Height); y++)
                {
                    ObsPoints.Add(new Point(x, y));
                }
            }
        }

        static public void CollisionCheck()
        {
            /*<Summary> Checks for a collision between the character and an obstacle />*/

            Point BottomLeft = new Point(Canvas.GetLeft(character), Canvas.GetTop(character) + character.Height);
            Point TopLeft = new Point(Canvas.GetLeft(character), Canvas.GetTop(character));
            Point TopRight = new Point(Canvas.GetLeft(character) + character.Width, Canvas.GetTop(character));
            Point BottomRight = new Point(Canvas.GetLeft(character) + character.Width, Canvas.GetTop(character) + character.Height);
            CollisionHappened = false;

            foreach (GenObstacle x in GenObs)
            {
                if (x.ObsPoints.Contains(BottomLeft))
                {
                    CollisionHappened = true;
                }

                else if (x.ObsPoints.Contains(BottomRight))
                {
                    CollisionHappened = true;
                }

                else if (x.ObsPoints.Contains(TopLeft))
                {
                    CollisionHappened = true;
                }

                else if (x.ObsPoints.Contains(TopRight))
                {
                    CollisionHappened = true;
                }
            }
            
        }

        static public GenObstacle ClosestElement()
        {
            /*<Summary> tracks the closest obstacle to the player for collision checking using a combination of the distance and midpoint formula. It returns the obstacle from the function. />*/

            double CharacterMidpointX = ((Canvas.GetLeft(character) + Canvas.GetRight(character)) / 2);
            double CharacterMidpointY = ((Canvas.GetTop(character) + Canvas.GetBottom(character)) / 2);
            double ElementPointX = GenObs[0].ObsPoints[0].X;
            double ElementPointY = GenObs[0].ObsPoints[0].Y;
            double dist = Math.Sqrt(Math.Pow((ElementPointX - CharacterMidpointX), 2) + Math.Pow((ElementPointY - CharacterMidpointY), 2));
            int index = 0;
            int count = 0;

            foreach (GenObstacle y in GenObs)
            {
                for (int x = 0; x < y.ObsPoints.Count; x++)
                {

                    ElementPointX = y.ObsPoints[x].X;
                    ElementPointY = y.ObsPoints[x].Y;
                    CharacterMidpointX = ((Canvas.GetLeft(character) + Canvas.GetRight(character)) / 2);
                    CharacterMidpointY = ((Canvas.GetTop(character) + Canvas.GetBottom(character)) / 2);

                    //the distance and midpoint formula
                    double ObsDist = Math.Sqrt((Math.Pow(ElementPointX - CharacterMidpointX, 2)) + (Math.Pow(ElementPointY - CharacterMidpointY, 2)));

                    if (ObsDist < dist)
                    {
                        index = count;
                        dist = ObsDist;
                    }
                }
                count++;
            }
            ClosestObstacle = GenObs[index].obs;

            return GenObs[index]; 
        }

        public void Remove(GenObstacle obs)
        {
            GenObs.Remove(obs); 
        }

        public void Clear()
        {
            GenObs.Clear();
        }

        public int Count()
        {
            return GenObs.Count();
        }
    }

    /*<Summary> The obstacles that inherit from the base class />*/

    class Wall : GenObstacle
    {
        public Wall(Image charac, Canvas canv, string pic, Image wall)
        {
            IsCollideable = true;
            character = charac;
            canvas = canv;
            CreateObs(pic, wall);
        }

    }

    class Door : GenObstacle
    {
        public Door(Image charac, Canvas canv, string pic, Image door)
        {
            IsCollideable = false;
            canvas = canv;
            character = charac;
            CreateObs(pic, door);
        }
    }

    class Item : GenObstacle
    {
        public Item(Image charac, Canvas canv, string pic, Image item)
        {
            IsCollideable = false;
            this.canvas = canv;
            character = charac;
            CreateObs(pic, item);
        }
    }

    class NPC : GenObstacle
    {
        public NPC(Image charac, Canvas canv, string pic, Image npc)
        {
            IsCollideable = false;
            this.canvas = canv;
            character = charac;
            CreateObs(pic, npc);
        }
    }
}
