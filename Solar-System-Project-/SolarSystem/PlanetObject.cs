using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SolarSystem
{
    
    class PlanetObject : SolarObject
    {
        //initialize variables 
        SolarObject Planet_center;
        int Planet_radius;
        int Planet_currentAngle = 0;
        int Planet_speedAngle;

        //Creating the constructor for the planet objects
        public PlanetObject(string name, Color color, Canvas parent, double startX, double startY, int update_time, int width, int height,
            SolarObject center, int radius, int speed)
            : base (name, color, parent, startX, startY, update_time, width, height)
        {
            Planet_center = center;
            Planet_radius = radius;
            Planet_speedAngle = speed;

        }

        /// <summary>
        /// a method calculate changes of planets movement on the x and y axes 
        /// </summary>
        protected override void CalculatChanges()
        {
            //apply orbit equation
            double xc = Planet_center.Planet_locX;
            double yc = Planet_center.Planet_locY;

            double rad = Planet_currentAngle * Math.PI / 180;
            Planet_locX = xc + Planet_radius * Math.Cos(rad);
            Planet_locY = yc + Planet_radius * Math.Sin(rad);

            //increase angle for next time
            Planet_currentAngle += Planet_speedAngle;
        }
    }
}
