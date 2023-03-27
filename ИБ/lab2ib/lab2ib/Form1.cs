using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2ib
{
    public partial class Form1 : Form
    {
        int sizeneiman = 10;
        int sizemnogochlen = 10;
        int sizelemer = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var neimandiagram = new neiman(sizeneiman);
            Random x = new Random();
            int seed = x.Next(1000,9999);
            neimandiagram.startneiman(Convert.ToInt32(seed));
            chart1.Series["Series1"].LegendText = "Диаграмма Неймана";
            for (int i = 0; i < neimandiagram.items.Length; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i+1, neimandiagram.items[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var mnogochlendiagram = new mnogochlen(sizemnogochlen);
            mnogochlendiagram.startmnogochleni();
            chart2.Series["Series1"].LegendText = "Диаграмма иррациональный коэффециент";
            for(int i = 0; i < mnogochlendiagram.I.Length; i++)
            {
                chart2.Series["Series1"].Points.AddXY(i + 1, mnogochlendiagram.I[i]);
            }
            mnogochlendiagram.startmnogochlenr();
            chart3.Series["Series1"].LegendText = "Диаграмма рациональный коэффециент";
            for (int i = 0; i < mnogochlendiagram.Q.Length; i++)
            {
                chart3.Series["Series1"].Points.AddXY(i + 1, mnogochlendiagram.Q[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var lemerdiagram = new lemer(sizelemer);
            lemerdiagram.startlemeri();
            chart4.Series["Series1"].LegendText = "Диаграмма иррациональный коэффециент";
            for(int i = 0; i < lemerdiagram.I.Length; i++)
            {
                chart4.Series["Series1"].Points.AddXY(i + 1, lemerdiagram.I[i]);
            }
            lemerdiagram.startlemerq();
            chart5.Series["Series1"].LegendText = "Диаграмма рациональный коэффециент";
            for(int i = 0; i < lemerdiagram.Q.Length; i++)
            {
                chart5.Series["Series1"].Points.AddXY(i + 1, lemerdiagram.Q[i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var lemer2diagram = new lemer2(sizelemer);
            lemer2diagram.startlemer2();
            chart6.Series["Series1"].LegendText = "Диаграмма с наилучшими коэффициентами";
            for(int i = 0; i < lemer2diagram.items.Length; i++)
            {
                chart6.Series["Series1"].Points.AddXY(i + 1, lemer2diagram.items[i]);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var mzdiagram = new mz(10);
            mzdiagram.startmz(5);
            chart7.Series["Series1"].LegendText = "МЗ";
            for (int i = 0; i < mzdiagram.results.Length; i++)
            {
                chart7.Series["Series1"].Points.AddXY(i + 1, mzdiagram.results[i]);
            }
        }
    }
}
