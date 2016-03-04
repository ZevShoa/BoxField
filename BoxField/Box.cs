using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxField
{
    class Box
    {
        public int x, y;
        /// <summary>
        /// Constuctor method for a box
        /// </summary>
        /// <param name="_x">x position on screen</param>
        /// <param name="_y">y position on screen</param>
        public Box(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

    }
}
