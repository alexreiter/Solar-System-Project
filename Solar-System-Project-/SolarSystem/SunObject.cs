using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SolarSystem
{
    class SunObject : SolarObject
    {
        //define constructor of sun object 
        public SunObject(string name, Color color, Canvas parent, double startX, double startY, int width, int height) 
            : base (name, color, parent, startX, startY, 0, width, height)
        {

        }
    }
}
