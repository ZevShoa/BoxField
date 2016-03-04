using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxField
{
    public partial class GameScreen : UserControl
    {
        int ranNum;
        int personX = 400;
        int personY = 400;
        Random ran = new Random();
        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        //used to draw boxes on screen
        SolidBrush boxBrush = new SolidBrush(Color.Green);
        SolidBrush drawBrush = new SolidBrush(Color.DarkGoldenrod);

        // create a list of Boxes

        List<Box> boxes = new List<Box>();
     

        int waitTime = 18;
        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            // - create initial box object and add it to list of Boxes
            Box b = new Box(500 + ran.Next(-5, 6), 0);
            boxes.Add(b);
            Box c = new Box(200 + ran.Next(-5, 6), 0);
            boxes.Add(c);
            Box d = new Box(800 + ran.Next(-5, 6), 0);
            boxes.Add(d);

        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.B:
                    bDown = true;
                    break;
                case Keys.N:
                    nDown = true;
                    break;
                case Keys.M:
                    mDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.B:
                    bDown = false;
                    break;
                case Keys.N:
                    nDown = false;
                    break;
                case Keys.M:
                    mDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            waitTime--;
            if (rightArrowDown == true)
            {
                personX += 5;
            }
            if (leftArrowDown == true)
            {
                personX -= 5;
            }
            if (downArrowDown == true)
            {
                personY+= 5;
            }
            if (upArrowDown == true)
            {
                personY -= 5;
            }
            for (int i = 0; i < boxes.Count; i++)
            {
                if (boxes[i].x + 30 >= personX - 20 &&boxes[i].x <= personX&& boxes[i].y + 20 <= personY + 60 && boxes[i].y + 20 >= personY + 20)
                {
                    boxes[i].x -= 10;
                   
                   

                }
                if (boxes[i].x + 30 >= personX - 20 && boxes[i].x <= personX + 30 && boxes[i].y + 30 >= personY - 20 && boxes[i].y <= personY)
                {
                    boxes[i].y -= 10;
                }
                if (boxes[i].x <= personX + 30 && boxes[i].x >= personX + 10 && boxes[i].y + 30 >= personY - 20 && boxes[i].y <= personY)
                {
                    boxes[i].x += 10;
                }
                if(boxes[i].x + 30 >= personX - 20 && boxes[i].x <= personX + 30 && boxes[i].y <= personY + 70 && boxes[i].y >= personY + 50)
                {
                    boxes[i].y += 10;
                }

            }

            if (waitTime == 0)
            {
                
               // add new boxes
              
                Box b = new Box(500 + ran.Next(-5,6), 0);
                boxes.Add(b);
                Box c = new Box(200 + ran.Next(-5, 6), 0);
                boxes.Add(c);
                Box d = new Box(800 + ran.Next(-5, 6), 0);
                boxes.Add(d);
                waitTime = 18;
            }
           

            // - update position of each box
            for (int i = 0; i < boxes.Count; i++)
            {
                
                boxes[i].y += 2;
                if (boxes[i].y >= 0)
                {
                    boxes[i].x-= ran.Next(-5,6);
                  
                }
                if (boxes[i].y >= 100)
                {
                    
                    boxes[i].x+= ran.Next(-5, 6);
                    
                }
                if (boxes[i].y >= 200)
                {
                    boxes[i].x -= ran.Next(-5, 6);
                   
                }
                if (boxes[i].y >= 300)
                {
                    boxes[i].x += ran.Next(-5, 6);
                    
                }
                if (boxes[i].y >= 400)
                {
                    boxes[i].x -= ran.Next(-5, 6);
                 
                }
                if (boxes[i].y >= 500)
                {
                    boxes[i].x += ran.Next(-5, 6);
                   
                }


            }

            // - remove box from list if it is off screen
            if (boxes[0].y > this.Height)
            {
                boxes.RemoveAt(0);
            }
            

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // - draw each box to the screen
            e.Graphics.FillRectangle(drawBrush,personX,personY,10,40);
            
            
            foreach (Box b in boxes)
            {
               
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, 30, 30);
               
            }
            foreach(Box c in boxes)
            {
                e.Graphics.FillRectangle(boxBrush, c.x, c.y, 30, 30);
            }
            foreach (Box d in boxes)
            {
                e.Graphics.FillRectangle(boxBrush, d.x, d.y, 30, 30);
            }


        }


    }
}
