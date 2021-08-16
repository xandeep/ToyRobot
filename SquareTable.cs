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
                    y = action("increase", y);                   
                         break;
                    case 1:
                        x = action("increase", x);
                        break;
                    case 2:
                        y = action("decrease", y);
                        break;
                    case 3:
                        x = action("decrease", x);
                        break;
                    default:
                        break;
                }

            
            
        }

        public static int action (string action, int position)
        {   
            if( action == "increase")
            {
                position = (position < 5 ? position + 1 : position);
            }

            if( action == "decrease")
            {
                position = (position > 0 ? position- 1 : position);
            }

            return position;
        }
    }
}
