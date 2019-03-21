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

namespace BurningChoices_code
{/*<Note> abstract factory works well when user or client is given a choice of different looks and feels of a product suchas if they want a blue car or red one. Then the desired look and feel is returned. This is
    not really used to create in the program i believe />*/

    class ObstacleChecker
    {
        //TODO
    }

    abstract class ObstacleAbstractFactory
    {
        public abstract GenObstacle GetObstacle(Image charac, Canvas can);
    }

    class WallFactory : ObstacleAbstractFactory
    {
        public override GenObstacle GetObstacle(Image charac, Canvas can)
        {
            return new Wall(charac, can);
        }
    }

    class DoorFactory : ObstacleAbstractFactory
    {
        public override GenObstacle GetObstacle(Image charac, Canvas can)
        {
            return new Door(charac, can);
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

        protected static Image character;//the character check collisions with
        //might make static because there should be just one character at a time
        protected Canvas canvas;//the canvas to add obstacles to
        //might make this static because there should be just one canvas at a time

        public GenObstacle()//this might be useless 
        {
            ObsPoints = new List<Point>();
        }

        public void CreateObs(string picture, int height, int width, Image ImgObj)//, int CanvasLeft, int CanvasTop)//this might be best. Easier to control the obstacles created. though might remove canvasleft etc.
        {//string picture is the path to the picture
            BitmapImage x = new BitmapImage();
            obs = ImgObj;

            x.BeginInit();
            x.UriSource = new Uri(picture, UriKind.RelativeOrAbsolute);
            x.EndInit();
            
            obs.Source = x;//gives the obstacles a texture/ image

            obs.Height = height;
            obs.Width = width;
            obs.Stretch = Stretch.Fill;
            obs.StretchDirection = StretchDirection.Both;

            Canvas.SetBottom(obs, Canvas.GetTop(obs) + height);//establishes the last two sides of the obstacles
            Canvas.SetRight(obs, Canvas.GetLeft(obs) + width);


            //canvas.Children.Add(obs);

            this.SetList();//adds obs's points to a list for collision checking and tracking
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

        public void CollisionCheck()//Checks for a collision between the character and an obstacle
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

            double MidpointX = (Canvas.GetLeft(character) + Canvas.GetRight(character)) / 2;
            double MidpointY = (Canvas.GetTop(character) + Canvas.GetBottom(character)) / 2;
            double dist = Math.Sqrt(Math.Pow((GenObs[0].ObsPoints[1].X - MidpointX), 2) + Math.Pow((GenObs[0].ObsPoints[1].Y - MidpointY), 2));
            //MessageBox.Show(Convert.ToString(GenObs.Count));
            for(int i = 0; i < GenObs.Count; i++)
            {
                for (int x = 0; x < GenObs[i].ObsPoints.Count; x++)
                {
                    if (Math.Sqrt(Math.Pow((GenObs[i].ObsPoints[x].X - ((Canvas.GetLeft(character) + Canvas.GetRight(character)) / 2)), 2)
                + Math.Pow((GenObs[i].ObsPoints[x].Y - ((Canvas.GetTop(character) + Canvas.GetBottom(character)) / 2)), 2)) < dist)
                    {
                        ClosestObstacle = GenObs[i].obs;
                            
                    }
                }
            }
            //MessageBox.Show(Convert.ToString(Canvas.GetRight(ClosestObstacle)));
        }
    }

    class Wall : GenObstacle//might make these private to reduce access to others though this might cause accessing issues
    {//TODO
        //List<Point> walls = new List<Point>();
        
        public Wall(Image charac, Canvas canvas)
        {
            IsCollideable = true;
            character = charac;
            this.canvas = canvas;
            //GenObs.Add(this);
            //obs = new Image();
        }

    }

    class Door : GenObstacle//gotta plan this one it's different than wall
    {
        public Door(Image charac, Canvas canvas)
        {//TODO
            IsCollideable = false;
            //character = charac;
            this.canvas = canvas;
            //GenObs.Add(this);//might need to split this from walls
        }
    }
}
