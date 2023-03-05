using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string op = Op.Text;
            int res;
            string ans;
            int a = int.Parse(Num1.Text);
            int b = int.Parse(Num2.Text);
            switch(op)
            {
                case "+":res = a + b; ans = res.ToString(); break;
                case "-":res = a - b; ans = res.ToString(); break;
                case "*":res = a * b; ans = res.ToString(); break;
                case "/":res = a / b; ans = res.ToString(); break;
                default:ans = "Error!";break;
            }
            Result.Text = ans;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
