using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3ib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var task1 = new zamena(textBox1.Text);
            task1.startzamena();
            textBox2.Text = task1.result;
            task1.startperestanovka();
            textBox3.Text = task1.result2;
            var task3=new des(textBox1.Text);
            task3.startdes();
            var task32 = new zamena(task3.result);
            task32.startzamena();
            task32.startperestanovka();
            textBox4.Text = task32.result2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var task4 = new enigma();
            task4.startenigma(textBox5.Text, Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text));
            textBox6.Text = task4.result;
        }
    }
}
