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
                    case Config.North:
                    y = action(Config.MoveForward, y);                   
                         break;
                    case Config.East:
                        x = action(Config.MoveForward, x);
                        break;
                    case Config.South:
                        y = action(Config.MoveBackward, y);
                        break;
                    case Config.West:
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

    }
}
