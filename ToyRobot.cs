﻿////Sandeep Thapa
///ersandeepthapa@gmail.com
///0424 579 528
///27/06/2019

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot
{
    public partial class ToyRobot : Form
    {
        public ToyRobot()
        {
            InitializeComponent();
        }

        // Display all Movements of the Toy Robot and log every move
        private void SetReport(bool finalReport = false)
        {
            Report.DisplayReport = "X :" + SquareTable.X + "     Y :" + SquareTable.Y + " ";
            Direction direction = new Direction();
            string latest = Report.DisplayReport + direction.getDirectionNameByCode(Direction.CurrentDirection);

            if (finalReport)
            {
                result.Text = latest;
            }
            else
            {
                displayOutput.Text = latest + "\r\n" + displayOutput.Text;
            }
        }


        //Set the Values of X,Y and the direction
        private void SetValues(object sender, EventArgs e)
        {
            HideErrorMsg();
            // identify the direction and act accordingly
            Button btn = (Button)sender;
            string name = btn.Name;

            Direction direction = new Direction();
            Direction.CurrentDirection = direction.getDirectionCodeByBtnName(btn.Name);

            EnableBtns();
            SetReport();
        }

        private void DirectionControl(object sender, EventArgs e)
        {
            HideErrorMsg();

            Button btn = (Button)sender;
            string name = btn.Name;

            if (name == "btnRight")
            {
                if (Direction.CurrentDirection != 3)
                {
                    Direction.CurrentDirection++;
                }
                else
                {
                    // if its 3, Direction will go back to 0 that is West to North
                    Direction.CurrentDirection = 0;
                }


            }

            if (name == "btnLeft")
            {
                if (Direction.CurrentDirection != 0)
                {
                    Direction.CurrentDirection--;
                }
                else
                {
                    // if its 0, Direction will go back to 3 that is  North to West
                    Direction.CurrentDirection = 3;
                }
            }
            SetReport();
        }

        // clears thelog report at the right hand side
        private void ClrReport_Click(object sender, EventArgs e)
        {
            //cleare the Log 
            displayOutput.Text = "";
        }


        //Move the toy towards the specified direction
        private void BtnMove_Click(object sender, EventArgs e)
        {
            // Move one step towrads the direction
            HideErrorMsg();
            SquareTable.move();
            txtX.Text = SquareTable.X.ToString();
            txtY.Text = SquareTable.Y.ToString();
            SetReport();

        }

        //Display Final Report
        private void BtnReport_Click(object sender, EventArgs e)
        {
            HideErrorMsg();
            result.Visible = true;
            SetReport(true);
        }


        //Display Error Msg to User
        private void ErrorMsg(string msg = "INVALID INPUT- COMMAND IGNORED")
        {

            error.Text = msg;
            error.Visible = true;
            if (msg == "INVALID INPUT- COMMAND IGNORED")
            {
                btnMove.BackColor = Color.Red;
            }

        }


        //Hide error Msg after corrected
        private void HideErrorMsg()
        {
            btnMove.BackColor = SystemColors.Control;
            error.Text = "";
        }


        //Enable Buttons    
        private void EnableBtns()
        {
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
            btnMove.Enabled = true;
        }


        //Disable Buttons  
        private void DisableBtns()
        {
            btnLeft.Enabled = false;
            btnRight.Enabled = false;
            btnMove.Enabled = false;
        }

        private void txtX_TextChanged(object sender, EventArgs e)
        {
            if (validInput())
            {
                SquareTable.X = Convert.ToInt32(txtX.Text) >= 0 ? Convert.ToInt32(txtX.Text) : 0;
            }
            else
            {
                DisableBtns();
                ErrorMsg("Please enter X/Y values between 0 - 5");
            }

        }

        private void txtY_TextChanged(object sender, EventArgs e)
        {
            if (validInput())
            {
                SquareTable.Y = Convert.ToInt32(txtY.Text) >= 0 ? Convert.ToInt32(txtY.Text) : 0;
            }
            else
            {
                DisableBtns();
                ErrorMsg("Please enter X/Y values between 0 - 5");
            }

        }

        public bool validInput()
        {
            HideErrorMsg();
            int result = 0;
            return (
                int.TryParse(txtX.Text, out result) && int.TryParse(txtY.Text, out result)
                && Convert.ToInt32(txtX.Text) < 6 && Convert.ToInt32(txtY.Text) < 6
                && Convert.ToInt32(txtX.Text) >= 0 && Convert.ToInt32(txtY.Text) >= 0);

        }
    }
}
