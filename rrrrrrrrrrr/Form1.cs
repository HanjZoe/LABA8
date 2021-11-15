using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace rrrrrrrrrrr
{
    public partial class Form1 : Form
    {
        int rowIndex;
        Random x = new Random();
        char dell = 'X', Add = '>';
        Class1 list1 = new Class1();
        DataTable table = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }
     

        private void button1_Click(object sender, EventArgs e)
        {
            string name;
            Double price;
            Console.WriteLine(textBox1.Text);
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    price = Convert.ToDouble(textBox2.Text);
                }
                else price = 0;
                name = textBox1.Text;
                list1._add(name, price);
                table_load();
                textBox1.Clear();
                textBox2.Clear();
            }
         


        }

     
      

        private void Form1_Load(object sender, EventArgs e)
        {
           table_load(); 
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rowIndex = e.RowIndex;
                    dataGridView2.Rows.RemoveAt(rowIndex);
                    Console.WriteLine(rowIndex);
                    list1._Dell(rowIndex);
                    table_load();
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream("input.txt", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            for(int i = 0; i < list1.menus.Count; i++)
            {
                streamWriter.WriteLine(list1.menus[i].name + " " + list1.menus[i].price);
            }
            streamWriter.Close();
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        public void table_load()
        {
            double value = 0;
            double value2 = 0;
            double value3 = 0;
            dataGridView1.Rows.Clear();

            for (int i = 0; i < list1.menus.Count; i++)
            {
                dataGridView1.Rows.Add(list1.menus[i].name, list1.menus[i].price, dell, Add);
            }
            dataGridView2.Rows.Clear();
            for (int i = 0; i < list1._check.Count; i++)
            {
                dataGridView2.Rows.Add(list1._check[i].name, list1._check[i].price, dell);
                 value += Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value.ToString());
                label4.Text = Convert.ToString(value);
            }
            dataGridView3.Rows.Clear();
            for (int i = 0; i < list1._classs.Count; i++)
            {
                dataGridView3.Rows.Add(list1._classs[i].suname, list1._classs[i].name, list1._classs[i].age, dell);
                value2 += Convert.ToDouble(dataGridView3.Rows[i].Cells[2].Value.ToString());
                
            }
            label9.Text = Convert.ToString(value2/list1._classs.Count);
            dataGridView4.Rows.Clear();
            for (int i = 0; i < list1._pass.Count; i++)
            {
                dataGridView4.Rows.Add(list1._pass[i].name, list1._pass[i].price);
                
            }
            label12.Text = Convert.ToString(list1._pass.Count);
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] s = File.ReadAllLines("input.txt");
            for (int i = 0; i <s.Length; i++)
            {
                string[] food = s[i].Split(new char[] { ' ' });
                list1._add(food[0], Convert.ToDouble(food[1]));
            }
            table_load();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rowIndex = e.RowIndex;
                    dataGridView3.Rows.RemoveAt(rowIndex);
                    Console.WriteLine(rowIndex);
                    list1.class_dell(rowIndex);
                    table_load();
                }
            }

        }

    private void button2_Click(object sender, EventArgs e)
        {
            string name;
            string suname;
            int age;
            if (!string.IsNullOrWhiteSpace(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                if (!string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    age = Convert.ToInt32(textBox3.Text);
                }
                else age = 0;
                name = textBox4.Text;
                suname = textBox5.Text;
                list1.class_add(suname, name, age);
                table_load();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            }

            private void button3_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream("input1.txt", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            for (int i = 0; i < list1._classs.Count; i++)
            {
                streamWriter.WriteLine(list1._classs[i].suname + " " + list1._classs[i].name + " " + list1._classs[i].age);
            }
            streamWriter.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] s = File.ReadAllLines("input1.txt");
            for (int i = 0; i < s.Length; i++)
            {
                string[] _class = s[i].Split(new char[] { ' ' });
                list1.class_add(_class[0], _class[1], Convert.ToInt32(_class[2]));
            }
            table_load();
        }

        private void KeyPress_c(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream("input2.txt", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            for (int i = 0; i < list1._pass.Count; i++)
            {
                streamWriter.WriteLine(list1._pass[i].name + " " + list1._pass[i].price);
            }
            streamWriter.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string[] s = File.ReadAllLines("input2.txt");
            for (int i = 0; i < s.Length; i++)
            {
                string[] pass = s[i].Split(new char[] { ' ' });
                list1.pass_add(pass[0],  Convert.ToDouble(pass[1]));
            }
            table_load();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            list1.pass_dell();
            int n = x.Next(0,42);
            Console.WriteLine(n);
            for(int i = 0; i<n; i++)
            {
                int c = x.Next(4);
                switch (c)
                {
                    case 0:
                        list1.pass_add("Пенсионный",30);
                        break;
                    case 1:
                        list1.pass_add("Школьный", 20);
                        break;
                    case 2:
                        list1.pass_add("Детский", 10);
                        break;
                    case 3:
                        list1.pass_add("Индивидуальный", 40);
                        break;


                }
                
            }
            table_load();
        }

        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 2)
            {
                if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rowIndex = e.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                    Console.WriteLine(rowIndex);
                    list1._dell(rowIndex);
                    table_load();
                }
            }
            if (e.ColumnIndex == 3)
            {
                string name;
                Double price;
                name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                price = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                list1._Add(name, price);
                table_load();

            }
        }
    }
}
