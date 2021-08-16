using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class Direction
    {
        private static int currentDirection;
        public static int CurrentDirection
        {
            get { return currentDirection; }

            /* Value of Current Direction cannot go more than 3
             * 0  NORTH
             * 1  EAST
             * 2  SOUTH
             * 3  WEST
             * 0  NORTH
             */

            set { currentDirection = value; }
           }

        public int getDirectionCodeByBtnName(string btn)
        {
            int value;
            switch (btn)
            {
                case "btnNorth":
                    value = 0;
                    break;
                case "btnEast":
                    value = 1;
                    break;
                case "btnSouth":
                    value = 2;
                    break;
                case "btnWest":
                    value = 3;
                    break;
                default:
                    value = 0;  // default value NORTH if invalid input
                    break;
            }

            return value;

        }


        public string getDirectionNameByCode(int code)
        {
            string value;
            switch (code)
            {
                case 0:
                    value = "North";
                    break;
                case 1:
                    value = "East";
                    break;
                case 2:
                    value = "South";
                    break;
                case 3:
                    value = "West";
                    break;
                default:
                    value = "North"; // default value NORTH if invalid input
                    break;
            }

            return value;

        }


    }

}



