using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ib4
{
    public partial class Form1 : Form
    {
        int[] k11v1 = new int[] { 2, 4, 6, 8, 11, 10, 1, 3, 5, 7, 9 };
        int[] k7v1 = new int[] { 3,4,5,6,7,1,2 };
        int[] k11v2 = new int[] { 1,3,5,7,9,11,10,8,6,4,2 };
        int[] k7v2 = new int[] {3,5,7,1,4,2,6 };
        bool[] v1 = new bool[11];//для коммутатора
        bool[] v2 = new bool[7];//для пн
        bool[] s = new bool[11];//сумматор
        int Current_row = 0;
        
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows.Add(1);
            dataGridView2.Rows.Add(1);
            textBox1.Text = "16";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            //dataGridView3.Rows.Add(1);
            //
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int size = 16;
            try
            {
                size = Convert.ToInt32(this.textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Не указан размер\n Применены стандартные настройки, разиер = 16", "error", MessageBoxButtons.OK);
            }
            //кнопка сгенерировать
            if (radioButton1.Checked)
            {
                
                //MessageBox.Show("checked button 1", "good", MessageBoxButtons.OK);
                sdvig();

                input_selection(size, comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex + 1,1);
                for (int i = 0; i < 11; i++)
                {
                    if (v1[i]) dataGridView1.Rows[0].Cells[i].Value = 1;
                    else dataGridView1.Rows[0].Cells[i].Value = 0;
                }
            }
            else if (radioButton2.Checked)
            {

                sdvig();
                for (int i = 0; i < 11; i++)
                {

                    for (int j = 0; j < 10; j++)
                    {
                        v1[j] = v1[j + 1];
                    }
                    v1[10] = v1[0] ^ v1[8];
                    s[i] = summator(v1);
                }
                input_selection(size, comboBox3.SelectedIndex + 1, comboBox4.SelectedIndex + 1, 2);
                  for (int i = 0; i < 11; i++)
                {
                    if (v1[i]) dataGridView1.Rows[0].Cells[i].Value = 1;
                    else dataGridView1.Rows[0].Cells[i].Value = 0;
                } 
                //MessageBox.Show("checked button 2", "good", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("no checked button", "error", MessageBoxButtons.OK);
            }
        }
        //ГПЧ1
        public bool gp41(int[] selected_komm, int choice)
        {
            for (int i = 0; i < 10; i++)
            {
                v1[i] = v1[i + 1];
            }
            v1[10] = v1[0] ^ v1[8];
            int j = 0;
            bool[] vv1 = new bool[11];
            foreach (int i in selected_komm)
            {
                vv1[j] = v1[i - 1];
                j++;
            }
            bool g = false;
            if (choice == 1 ) g = vv1[0] ^ vv1[1] & vv1[2] ^ vv1[3] & vv1[5] & vv1[8] ^ vv1[9] | vv1[10];
            else if (choice == 2) g = vv1[0] | vv1[9] ^ vv1[1] | vv1[4] & vv1[5] ^ vv1[10];
            // возможно тут надо ещё V1=VV1;
            return g;
        }

        void sdvig()//это не СДВИГ, это чтобы считать с таблицы данные входные
        {
            for (int i = 0; i < 11; i++)
            {
                if (Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[i].Value) == 1)
                {
                    v1[i] = true;
                }
                else if (Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[i].Value) == 0)
                {
                    v1[i] = false;
                }
                else
                {
                    MessageBox.Show("wrong input", "error", MessageBoxButtons.OK);
                    break;
                }
            }

        }
        void input_selection(int size, int k, int f,int gp4)
        {
            dataGridView3.Rows.Add(1);
            var builder = new StringBuilder();
            bool g = false;
            if (gp4 == 1)
            {
                for (int i = 0; i < size; i++)
                {
                    if (k == 1) g = gp41(k11v1, f);
                    else if (k == 2) g = gp41(k11v2, f);
                    if (g) builder.Append("1");
                    else if (!g) builder.Append("0");
                }
            }
            if (gp4==2)
            {
                for (int i = 0; i < size; i++)
                {
                    if (k == 1)
                    {
                        g = gp42(k7v1, f);
                    }
                    else if (k == 2)
                    {
                        g = gp42(k7v2, f);
                    }
                    if (g) builder.Append("1");
                    else if (!g) builder.Append("0");
                }
            }
            this.dataGridView3.Rows[Current_row].Cells[0].Value = builder.ToString();
            for (int i = 0; i < 7; i++)
            {
                if (v2[i]) dataGridView2.Rows[0].Cells[i].Value = 1;
                else dataGridView2.Rows[0].Cells[i].Value = 0;
            }
            Current_row++;
        }

        bool summator(bool[] a)
        {
            bool s1 = a[0] ^a [1]^ a[2] ^ a[3] ^ a[4] ^ a[5] ^ a[6] ^ a[7] ^ a[8] ^ a[9] ^ a[10];
            return s1;
        }

        bool gp42(int[] selected_komm, int choice)
        {
            for (int j = 0; j < 10; j++)
            {
                v1[j] = v1[j + 1];
                s[j] = s[j + 1];
            }
            v1[10] = v1[0] ^ v1[8];
            s[10] = summator(v1);
            for (int i = 0; i<7; i++)
            {
                v2[i] = s[i];
            }
            int k = 0;
            bool[] vv1 = new bool[7];
            foreach (int i in selected_komm)
            {
                vv1[k] = v2[i - 1];
                k++;
            }
            bool g = false;
            if (choice == 1) g = vv1[0] & vv1[6] ^ vv1[2] & vv1[3];
            else if (choice == 2) g = vv1[0] & vv1[5] ^ vv1[3] & vv1[4];


            //возможно тут надо ещё V1=VV1;
            return g;
        }
        void lab5(int size)
        {
            float[] p = new float[4];
            for (int k = 0; k < 4; k++)
            {
                String posl = this.dataGridView3.Rows[k].Cells[0].Value.ToString();
                int sum = 0;
                foreach (char c in posl)
                {
                    if (c == '1')
                    {
                        sum++;
                    }
                    
                }
                p[k] = 1 / (float)size * (float)sum;
            }
            textBox2.Text = p[0].ToString();
            textBox4.Text = p[1].ToString();
            textBox5.Text = p[2].ToString();
            textBox6.Text = p[3].ToString();
        }

        void lab5_pper(int size)
        {
            float[] p = new float[4];
            for (int k = 0; k < 4; k++)
            {
                String posl = this.dataGridView3.Rows[k].Cells[0].Value.ToString();
                int sum = 0;
                for(int i=1;i<posl.Length;i++)
                {
                    if (posl[i] == '1'&& posl[i-1]=='0' || posl[i] == '0' && posl[i - 1] == '1')
                    {
                        sum++;
                    }

                    
                }
                p[k] = 1 / (float)size * (float)sum;
            }
            textBox3.Text = p[0].ToString();
            textBox11.Text = p[1].ToString();
            textBox10.Text = p[2].ToString();
            textBox9.Text = p[3].ToString();
        }

        void lab5_2(int size)
        {
            bool[,] poslti_bool = new bool[6,size];
            for(int i = 0;i<4;i++)
            {
                string poslti= this.dataGridView3.Rows[i].Cells[0].Value.ToString();
                for (int j=0;j<poslti.Length;j++)
                {
                    if (poslti[j] == '1') poslti_bool[i,j]=true;
                    else if (poslti[j] == '0') poslti_bool[i, j] = false;
                }

            }
            for (int j = 0; j < size; j++)
            {
                poslti_bool[4, j] = poslti_bool[0, j] ^ poslti_bool[2, j];
                poslti_bool[5, j] = poslti_bool[1, j] ^ poslti_bool[3, j];
            }
            int sum = 0;
            float[] p = new float[2];
            for (int k = 0; k < 2; k++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (poslti_bool[4 +k, j])
                    {
                        sum++;
                    }
                }
                p[k] = (1 / (float)size * (float)sum);
            }
            textBox7.Text = p[0].ToString();
            textBox12.Text = p[1].ToString();
            for (int k = 0; k < 2; k++)
            {
                int sum1 = 0;
                for (int i = 1; i < size; i++)
                {
                    if (poslti_bool[k+4,i] && !poslti_bool[k + 4, i-1] || !poslti_bool[k + 4, i] && poslti_bool[k + 4, i-1])
                    {
                        sum1++;
                    }


                }
                p[k] = 1 / (float)size * (float)sum1;
            }
            textBox8.Text = p[0].ToString();
            textBox13.Text = p[1].ToString();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                lab5(Convert.ToInt32(textBox1.Text));
                lab5_pper(Convert.ToInt32(textBox1.Text));
            }
            catch
            {
                MessageBox.Show("Проверте правильность введёных данных", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                lab5_2(Convert.ToInt32(textBox1.Text));
            }
            catch
            {
                MessageBox.Show("Проверте правильность введёных данных", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Current_row = 0;
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
        }
    }
}
