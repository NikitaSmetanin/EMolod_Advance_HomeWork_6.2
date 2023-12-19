using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EMolod_Advance_HomeWork_6._2
{
    public partial class Form1 : Form
    {
        double number = 1;
        public Form1()
        {
            InitializeComponent();

            int x = 20;
            int y = 160;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.createButton(new Point(x + 70 * j, y + 70 * i), number.ToString(), new Size(50, 50));
                    number++;
                }
            }
            this.createButton(new Point(20, 370), "0", new Size(190, 50));         

        }

        private System.Windows.Forms.Button createButton(Point point, string text, Size size)
        {
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();

            button.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button.Location = point;
            button.Name = "numberButton";
            button.Size = size;
            button.TabIndex = 0;
            button.Text = text;
            button.UseVisualStyleBackColor = true;
            button.Click += numberButton_Click;

            this.Controls.Add(button);

            return button;
        }
        // Функція обробки числових кнопок
        private void numberButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += ((System.Windows.Forms.Button)sender).Text;
        }
        // Функція обробки кнопок операцій +, -, /, *
        private void operationButton1_Click(object sender, EventArgs e)
        {
            this.number = Convert.ToDouble(mainTextBox.Text);
            mainTextBox.Text = string.Empty;
        }
        // Функція обробки кнопки =
        private void equalButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text = (this.number + Convert.ToDouble(mainTextBox.Text)).ToString();
        }
        // Функція обробки кнопки очистки
        private void clearButton_Click(object sender, EventArgs e)
        {
            this.number = 0;
            mainTextBox.Text = string.Empty;
        }
    }
}
