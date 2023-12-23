using System;
using System.Drawing;
using System.Windows.Forms;

namespace EMolod_Advance_HomeWork_6._2
{
    public partial class Form1 : Form
    {
        double number = 0;
        string operation;
        bool isDot = false;
        public Form1()
        {
            InitializeComponent();

            int x = 20;
            int y = 160;

            string[] chars = {  "%", "C", "<<", "=",
                                "1", "2", "3", "+",
                                "4", "5", "6", "-",
                                "7", "8", "9", "*",
                                "±", "0", ",", "/" };
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.createButton(new Point(x + 70 * j, y + 70 * i), chars[(int)number], new Size(50, 50));
                    number++;
                }
            }
            number = 0;            
        }

        // Функція створення кнопок з цифрами
        private Button createButton(Point point, string text, Size size)
        {
            Button button = new Button();

            button.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button.Location = point;
            button.Name = "Button";
            button.Size = size;
            button.TabIndex = 0;
            button.Text = text;
            button.UseVisualStyleBackColor = true;
            button.Click += Button_Click;

            this.Controls.Add(button);

            return button;            
        }
        // Функція обробки кнопок
        private void Button_Click(object sender, EventArgs e)
        {
            string text = ((Button)sender).Text;

            switch (text)
            {
                case "0" or "1" or "2" or "3" or "4" or "5" or "6" or "7" or "8" or "9": 
                    mainTextBox.Text += text; 
                    break;

                case ",":
                    if (!isDot)
                    {
                        mainTextBox.Text += text;
                        isDot = true;
                    }                        
                    break;

                case ("<<"):
                    if (mainTextBox.Text.Length != 0)
                        mainTextBox.Text = mainTextBox.Text.Substring(0, mainTextBox.Text.Length - 1); 
                    break;

                case "+" or "-" or "*" or "/" or "%":
                    if (!getDouble(mainTextBox.Text, out this.number))
                        break;                               
                    mainTextBox.Text = string.Empty;
                    this.operation = text;
                    isDot = false;
                    break;

                case "=":
                    double secondNumber = 0;
                    if (!getDouble(mainTextBox.Text, out secondNumber))
                        break;
                    switch(operation)
                    {
                        case "+":
                            mainTextBox.Text = (this.number + secondNumber).ToString();
                            break;
                        case "-":
                            mainTextBox.Text = (this.number - secondNumber).ToString();
                            break;
                        case "*":
                            mainTextBox.Text = (this.number * secondNumber).ToString();
                            break;
                        case "/":
                            if (Convert.ToDouble(mainTextBox.Text) != 0)
                                mainTextBox.Text = (this.number / secondNumber).ToString();
                            else
                                MessageBox.Show("Не можна ділити на нуль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        case "%":
                            mainTextBox.Text = (this.number * secondNumber / 100).ToString();
                            break;
                    }
                    historyTextBox.Text += this.number.ToString() + " " + operation + " " + secondNumber.ToString() +
                            " = " + mainTextBox.Text + Environment.NewLine;
                    break;

                case "C":
                    this.number = 0;
                    mainTextBox.Text = string.Empty;
                    isDot = false;
                    break;

                case "±":
                    mainTextBox.Text = (-1 * Convert.ToDouble(mainTextBox.Text)).ToString();
                    break;

                default:
                    MessageBox.Show("Ця функція в розробці", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }        
        // Функція шаблонізації введення даних в текстове поле
        private void mainTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифри, клавіша BackSpace та кома
            {
                e.Handled = true;
            }
        }
        // Функція отримання числового значення з текстового поля 
        // параметри - рядок типу string, змінна типу double
        private bool getDouble(string text, out double number)
        {            
            try
            {
                number = Convert.ToDouble(mainTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Невірне значення у полі вводу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                number = 0;
                return false;
            }
            return true;
        }
    }
}
