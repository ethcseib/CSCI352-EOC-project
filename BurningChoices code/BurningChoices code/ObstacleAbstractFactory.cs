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
{/*<Note> abstract factory works well when user or client is given a choice of different looks and feels of a product suchas if they want a blue car or red one. Then the desired look and feel is returned. This is
    not really used to create in the program i believe />*/

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
    }

    abstract class GenObstacle
    {
        public static Image ClosestObstacle;//used in tracking the closest obstacle to the player
        //could possibly create an accessor for ClosestObstacle so it can't be openly modified

        protected static List<GenObstacle> GenObs = new List<GenObstacle>();//holds every object instance of a new obstacle. May not be the best due to memory consumption
        protected bool IsCollideable = true;//used to determine if an obstacle can be passed through by the player true means no
        public bool collideable//accessor to IsCollideable
        {
            get { return IsCollideable; }
        }

        protected List<Point> ObsPoints;//holds the (x, y) coordinates for the obstacles

        static protected bool CollisionHappened = false;//when a collision happens this will become true
        public bool CollisionStatus//access to see if a collision happened
        {
            get { return CollisionHappened; }
        }

        protected Image obs;//the obstacle

        static protected Image character;//the character check collisions with
        //might make static because there should be just one character at a time
        protected Canvas canvas;//the canvas to add obstacles to
        //might make this static because there should be just one canvas at a time

        public GenObstacle()//this might be useless 
        {
            ObsPoints = new List<Point>();
        }

        public void CreateObs(string picture, Image ImgObj)//, int CanvasLeft, int CanvasTop)//this might be best. Easier to control the obstacles created. though might remove canvasleft etc.
        {//string picture is the path to the picture
            BitmapImage x = new BitmapImage();
            obs = ImgObj;

            x.BeginInit();
            x.UriSource = new Uri(picture, UriKind.RelativeOrAbsolute);
            x.EndInit();
            
            obs.Source = x;//gives the obstacles a texture/ image

            obs.Height = ImgObj.Height;
            obs.Width = ImgObj.Width;
            
            obs.Stretch = Stretch.Fill;
            obs.StretchDirection = StretchDirection.Both;

            Canvas.SetBottom(obs, Canvas.GetTop(obs) + obs.Height);//establishes the last two sides of the obstacles
            Canvas.SetRight(obs, Canvas.GetLeft(obs) + obs.Width);

            //MessageBox.Show(Convert.ToString(Canvas.GetBottom(obs)));
            //MessageBox.Show(Convert.ToString(Canvas.GetRight(obs)));
            //canvas.Children.Add(obs);

            SetList();//adds obs's points to a list for collision checking and tracking
            GenObs.Add(this);//Hold every new obstacle created for collision checking
            /*<Note> Would like to find a way to just keep calling createObs to add new walls but this might defeat the purpose of abstract factory />*/
        }

        protected void SetList()//gathers the coordinates of each obstacle to be used for tracking and collision testing
        {
            
            for (int x = Convert.ToInt32(Canvas.GetLeft(obs)); x <= Convert.ToInt32(Canvas.GetLeft(obs) + obs.Width); x++)
            {
                
                for (int y = Convert.ToInt32(Canvas.GetTop(obs)); y <= Convert.ToInt32(Canvas.GetTop(obs) + obs.Height); y++)
                {
                    ObsPoints.Add(new Point(x, y));
                }
            }
        }

        static public void CollisionCheck()//Checks for a collision between the character and an obstacle
        {
            
            Point BottomLeft = new Point(Canvas.GetLeft(character), Canvas.GetTop(character) + character.Height);
            Point TopLeft = new Point(Canvas.GetLeft(character), Canvas.GetTop(character));
            Point TopRight = new Point(Canvas.GetLeft(character) + character.Width, Canvas.GetTop(character));
            Point BottomRight = new Point(Canvas.GetLeft(character) + character.Width, Canvas.GetTop(character) + character.Height);
            CollisionHappened = false;

            foreach (GenObstacle x in GenObs)
            {
                if (x.ObsPoints.Contains(BottomLeft))//changed from ObsPoints.Contains()
                {//collision at top or right
                    //MessageBox.Show("bottom left " + Convert.ToString(BottomRight));

                    CollisionHappened = true;
                }

                else if (x.ObsPoints.Contains(BottomRight))//if i can find a way to decide this i might be able to use some form of strategy pattern
                {//collisiion at top or left
                    //MessageBox.Show("bottom right " + Convert.ToString(BottomRight));

                    CollisionHappened = true;
                }

                else if (x.ObsPoints.Contains(TopLeft))
                {//Collision at bottom or right
                    //MessageBox.Show("top left " + Convert.ToString(BottomRight));

                    CollisionHappened = true;
                }

                else if (x.ObsPoints.Contains(TopRight))
                {//collision at bottom or left
                    //MessageBox.Show("top right " + Convert.ToString(BottomRight));

                    CollisionHappened = true;
                }

            }
            
        }

        public void ClosestElement()//tracks the closest obstacle to the player for collision checking using a combination of the distance and midpoint formula. 
        {//Might look into using thread with it though possibly not due to the character unless i stop the thread after the loop exits
            double CharacterMidpointX = (Canvas.GetLeft(character) + Canvas.GetRight(character)) / 2;
            double CharacterMidpointY = (Canvas.GetTop(character) + Canvas.GetBottom(character)) / 2;
            double ElementMidpointX = (Canvas.GetLeft(GenObs[0].obs) + Canvas.GetRight(GenObs[0].obs)) / 2;
            double ElementMidpointY = (Canvas.GetTop(GenObs[0].obs) + Canvas.GetBottom(GenObs[0].obs)) / 2;

            double dist = Math.Sqrt(Math.Pow((ElementMidpointX - CharacterMidpointX), 2) + Math.Pow((ElementMidpointY - CharacterMidpointY), 2));

            for (int i = 0; i < GenObs.Count; i++)
            {
                
                for (int y = Convert.ToInt32(Canvas.GetTop(GenObs[i].obs)); y < Canvas.GetBottom(GenObs[i].obs); y++)
                {
                    if (Math.Sqrt((Math.Pow(((Canvas.GetLeft(GenObs[i].obs) + Canvas.GetRight(GenObs[i].obs)) / 2) - (Canvas.GetLeft(character) + Canvas.GetRight(character) / 2), 2)
                        + Math.Pow(((Canvas.GetTop(GenObs[i].obs) + Canvas.GetBottom(GenObs[i].obs)) / 2) - (Canvas.GetTop(character) + Canvas.GetBottom(character) / 2), 2))) < dist)
                    {
                        ClosestObstacle = GenObs[i].obs;

                        dist = Math.Sqrt((Math.Pow(((Canvas.GetLeft(GenObs[i].obs) + Canvas.GetRight(GenObs[i].obs)) / 2) - (Canvas.GetLeft(character) + Canvas.GetRight(character) / 2), 2)
                            + Math.Pow(((Canvas.GetTop(GenObs[i].obs) + Canvas.GetBottom(GenObs[i].obs)) / 2) - (Canvas.GetTop(character) + Canvas.GetBottom(character) / 2), 2)));
                    }
                }
            }
        }
    }

    class Wall : GenObstacle//might make these private to reduce access to others though this might cause accessing issues
    {//TODO
        //List<Point> walls = new List<Point>();
        
        public Wall(Image charac, Canvas canv, string pic, Image wall)
        {
            IsCollideable = true;
            character = charac;
            canvas = canv;
            CreateObs(pic, wall);
        }

    }

    class Door : GenObstacle//gotta plan this one it's different than wall
    {
        public Door(Image charac, Canvas canv, string pic, Image door)
        {//TODO
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
            //canvas.Children.Remove(this);
        }

        /*public override void CollisionCheck()
        {
            base.CollisionCheck();MessageBox.Show("happened");
            if (CollisionHappened)
            {
                
                canvas.Children.Remove(obs);//I don't know how this will work logic wise
            }
        }*/
    }

    /*<TODO> This observer will hopefully be used with collision. Kind of like an event system. I need to think on the implementation a bit more. I'm not quite sure how I will go about this
     * </TODO>*/
    abstract class Subject
    {
        protected List<Observer> obs = new List<Observer>();

        protected abstract void Attach(Observer obj);
        protected abstract void Detatch(Observer obj);
        protected abstract void Notify();
    }

    class Collision : Subject
    {
        protected override void Attach(Observer obj)
        {
            obs.Add(obj);
        }

        protected override void Detatch(Observer obj)
        {
            obs.Remove(obj);
        }

        protected override void Notify()
        {
            foreach(Observer x in obs)
            {
                x.Update(this);
            }
        }

    }

    abstract class Observer
    {
        public abstract void Update(Subject obj);// might need to be protected this is just a temporary fix
    }


}
