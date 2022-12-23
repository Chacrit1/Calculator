using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        double CollectNumber1 = 0.0;
        double CollectNumber2 = 0.0;
        string OperatorNow = "";
        bool OperatorState = false;
        bool EqualState = false;
        private void buttonNumpadClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (EqualState)
            {
                this.textBox1.Text = string.Empty;
                this.textBox2.Text = string.Empty;
                EqualState = false;
            }
            if (this.textBox1.Text == "0" || OperatorState)
            { 
                this.textBox1.Text = string.Empty;
                OperatorState = false;
            }
            if (button.Text == ".")
            {
                if((this.textBox1.Text.Contains(".")))
                {
                    return;
                }
            }
            this.textBox1.Text = this.textBox1.Text + button.Text;
            if (button.Text != ".")
            {
                    this.textBox1.Text = String.Format("{0:#,##0.############}", double.Parse(this.textBox1.Text));
            }

        }

        private void buttonOperatorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "C") {
                this.textBox1.Text = "0";
                this.textBox2.Text = string.Empty;
            }
            if(button.Text == "+" || button.Text == "-" || button.Text =="x"||button.Text=="/" ) {
                if (this.textBox1.Text != "0")
                {
                    CollectNumber1 = Double.Parse(this.textBox1.Text);
                    OperatorNow = button.Text;
                    this.textBox2.Text = this.textBox1.Text + " " + OperatorNow;
                    OperatorState = true;
                }
            }
            if(button.Text == "=")
            {
                CollectNumber2 = Double.Parse(this.textBox1.Text);
                this.textBox2.Text = this.textBox2.Text + " " +this.textBox1.Text + " = ";
                if (OperatorNow == "+")
                {
                    this.textBox1.Text = (CollectNumber1 + CollectNumber2).ToString();
                }
                if (OperatorNow == "-")
                {
                    this.textBox1.Text = (CollectNumber1 - CollectNumber2).ToString();
                }
                if (OperatorNow == "x")
                {
                    this.textBox1.Text = (CollectNumber1 * CollectNumber2).ToString();
                }
                if (OperatorNow == "/")
                {
                    this.textBox1.Text = (CollectNumber1 / CollectNumber2).ToString();
                }
                EqualState = true;
            }
        }

     
    }
}
