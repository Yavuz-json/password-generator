using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace password_generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        int passwordVisible;
        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            passwordVisible = 0;

            if (textBox1.Text == "")
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (passwordVisible == 1)
            {
                passwordVisible = 0;
                textBox1.PasswordChar = '*';
                button3.Text = "Visible";
            }
            else if (passwordVisible == 0)
            {
                passwordVisible = 1;
                textBox1.PasswordChar = '\0';
                button3.Text = "Invisible";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            if (textBox1.Text != "")
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            int length = trackBar1.Value;
            string[] password = new string[length];

            bool isLowerCase = checkBox1.Checked;
            bool isUpperCase = checkBox2.Checked;
            bool isNumbers = checkBox3.Checked;
            bool isSymbols = checkBox4.Checked;

            string charsToUse = "";

            string lcc = "abcdefghijklmnopqrstuvwxyz"; 
            string ucc = lcc.ToUpper();
            string nums = "01234567890123456789";
            string symbols = "@._!*,@._!*,";

            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false)
            {
                MessageBox.Show("Error");
            }
            else
            {
                if (isLowerCase == true)
                {
                    charsToUse += lcc;
                }
                if (isUpperCase == true)
                {
                    charsToUse += ucc;
                }
                if (isNumbers == true)
                {
                    charsToUse += nums;
                }
                if (isSymbols == true)
                {
                    charsToUse += symbols;
                }

                Random random = new Random();

                for (int i = 0; i < length; i++)
                {
                    password[i] = charsToUse[random.Next(0, charsToUse.Length - 1)].ToString();
                    textBox1.Text += password[i];
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }
    }
}
