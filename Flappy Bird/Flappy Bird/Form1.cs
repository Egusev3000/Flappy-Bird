using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flappy_Bird.Properties;
using System.Media;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        Player bird;
        TheWall wall1;
        TheWall wall2;
        int score = 0;
        int bestscore = 0;

        float gravity;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(update);
            timer1.Start();

            timer2.Interval = 100;
            timer2.Tick += Pause;

            Init();

            Invalidate();
        }

        int timeStop = 0;

        public void Init()
        {
            bird = new Player(100, 200);
            wall1 = new TheWall(300, -200);
            wall2 = new TheWall(300, 300);
        }

        private void Pause(Object sender, EventArgs e)
        {
            timeStop++;
            if (timeStop > 3)
            {
                timer2.Stop();
                Init();
                timeStop = 0;
                score = 0;
                label1.Text = "Score: " + score;
                //playGameover();
            }
        }

        private void update(object sender, EventArgs e)
        {
            if (bird.y > 420)
            {
                bird.isAlive = false;
            }
            if (bird.isAlive)
            {
                MoveWalls();
                if (bird.gravityValue != 2.55f)
                    bird.gravityValue += 0.05f;
                bird.y += bird.gravityValue;
            }
            else
            {
                timer2.Start();
            }
            if (Collide(bird, wall1) || Collide(bird, wall2))
                bird.isAlive = false;
            Invalidate();
        }

        //private void playGameover()
        //{
            //SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\kguse\OneDrive\Desktop\Егор\gameover.wav");
            //simpleSound.Play();
        //}

        private bool Collide(Player bird, TheWall wall1)
        {
            PointF delta = new PointF();
            delta.X = (bird.x + bird.size / 2) - (wall1.x + wall1.sizeX / 2);
            delta.Y = (bird.y + bird.size / 2) - (wall1.y + wall1.sizeY / 2);
            if (Math.Abs(delta.X) <= bird.size / 2 + wall1.sizeX / 2)
            {
                if (Math.Abs(delta.Y) <= bird.size / 2 + wall1.sizeY / 2)
                {
                    return true;
                }
            }
            return false;
        }

        private void CreatNewWall()
        {
            if (wall1.x < bird.x - 220)
            {
                Random r = new Random();
                int y1;
                //int y2;
                y1 = r.Next(-200, 000);
                wall1 = new TheWall(350, y1);
                wall2 = new TheWall(350, y1 + 400);
                score++;
                label1.Text = "Score: " + score;
                if (score > bestscore)
                {
                    bestscore++;
                    label2.Text = "Best score: " + bestscore;
                }
            }
        }

        private void MoveWalls()
        {
            wall1.x -= 2;
            wall2.x -= 2;
            CreatNewWall();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(bird.birdImg, bird.x, bird.y, bird.size, bird.size);

            wall1.wallImg.RotateFlip(RotateFlipType.Rotate180FlipX);
            graphics.DrawImage(wall1.wallImg, wall1.x, wall1.y, wall1.sizeX, wall1.sizeY);
            wall1.wallImg.RotateFlip(RotateFlipType.Rotate180FlipX);

            graphics.DrawImage(wall2.wallImg, wall2.x, wall2.y, wall2.sizeX, wall2.sizeY);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (bird.isAlive && bird.y > 35)
            {
                if (e.KeyData.ToString() == "Space")
                {
                    gravity = 0;
                    bird.gravityValue = -2.25f;
                }
            }
        }
    }
}
