using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Xml.Linq;
using ListView = System.Windows.Forms.ListView;
namespace Entry_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static ListView listView1 = new ListView();
        // Records are save
        private void button1_Click(object sender, EventArgs e)
        {
            string first_name = textBox1.Text;
            string last_name = textBox2.Text;
            string contact_no = textBox3.Text;
            string address = richTextBox1.Text;
            string warehouse_no = textBox5.Text;
            string warehouse_name = textBox6.Text;  
            string str = "Female";
            if (radioButton1.Checked == true)
            {
                str = "Male";
            }
            ListViewItem list = new ListViewItem(textBox1.Text + " " + textBox2.Text);
            list.SubItems.Add(textBox3.Text);
            list.SubItems.Add(str);
            list.SubItems.Add(richTextBox1.Text);
            list.SubItems.Add(textBox5.Text);
            list.SubItems.Add(textBox6.Text);
            listView1.Items.Add(list);
            MessageBox.Show("Recorde save");
        }
        //Record show on 2nd form
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }
        //Update Record
        private void button3_Click(object sender, EventArgs e)
        {
            string str = "Female";
            if (radioButton1.Checked == true)
            {
                str = "Male";
            }
            foreach (ListViewItem item in listView1.Items)
            {
                String[] str1 = item.SubItems[0].Text.Split(' ');
                Console.WriteLine(str1[0] + " " + str1[1]);
                String contact_no = item.SubItems[1].Text.ToString();
                if (textBox3.Text == contact_no)
                {
                    item.SubItems[0].Text = textBox1.Text + " " + textBox2.Text;
                    item.SubItems[1].Text = textBox3.Text.ToString();
                    item.SubItems[2].Text = str;
                    item.SubItems[3].Text = richTextBox1.Text;
                    item.SubItems[4].Text = textBox5.Text;
                    item.SubItems[5].Text = textBox6.Text;
                    MessageBox.Show("Data Updated");
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string first_name = textBox1.Text;
            string last_name = textBox2.Text;
            string str = "Female";
            if (radioButton1.Checked == true)
            {
                str = "Male";
            }
            string gender = str;
            string contact_no = textBox3.Text;
            string address = richTextBox1.Text;
            string warehouse_no = textBox5.Text;
            string warehouse_name = textBox6.Text;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\VP Programs\Entry Form\Entry Form\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "INSERT INTO CustomerTable (first_name,last_name,gender,contact_no,address,warehouse_no,warehouse_name) VALUES('" + first_name + "','" + last_name + "','" + gender + "','" + contact_no + "','" + address + "','" + warehouse_no + "','" + warehouse_name + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Data Inserted");

            }
            else if (i == 0)
            {
                MessageBox.Show("Sorry! Data not inserted");
            }
        }
        // Clearing Records
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            richTextBox1.Clear();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                String[] str = item.SubItems[0].Text.Split(' ');
                Console.WriteLine(str[0] + " " + str[1]);
                string contact_no = item.SubItems[1].Text.ToString();
                if (textBox3.Text == contact_no)
                {
                    textBox1.Text = str[0];
                    textBox2.Text = str[1];
                    richTextBox1.Text = item.SubItems[3].Text;
                    textBox5.Text = item.SubItems[4].Text;
                    textBox6.Text = item.SubItems[5].Text;
                    MessageBox.Show("Data searched");
                }
            }
        }
    }
}