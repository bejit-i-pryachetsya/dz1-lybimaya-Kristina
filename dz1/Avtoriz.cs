using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace dz1
{



    public partial class Avtoriz : Form
    {


        

        public Avtoriz()
        {
            InitializeComponent();
            DB x = new DB();
            DataTable contacts = x.WiewContacts();
            dataGridView1.DataSource = contacts;
            dataGridView1.Columns[0].HeaderText = "Имя";
            dataGridView1.Columns[1].HeaderText = "Номер телефона";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool val = true;
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                
                val= false;
            }
            else if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                val = false;
            }
            else if (Regex.IsMatch(textBox2.Text, @"^\d+$") == false)
            {
                MessageBox.Show("Номер телефона должен содержать только цифры!");
                val = false;
            }
            else if (textBox2.TextLength != 11)
            {
                MessageBox.Show("Введите корректный номер телефона!");
                val = false;
            }
            else if (val == true)
            {
                try
                {
                    DB x = new DB();
                    x.SetContact(textBox1.Text, textBox2.Text);
                    DataTable contacts = x.WiewContacts();
                    dataGridView1.DataSource = contacts;
                    dataGridView1.Columns[0].HeaderText = "Имя";
                    dataGridView1.Columns[1].HeaderText = "Номер телефона";
                }
                catch
                {
                    MessageBox.Show("Что то пошло не так:(");
                   
                }

                textBox1.Clear();
                textBox2.Clear();
            }
            
        }

        public int r;
        public string column;
        private  void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            column = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            r = e.ColumnIndex;
          
        }


        

        private void button3_Click(object sender, EventArgs e)
        {

            bool val = true;

            if (string.IsNullOrEmpty(textBox1.Text) == true & string.IsNullOrEmpty(textBox2.Text) == true)
            {
                MessageBox.Show("Хотя бы одно из полей должно быть заполнено!");
                
                val = false;
            }   
            else if (val == true)
            {
                try
                {

                    string name = "name";
                    string phone = "phone_number";
                    string new_name = textBox1.Text;
                    string new_phone = textBox2.Text;
                    DB x = new DB();
                    NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=5432;Database=Dz1;Username=postgres;Password=12345");

                    
                    

                    if (r == 0 & string.IsNullOrEmpty(textBox1.Text) == true)
                    {
                        MessageBox.Show("Введите новое имя!");
                        
                            val = false;
                       
                        

                    }
                    else if (r == 0 & string.IsNullOrEmpty(textBox1.Text) == false)
                    {
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        string sql = ($"update contacts set name = '{new_name}' where name = '{column}';");
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                        ds.Reset();
                        da.Fill(dt);
                        DataTable contacts = x.WiewContacts();
                        dataGridView1.DataSource = contacts;
                        dataGridView1.Columns[0].HeaderText = "Имя";
                        dataGridView1.Columns[1].HeaderText = "Номер телефона";
                        
                    }

                    else if (r == 1 & string.IsNullOrEmpty(textBox2.Text) == true)
                    {

                        MessageBox.Show("Введите новый номер!");
                        val = false;
                        
                        
                    }
                    else if (Regex.IsMatch(textBox2.Text, @"^\d+$") == false)
                    {
                        MessageBox.Show("Номер телефона должен содержать только цифры!");
                        val = false;
                    }
                    else if (textBox2.TextLength != 11)
                    {
                        MessageBox.Show("Введите корректный номер телефона!");
                        val = false;
                    }
                    else if (r == 1 & string.IsNullOrEmpty(textBox2.Text) == false)
                    {
                        DataSet ds1 = new DataSet();
                        DataTable dt1 = new DataTable();
                        string sql1 = ($"update contacts set phone_number = '{new_phone}' where phone_number = '{column}';");
                        NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(sql1, conn);
                        ds1.Reset();
                        da1.Fill(dt1);
                        DataTable contacts = x.WiewContacts();
                        dataGridView1.DataSource = contacts;
                        dataGridView1.Columns[0].HeaderText = "Имя";
                        dataGridView1.Columns[1].HeaderText = "Номер телефона";
                        
                    }


                    
                    
                }

                catch
                {
                    MessageBox.Show("Что то пошло не так:(");
                  
                }
                textBox1.Clear();
                textBox2.Clear();
            }

               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool val = true;
            DB x = new DB();  
                x.DeleteContact(column);

            DataTable contacts = x.WiewContacts();
            dataGridView1.DataSource = contacts;
            dataGridView1.Columns[0].HeaderText = "Имя";
            dataGridView1.Columns[1].HeaderText = "Номер телефона";
           

            textBox1.Clear();
            textBox2.Clear();
            }
        }
    }




