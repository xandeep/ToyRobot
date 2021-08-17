using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class SquareTable : ToyRobot
    {
        private static int x;
        private static int y;

        public static int X 
        {
            get { return x; }
            set { x = value; }
        }
        public static int Y
        {
            get { return y; }
            set { y = value; }
        }

        public static void move()
        {   
            
                switch (Direction.CurrentDirection)
                {
                    case 0:
                    y = action(Config.MoveForward, y);                   
                         break;
                    case 1:
                        x = action(Config.MoveForward, x);
                        break;
                    case 2:
                        y = action(Config.MoveBackward, y);
                        break;
                    case 3:
                        x = action(Config.MoveBackward, x);
                        break;
                    default:
                        break;
                }

            
            
        }

        public static int action (string action, int position)
        {   
            if( action == Config.MoveForward)
            {
                position = (position < Config.MaxValue ? position + 1 : position);
            }

            if( action == Config.MoveBackward)
            {
                position = (position > Config.MinValue ? position - 1 : position);
            }

            return position;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SquareTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "SquareTable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
