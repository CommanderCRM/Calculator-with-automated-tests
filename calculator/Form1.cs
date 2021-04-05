using System;
using System.Windows.Forms;
using System.Text;

namespace calculator
{
    public partial class Form1 : Form
    {
  
        public Form1()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
            textBox1.Text = String.Empty;
            
        }
        public static string ans = String.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
                textBox1.Text += button1.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
                textBox1.Text += button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += button7.Text;  
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += button8.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += button11.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
                textBox1.Text += button12.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
                textBox1.Text += button13.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
                textBox1.Text += button16.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
                textBox1.Text += button17.Text;
        }
        //when 9 is pressed
        private void button18_Click(object sender, EventArgs e)
        {
                textBox1.Text += button18.Text;
        }

        //. button
        private void button2_Click(object sender, EventArgs e)
        {
                textBox1.Text += button2.Text;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += " + ";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += " - ";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += " * ";
        }
        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += " / ";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try { textBox1.Text = RPN.Calculate(textBox1.Text).ToString(); }
            catch (MyException ex) { textBox1.Text = ex.type; }
            
        }
        //CE
        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text = ans = String.Empty;
        }
        private void button28_Click(object sender, EventArgs e)
        {
            textBox1.Text += "!";
        }
        //backspace
        private void button31_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                textBox1.Text = (textBox1.Text.Substring(0, textBox1.Text.Length - 1));
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {}
        private void userControl11_Load(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void button33_Click_1(object sender, EventArgs e)
        {
            textBox1.Text += button33.Text;
        }

        private void button40_Click(object sender, EventArgs e)
        {
            textBox1.Text += button40.Text;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (ans.Length > 0)
                textBox1.Text += ans;  
            else
            {
                ans = textBox1.Text;
                textBox1.Text = String.Empty;
            }
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                button5.PerformClick();

            if (e.KeyCode.Equals(Keys.Add))
                button3.PerformClick();

            if (e.KeyCode.Equals(Keys.Subtract))
                button9.PerformClick();

            if (e.KeyCode.Equals(Keys.Multiply))
                button10.PerformClick();

            if (e.KeyCode.Equals(Keys.Divide))
                button15.PerformClick();

            if (e.KeyCode.Equals(Keys.Back))
                button31.PerformClick();

            if (e.KeyCode.Equals(Keys.OemOpenBrackets))
                button33.PerformClick();

            if (e.KeyCode.Equals(Keys.OemCloseBrackets))
                button40.PerformClick();

            if ((e.KeyCode.Equals(Keys.Decimal)) || (e.KeyCode.Equals(Keys.Oemcomma)) || (e.KeyCode.Equals(Keys.OemPeriod)))
                button2.PerformClick();

            if ((e.KeyCode.Equals(Keys.NumPad0)) || (e.KeyCode.Equals(Keys.D0)))
                button1.PerformClick();

            if ((e.KeyCode.Equals(Keys.NumPad1)) || (e.KeyCode.Equals(Keys.D1)))
                button6.PerformClick();

            if ((e.KeyCode.Equals(Keys.NumPad2)) || (e.KeyCode.Equals(Keys.D2)))
                button7.PerformClick();

            if ((e.KeyCode.Equals(Keys.NumPad3)) || (e.KeyCode.Equals(Keys.D3)))
                button8.PerformClick();

            if ((e.KeyCode.Equals(Keys.NumPad4)) || (e.KeyCode.Equals(Keys.D4)))
                button11.PerformClick();

            if ((e.KeyCode.Equals(Keys.NumPad5)) || (e.KeyCode.Equals(Keys.D5)))
                button12.PerformClick();

            if ((e.KeyCode.Equals(Keys.NumPad6)) || (e.KeyCode.Equals(Keys.D6)))
                button13.PerformClick();

            if ((e.KeyCode.Equals(Keys.NumPad7)) || (e.KeyCode.Equals(Keys.D7)))
                button16.PerformClick();

            if ((e.KeyCode.Equals(Keys.NumPad8)) || (e.KeyCode.Equals(Keys.D8)))
                button17.PerformClick();

            if ((e.KeyCode.Equals(Keys.NumPad9)) || (e.KeyCode.Equals(Keys.D9)))
                button18.PerformClick();
        }

        public double method_for_tests(string str)
        {
            StringBuilder st = new StringBuilder(str);
            if (st[0] == '-')
            {
                st[0] = 'm';
            }
            int i = 0;
            while (i != st.Length)
            {
                if (st[i] == '-')
                {
                    if (st[i - 1] == '^' || st[i - 1] == '/' || st[i - 1] == '*')
                    {
                        st[i] = 'm';
                    }

                }
                i++;
            }
            return RPN.Calculate(st.ToString());
        }
    }
} 