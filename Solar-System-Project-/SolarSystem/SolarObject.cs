using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;


namespace SolarSystem
{
    //defining the solar object 
    class SolarObject
    {
        //initializing variables (creating shape and color)
        public Ellipse PlanetShape;

        protected SolidColorBrush PlanetBackbrush;

        //name of the planet, shape
        public string PlanetName;

        //location of planet, shape
        public double Planet_locX, Planet_locY;

        protected int Planet_update_interval;

        protected Canvas Planet_parent;
        protected int Planet_currentTime = 0;

        public SolarObject(string name, Color color, Canvas parent, double startX, double startY, int update_time, int width, int height)
        {
            PlanetName = name;
            PlanetShape = new Ellipse();
            PlanetBackbrush = new SolidColorBrush(color);
            Planet_locX = startX;
            Planet_locY = startY;
            Planet_parent = parent;
            Planet_update_interval = update_time;
            PlanetShape.Fill = PlanetBackbrush;
            PlanetShape.Width = width;
            PlanetShape.Height = height;
            Planet_parent.Children.Add(PlanetShape);
            PlanetShape.ToolTip = PlanetName;

            DefineNewLocation();
        }

        /// <summary>
        /// This method will change visual of location
        /// </summary>
        public void DefineNewLocation()
        {
            PlanetShape.SetValue(Canvas.LeftProperty, Planet_locX);
            PlanetShape.SetValue(Canvas.TopProperty, Planet_locY);
        }

        /// <summary>
        /// This method will change values of location
        /// </summary>
   
        //virtual empty method
        protected virtual void CalculatChanges()
        {
            
        }

        /// <summary>
        /// this method will update the current time and location based on the calculated changes 
        /// </summary>
        /// <param name="time"></param>
        public void Update(int time)
        {
            
            if(Planet_update_interval > 0)
            {
                Planet_currentTime += time;

                if(Planet_currentTime >= Planet_update_interval)
                {
                    CalculatChanges();

                    DefineNewLocation();

                    Planet_currentTime = 0;
                }
            }
        }
    }
}
