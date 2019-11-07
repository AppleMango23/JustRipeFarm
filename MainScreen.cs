using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16102019P1S2
{
    public partial class MainScreen : Form
    {
        String textBoxName = "";
        int textBoxAge = 0;
        String textBoxGender = "";
        String dateAndTime = "";
        

        public MainScreen()
        {
            InitializeComponent();
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            showtable();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
            panel4.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
            panel4.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            Labourer labr = new Labourer();
            labr.Name = textBoxName;
            labr.Age = textBoxAge;
            labr.Gender = textBoxGender;
            labr.DateAndTime = dateAndTime;

            LabourerHandler labHnd = new LabourerHandler();
            int recordCnt = labHnd.addNewLabourer(dbConn.getConn(), labr);
            MessageBox.Show(recordCnt + " record has been inserted !!");

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBoxName = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBoxAge = Int32.Parse(textBox3.Text);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxGender = comboBox5.Text;
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
            dateAndTime = (dateTimePicker6.Value).ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        public void showtable()
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            LabourerHandler labHnd = new LabourerHandler();

            dataGridView1.DataSource = labHnd.getAllLabourer(dbConn.getConn());
        }
    }
}
