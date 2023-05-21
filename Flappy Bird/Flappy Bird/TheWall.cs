using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Flappy_Bird.Properties;

namespace Flappy_Bird
{
    class TheWall
    {
        public int x;
        public int y;
        public Image wallImg;

        public int sizeX;
        public int sizeY;

        public TheWall(int x, int y)
        {
            wallImg = Resources.tube;
            this.x = x;
            this.y = y;
            sizeX = 50;
            sizeY = 300;
        }
    }
}
