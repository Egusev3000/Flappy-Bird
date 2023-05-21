using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Flappy_Bird.Properties;

namespace Flappy_Bird
{
    class Player
    {
        public float x;
        public float y;
        public Image birdImg;

        public int size;

        public float gravityValue;

        public bool isAlive;

        public Player(int x, int y)
        {
            birdImg = Resources.bird;
            this.x = x;
            this.y = y;
            size = 35;
            gravityValue = 2.55f;
            isAlive = true;
        }
    }
}
