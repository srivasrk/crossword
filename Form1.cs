using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WordGame
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Text = "Rules For the Crossword are given Below:\n(1)Working knowledge of XML and WebServices is preferred\n(2)All the responses must be entered in the space provided\n(3)You will have 5 minutes to solve this puzzle\n\n\nIf you agree to the terms and conditions then hit Start or make it!";
            textBox2.Hide();
            button2.Hide();
            button1.Hide();
            label9.Text = "Welcome    ";
        }
        int timeleft, timeleftmin, timeleftsec;

        private List<string> getDataFromXML()
        {
            /***************
            int level = 0;
            **************/
            XmlDocument doc = new XmlDocument();
            doc.Load("WordGame.xml");
            XmlElement rootxml = doc.DocumentElement;
            XmlNodeList nodeList = rootxml.GetElementsByTagName("record");
            List<string> listAnswers = new List<string>();
            List<string> listAnswers1 = new List<string>();

            for (int level = 0; level < nodeList.Count; level++)
            {
                foreach (XmlNode Node in nodeList[level].ChildNodes)
                {
                    if (Node.LocalName == "Answer")
                    {
                        listAnswers.Add(Node.InnerText);
                    }
                }
            }
            for (int level = 0; level < nodeList.Count; level++)
            {
                foreach (XmlNode Node in nodeList[level].ChildNodes)
                {
                    if (Node.LocalName == "Question")
                    {
                        listAnswers1.Add(Node.InnerText);
                    }
                }
            }
            label2.Text = listAnswers1[0];
            label3.Text = listAnswers1[1];
            label5.Text = listAnswers1[2];
            label6.Text = listAnswers1[3];
            label7.Text = listAnswers1[4];
            label8.Text = listAnswers1[5];
            return listAnswers;
            
        }


        private void populateData()
        {
            DataTable dt = new DataTable();
            
            dt.Columns.Add("1");
            dt.Columns.Add("2");
            dt.Columns.Add("3");
            dt.Columns.Add("4");
            dt.Columns.Add("5");
            dt.Columns.Add("6");

            List<string> listStrings = getDataFromXML();

            dt.Rows.Add(listStrings[0][0], "", listStrings[0][2].ToString(), "", "", listStrings[0][5].ToString());
            dt.Rows.Add("", "", "", "", "", "");
            dt.Rows.Add("", "", "", "", "", "");
            dt.Rows.Add("", "", "", "", "", "");
            dt.Rows.Add(listStrings[3][0].ToString(), "", "", listStrings[3][3].ToString(), "", "");
            dt.Rows.Add("", "", "", "", "", "");
            dt.Rows.Add("", "", listStrings[5][0].ToString(), "", "", "");
            dt.Rows.Add("", "", "", "", "", "");
            
            dataGridView1.DataSource = dt;
        }

        private void GrayOutCells()
        {
            dataGridView1.Rows[1].Cells[0].Style.BackColor = Color.Black;
            dataGridView1.Rows[2].Cells[0].Style.BackColor = Color.Black;
            dataGridView1.Rows[3].Cells[0].Style.BackColor = Color.Black;
            dataGridView1.Rows[5].Cells[0].Style.BackColor = Color.Black;
            dataGridView1.Rows[6].Cells[0].Style.BackColor = Color.Black;
            dataGridView1.Rows[7].Cells[0].Style.BackColor = Color.Black;

            dataGridView1.Rows[1].Cells[1].Style.BackColor = Color.Black;
            dataGridView1.Rows[2].Cells[1].Style.BackColor = Color.Black;
            dataGridView1.Rows[3].Cells[1].Style.BackColor = Color.Black;
            dataGridView1.Rows[5].Cells[1].Style.BackColor = Color.Black;
            dataGridView1.Rows[6].Cells[1].Style.BackColor = Color.Black;
            dataGridView1.Rows[7].Cells[1].Style.BackColor = Color.Black;

            dataGridView1.Rows[5].Cells[2].Style.BackColor = Color.Black;
            dataGridView1.Rows[7].Cells[2].Style.BackColor = Color.Black;

            dataGridView1.Rows[1].Cells[3].Style.BackColor = Color.Black;
            dataGridView1.Rows[2].Cells[3].Style.BackColor = Color.Black;
            dataGridView1.Rows[3].Cells[3].Style.BackColor = Color.Black;

            dataGridView1.Rows[1].Cells[4].Style.BackColor = Color.Black;
            dataGridView1.Rows[2].Cells[4].Style.BackColor = Color.Black;
            dataGridView1.Rows[3].Cells[4].Style.BackColor = Color.Black;
            dataGridView1.Rows[4].Cells[4].Style.BackColor = Color.Black;
            dataGridView1.Rows[5].Cells[4].Style.BackColor = Color.Black;
            dataGridView1.Rows[7].Cells[4].Style.BackColor = Color.Black;

            dataGridView1.Rows[4].Cells[5].Style.BackColor = Color.Black;
            dataGridView1.Rows[5].Cells[5].Style.BackColor = Color.Black;
            dataGridView1.Rows[7].Cells[5].Style.BackColor = Color.Black;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }
        
        public void button1_Click(object sender, EventArgs e)
        {
            populateData();
            GrayOutCells();
            timer1.Start();
            timer1.Interval = 1000;
            timeleft = 300;
            label4.Hide();
            groupBox1.Show();
            groupBox2.Show();
            pictureBox1.Hide();
            pictureBox2.Hide();
            textBox2.Show();
            button1.Hide();
            button2.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeleft = (timeleft - 1);
            timeleftsec = timeleft % 60;
            timeleftmin = timeleft / 60;
            label1.Text = "Time Left :  " + timeleftmin.ToString() + " minutes  and " + timeleftsec.ToString() + " seconds";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Hide();
            string str = textBox1.Text;
           if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Crossword incomplete. C ya JackAss!!");
                
            }
             List<string> listStrings= getDataFromXML();
             ansValidation(listStrings);
             
        }
        void ansValidation(List<string> listStrings)
        {
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            bool flag5 = false;
            bool flag6 = false;
            int score = 0;
            if (textBox1.Text.ToUpper() == listStrings[0])
            {
                flag1 = true;
                score = 10;
                dataGridView1.Rows[0].Cells[1].Value = listStrings[0][1];
                dataGridView1.Rows[0].Cells[3].Value = listStrings[0][3];
                dataGridView1.Rows[0].Cells[4].Value = listStrings[0][4];
            }
            if (textBox2.Text.ToUpper() == listStrings[1])
            {
                flag2 = true;
                score =score+ 10;
                dataGridView1.Rows[1].Cells[2].Value = listStrings[1][1];
                dataGridView1.Rows[2].Cells[2].Value = listStrings[1][2];
                dataGridView1.Rows[3].Cells[2].Value = listStrings[1][3];
                dataGridView1.Rows[4].Cells[2].Value = listStrings[1][4];
            }
            if (textBox3.Text.ToUpper() == listStrings[2])
            {
                flag3 = true;
                score = score + 10;
                dataGridView1.Rows[5].Cells[3].Value = listStrings[2][1];
                dataGridView1.Rows[6].Cells[3].Value = listStrings[2][2];
                dataGridView1.Rows[7].Cells[3].Value = listStrings[2][3];

            }
            if (textBox4.Text.ToUpper() == listStrings[3])
            {
                flag4 = true;
                score = score + 10;
                dataGridView1.Rows[4].Cells[1].Value = listStrings[3][1];
                dataGridView1.Rows[4].Cells[2].Value = listStrings[3][2];
            }
            if (textBox5.Text.ToUpper() == listStrings[4])
            {
                flag5 = true;
                score = score + 10;
                dataGridView1.Rows[1].Cells[5].Value = listStrings[4][1];
                dataGridView1.Rows[2].Cells[5].Value = listStrings[4][2];
                dataGridView1.Rows[3].Cells[5].Value = listStrings[4][3];
            }
            if (textBox6.Text.ToUpper() == listStrings[5])
            {
                flag6 = true;
                score = score + 10;
                dataGridView1.Rows[6].Cells[3].Value = listStrings[5][1];
                dataGridView1.Rows[6].Cells[4].Value = listStrings[5][2];
                dataGridView1.Rows[6].Cells[5].Value = listStrings[5][3];
            }
            if (flag1 || flag2 || flag3 || flag4 || flag5 || flag6)
            {
                MessageBox.Show("Total Score: " + score);
            }
            else
            {
                MessageBox.Show("None Of the answers are correct\nTotal Score: " + score);
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            populateData();
            GrayOutCells();
            timer1.Start();
            timer1.Interval = 1000;
            timeleft = 300;
            label4.Hide();
            groupBox1.Show();
            groupBox2.Show();
            pictureBox1.Hide();
            pictureBox2.Hide();
            textBox2.Show();
            button1.Hide();
            button2.Show();
            pictureBox3.Hide();
            label9.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
