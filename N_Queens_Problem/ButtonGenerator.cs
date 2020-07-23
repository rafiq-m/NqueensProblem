using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace N_Queens_Problem
{
    class ButtonGenerator
    {
        FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
        Button[,] buttons;
        int number;
         public ButtonGenerator(FlowLayoutPanel flowLayoutPanel)
         {
            this.flowLayoutPanel = flowLayoutPanel;
         }
        public void generateButtons(int number)
        {
            this.number = number;
            flowLayoutSize(number);
            this.buttons = new Button[number, number];
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    buttons[i,j]  = addButtonProp(buttons[i,j],i,j);
                    flowLayoutPanel.Controls.Add(buttons[i,j]);
                }
            }
        }
        private Button addButtonProp(Button button,int i, int j)
        {
            button = new Button();
            button.BackColor = Color.LightBlue;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.DarkBlue;
            button.FlatAppearance.BorderSize = 2;
            button.Font = new Font(button.Font, FontStyle.Bold);
            button.Name = i.ToString() + j.ToString();
            button.Text = i.ToString() + j.ToString();
            button.Height = 80;
            button.Width = 74;
            button.Click += new EventHandler(this.buttonClick);
            return button;
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (isSafe(Convert.ToInt32(button.Text[0])-48, Convert.ToInt32(button.Text[1])-48, number))
                button.BackColor = Color.Green;
            else
                button.BackColor = Color.Red;
            button.Enabled = false;
        }
        private void flowLayoutSize(int number)
        {
            flowLayoutPanel.Width = 74 * (++number);
            flowLayoutPanel.Height = 80 * (++number);
        }


        private bool isSafe(int row, int col, int number)
        {
            int i, j;
            //for row
            for (i = 0; i < number; i++)
            {
                if (buttons[row, i].BackColor == System.Drawing.Color.Green)
                    return false;
            }
            //for col
            for (i = 0; i < number; i++)
            {
                if (buttons[i, col].BackColor == System.Drawing.Color.Green)
                    return false;
            }
            //for top to bottom and right to left
            for (i = row, j = col; j >= 0 && i < number; j--, i++)
            {
                if (buttons[i, j].BackColor == System.Drawing.Color.Green)
                    return false;
            }
            //for top to bottom and right to left
            for (i = row, j = col; j < number && i >=0; j++, i--)
            {
                if (buttons[i, j].BackColor == System.Drawing.Color.Green)
                    return false;
            }
            //for top to bottom and left to right
            if (col - row >= 0)
            {
                for (i = 0, j = col - row; i < number && j < number; i++, j++)
                {
                    if (buttons[i, j].BackColor == System.Drawing.Color.Green)
                        return false;
                }
            }
            else
            {
                for (i = row, j = col; j >= row && i <= col; j--, i++)
                {
                    if (buttons[i, j].BackColor == System.Drawing.Color.Green)
                        return false;
                }
                for (i = row-col, j = 0; i < number && j < number; i++, j++)
                {
                    if (buttons[i, j].BackColor == System.Drawing.Color.Green)
                        return false;
                }
            }
            /* Check this row on left side */
            //for (i = 0; i < col; i++)
            //    if (buttons[row,i].BackColor == System.Drawing.Color.Green)
            //        return false;

            ///* Check upper diagonal on left side */
            //for (i = row, j = col; i >= 0 &&
            //     j >= 0; i--, j--)
            //    if (buttons[i,j].BackColor == System.Drawing.Color.Green)
            //        return false;

            ///* Check lower diagonal on left side */
            //for (i = row, j = col; j >= 0 && i < number; i++, j--)
            //    if (buttons[i, j].BackColor == System.Drawing.Color.Green)
            //        return false;

            return true;
        }
    }
}
