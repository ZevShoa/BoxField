using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoxField
{
    class Box
    {
        public int x, y;
        public Color boxColor;
        /// <summary>
        /// Constructor method for a box
        /// </summary>
        /// <param name="_x">x position on screen</param>
        /// <param name="_y">y position on screen</param>
        public Box(int _x, int _y, Color _boxColor)
        {
            x = _x;
            y = _y;
            boxColor = _boxColor;
           
        }

    }
}
