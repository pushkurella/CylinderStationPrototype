using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIAssignment3
{
    public partial class Form1 : Form
    {
        private bool switchedOn = false;
        Random random = new Random(0);
        private System.Windows.Forms.Timer timer;
        private int serial = 0;
        DataTable dt = null;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Environment.CurrentDirectory + @"\sirenfinal.wav");
        public Form1()
        {
            InitializeComponent();
        }
        private  void TimerHandler(object sender,EventArgs e)
        {
            int r = random.Next(7);
            FaultyCylinderAndGauge(r,"norma");

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateDataTable();
        }

        private void CreateDataTable()
        {
            dt = new DataTable("grid");
            // create columns
            for (int i = 0; i < 4; i++)
            {
                dt.Columns.Add();
            }
            dt.Columns[0].ColumnName = "Serial No";
            dt.Columns[1].ColumnName = "Cylinder No";
            dt.Columns[2].ColumnName = "Error Message";
            dt.Columns[3].ColumnName = "Timestamp";
            

        }
        private void FaultyCylinderAndGauge(int r,string option)
        {
            string path = string.Empty;
            string path2 = string.Empty;
            string errormsg = string.Empty;
            int r1 = random.Next(50);
            string tempOption = option;
            if (option=="off")
            {
                path = Environment.CurrentDirectory + @"\cylinderoffinitial.png";
                path2 = Environment.CurrentDirectory + @"\watchinitial.png";
                errormsg = "Normal";

            }
            else if (option=="normal")
            {
                path = Environment.CurrentDirectory + @"\common11frames.gif";
                path2 = Environment.CurrentDirectory + @"\finalpressuregaugecommon11frames.gif";
                errormsg = "Normal";

            }
            else if (r1>= 0 && r1<=10)
            {
                //low pressure
                path = Environment.CurrentDirectory + @"\faultylowpressure.gif";
                path2 = Environment.CurrentDirectory + @"\faultygaugelowpressure.gif";
                errormsg = "Under Pressure!!!";
                player.Play();
            }
            else if(r1>10 && r1<21)
            {
                //high pressure
                path = Environment.CurrentDirectory + @"\faultyhighpressure.gif";
                path2 = Environment.CurrentDirectory + @"\faultygaugehighpressure.gif";
                errormsg = "Over Pressure!!!";
                player.Play();
            }
            else
            {
                path = Environment.CurrentDirectory + @"\common11frames.gif";
                path2 = Environment.CurrentDirectory + @"\finalpressuregaugecommon11frames.gif";
                errormsg = "Normal";
            }
            
            Image image = Image.FromFile(path);
            System.Drawing.ImageAnimator.Animate(image, OnFrameChanged);
            Image image2 = Image.FromFile(path2);
            System.Drawing.ImageAnimator.Animate(image2, OnFrameChanged);
            switch (r) {
                case 1:
                    pictureBox1.Image = Image.FromFile(path);
                    pictureBox9.Image = Image.FromFile(path2);
                    if(tempOption == "off")
                    {
                        pictureBox26.Visible = false;
                        pictureBox32.Visible = false;
                    }
                    else if (errormsg == "Normal")
                    {
                        pictureBox26.Visible = true;
                        pictureBox32.Visible = false;
                    }
                    else
                    {
                        pictureBox26.Visible = false;
                        pictureBox32.Visible = true;
                    }
                    break;
                case 2:
                    pictureBox2.Image = Image.FromFile(path);
                    pictureBox10.Image = Image.FromFile(path2);
                    if (tempOption == "off")
                    {
                        pictureBox27.Visible = false;
                        pictureBox33.Visible = false;
                    }
                    else if(errormsg == "Normal")
                    {
                        pictureBox27.Visible = true;
                        pictureBox33.Visible = false;
                    }
                    else
                    {
                        pictureBox27.Visible = false;
                        pictureBox33.Visible = true;
                    }
                    break;
                case 3:
                    pictureBox3.Image = Image.FromFile(path);
                    pictureBox12.Image = Image.FromFile(path2);
                    if (tempOption == "off")
                    {
                        pictureBox28.Visible = false;
                        pictureBox34.Visible = false;
                    }
                    else if(errormsg == "Normal")
                    {
                        pictureBox28.Visible = true;
                        pictureBox34.Visible = false;
                    }
                    else
                    {
                        pictureBox28.Visible = false;
                        pictureBox34.Visible = true;
                    }
                    break;
                case 4:
                    pictureBox4.Image = Image.FromFile(path);
                    pictureBox8.Image = Image.FromFile(path2);
                    if (tempOption == "off")
                    {
                        pictureBox29.Visible = false;
                        pictureBox35.Visible = false;
                    }
                    else if(errormsg == "Normal" || errormsg == "off")
                    {
                        pictureBox29.Visible = true;
                        pictureBox35.Visible = false;
                    }
                    else
                    {
                        pictureBox29.Visible = false;
                        pictureBox35.Visible = true;
                    }
                    break;
                case 5:
                    pictureBox5.Image = Image.FromFile(path);
                    pictureBox7.Image = Image.FromFile(path2);
                    if (tempOption == "off")
                    {
                        pictureBox30.Visible = false;
                        pictureBox36.Visible = false;
                    }
                    else if(errormsg == "Normal" || errormsg == "off")
                    {
                        pictureBox30.Visible = true;
                        pictureBox36.Visible = false;
                    }
                    else
                    {
                        pictureBox30.Visible = false;
                        pictureBox36.Visible = true;
                    }
                    break;
                case 6:
                    pictureBox6.Image = Image.FromFile(path);
                    pictureBox11.Image = Image.FromFile(path2);
                    if (tempOption == "off")
                    {
                        pictureBox31.Visible = false;
                        pictureBox37.Visible = false;
                    }
                    else if(errormsg == "Normal" || errormsg == "off")
                    {
                        pictureBox31.Visible = true;
                        pictureBox37.Visible = false;
                    }
                    else
                    {
                        pictureBox37.Visible = true;
                        pictureBox31.Visible = false;
                    }
                    break;
                default:
                    break;
               
            }
            serial++;

            UpdateDataGrid(serial, r, errormsg);
        }

        private void UpdateDataGrid(int serial, int r, string errormsg)
        {
            for (int i = 0; i < 1; i++)
            {
                DataRow row = dt.NewRow();

                for (int j = 0; j < 1; j++)
                {
                    row[j] = serial;
                    row[j + 1] = r;
                    row[j + 2] = errormsg;
                    row[j + 3] = DateTime.Now.ToString("hh:mm:ss");

                }

                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;
            //DataGridViewColumn column1 = dataGridView1.Columns[0];
            //column1.Width = 70;
            //DataGridViewColumn column2 = dataGridView1.Columns[1];
            //column2.Width = 50;
            //DataGridViewColumn column3 = dataGridView1.Columns[2];
            //column3.Width = 100;
            //DataGridViewColumn column4 = dataGridView1.Columns[3];
            //column4.Width = 100;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns[1].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns[2].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns[3].DefaultCellStyle.ForeColor = Color.White;

            for (int c = 0; c < dataGridView1.Rows.Count - 1; c++)
            {
                if (dataGridView1.Rows[c].Cells[2].Value.ToString() == "Over Pressure!!!")
                {
                    dataGridView1.Rows[c].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (dataGridView1.Rows[c].Cells[2].Value.ToString() == "Under Pressure!!!")
                {
                    dataGridView1.Rows[c].DefaultCellStyle.BackColor = Color.DarkOrange;
                }
                else
                {
                    dataGridView1.Rows[c].DefaultCellStyle.BackColor = Color.Green;
                }
            }
            dataGridView1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }
        private void OnFrameChanged(object sender, EventArgs e)
        {

        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (!switchedOn)
            {
                switchedOn = true;
                pictureBox14.Visible = false;
                pictureBox15.Visible = true;
                KeepCylindersRunning(switchedOn);
                SetPressureGauges(switchedOn);
                KeepColorWires(switchedOn,"all");
            }
            button7.Text = "Export Data to XML file";
               // allowOnce = false;
                timer = new System.Windows.Forms.Timer();
                timer.Tick += new EventHandler(TimerHandler);
                timer.Interval = 5000;
                timer.Start();
            
        }

        private void KeepColorWires(bool on,string button)
        {
            string path = string.Empty;
            string path2 = string.Empty;
            if (on)
            {
                path = Environment.CurrentDirectory + @"\verticalwire.gif";
                path2 = Environment.CurrentDirectory + @"\horizontalgif.gif";
                
            }
            else
            {
                path = Environment.CurrentDirectory + @"\verticalwireinitial.png";
                path2 = Environment.CurrentDirectory + @"\horizontalwireinitial.png";
            }
            if (button == "1off" || button == "2off" || button == "3off" || button == "4off" || button == "5off" || button == "6off")
            {
                path = Environment.CurrentDirectory + @"\verticalwireinitial.png";
                path2 = Environment.CurrentDirectory + @"\horizontalwireinitial.png";
            }
            Image image = Image.FromFile(path);
            System.Drawing.ImageAnimator.Animate(image, OnFrameChanged);
            if (button == "1")
            {
                pictureBox16.Image = Image.FromFile(path);
            }
            else if (button == "1off")
            {
                pictureBox16.Image = Image.FromFile(path);
            }
            if (button == "2")
            {
                pictureBox17.Image = Image.FromFile(path);
            }
            else if (button == "2off")
            {
                pictureBox17.Image = Image.FromFile(path);
            }
            if (button == "3")
            {
                pictureBox21.Image = Image.FromFile(path);
            }
            else if (button == "3off")
            {
                pictureBox21.Image = Image.FromFile(path);
            }
            if (button == "4")
            {
                pictureBox20.Image = Image.FromFile(path);
            }
            else if (button == "4off")
            {
                pictureBox20.Image = Image.FromFile(path);
            }
            if (button == "5")
            {
                pictureBox19.Image = Image.FromFile(path);
            }
            else if (button == "5off")
            {
                pictureBox19.Image = Image.FromFile(path);
            }
            if (button == "6")
            {
                pictureBox18.Image = Image.FromFile(path);
            }
            else if (button == "6off")
            {
                pictureBox18.Image = Image.FromFile(path);
            }
            if (button=="all")
            {
                pictureBox16.Image = Image.FromFile(path);
                pictureBox17.Image = Image.FromFile(path);
                pictureBox18.Image = Image.FromFile(path);
                pictureBox19.Image = Image.FromFile(path);
                pictureBox20.Image = Image.FromFile(path);
                pictureBox21.Image = Image.FromFile(path);
            }
            //common
            pictureBox23.Image = Image.FromFile(path);
            //using path2
            pictureBox22.Image = Image.FromFile(path2);
            //using path3
            pictureBox24.Image = Image.FromFile(path2);
        }

        private void KeepCylindersRunning(bool on)
        {
            string path = string.Empty;
            if (on)
            {
                path = Environment.CurrentDirectory + @"\common.gif";

            }
            else
            {
                path = Environment.CurrentDirectory + @"\cylinderoffinitial.png";
            }
            
            Image image = Image.FromFile(path);
            System.Drawing.ImageAnimator.Animate(image, OnFrameChanged);
            pictureBox1.Image = Image.FromFile(path);
            pictureBox2.Image = Image.FromFile(path);
            pictureBox3.Image = Image.FromFile(path);
            pictureBox4.Image = Image.FromFile(path);
            pictureBox5.Image = Image.FromFile(path);
            pictureBox6.Image = Image.FromFile(path);
        }

        private void SetPressureGauges(bool on)
        {
            string path = string.Empty;
            if (on)
            {
                path = Environment.CurrentDirectory + @"\watchnormal1.gif";
            }
            else
            {
                path = Environment.CurrentDirectory + @"\watchinitial.png";
            }
            Image image = Image.FromFile(path);
            System.Drawing.ImageAnimator.Animate(image, OnFrameChanged);
            pictureBox7.Image = Image.FromFile(path);
            
            pictureBox8.Image = Image.FromFile(path);
            
            pictureBox9.Image = Image.FromFile(path);
            
            pictureBox10.Image = Image.FromFile(path);
            
            pictureBox11.Image = Image.FromFile(path);
            
            pictureBox12.Image = Image.FromFile(path);
            
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            pictureBox14.Visible = true;
            pictureBox15.Visible = false;
            if(switchedOn)
            {
                switchedOn = false;
                pictureBox14.Visible = true;
                pictureBox15.Visible = false;
                KeepCylindersRunning(switchedOn);
                SetPressureGauges(switchedOn);
                KeepColorWires(switchedOn,"all");
            }
            if (timer!=null)
            {
                timer.Stop();
                CreateDataTable();
                button7.Text = "Export To XML file";
                button1.Text = "RESTART";
                button1.BackColor = Color.Green;
                button2.Text = "RESTART";
                button2.BackColor = Color.Green;
                button3.Text = "RESTART";
                button3.BackColor = Color.Green;
                button4.Text = "RESTART";
                button4.BackColor = Color.Green;
                button5.Text = "RESTART";
                button5.BackColor = Color.Green;
                button6.Text = "RESTART";
                button6.BackColor = Color.Green;
                serial = 0;
               // dataGridView1.DataSource = null;
                pictureBox26.Visible = false;
                pictureBox27.Visible = false;
                pictureBox28.Visible = false;
                pictureBox29.Visible = false;
                pictureBox30.Visible = false;
                pictureBox31.Visible = false;
                pictureBox32.Visible = false;
                pictureBox33.Visible = false;
                pictureBox34.Visible = false;
                pictureBox35.Visible = false;
                pictureBox36.Visible = false;
                pictureBox37.Visible = false;
            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (button1.Text == "RESTART")
            {
                button1.Text = "STOP";
                button1.BackColor = Color.Red;
                FaultyCylinderAndGauge(1, "normal");
                KeepColorWires(true,"1");
            }
            else
            {
                button1.Text = "RESTART";
                button1.BackColor = Color.Green;
                FaultyCylinderAndGauge(1, "off");
                KeepColorWires(true, "1off");

            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (button1.Text == "RESTART")
            {
                button1.BackColor = Color.Green;
            
            }
            else
            {
                button1.BackColor = Color.Red;
                
            }
            button1.ForeColor = SystemColors.HighlightText;
            button1.Height += 4;
            button1.Width += 4;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (button1.Text == "RESTART")
            {
                button1.BackColor = Color.FromArgb(0, 192, 0);

            }
            else
            {
                button1.BackColor = Color.OrangeRed;

            }
            button1.ForeColor = SystemColors.HighlightText;
            button1.Height -= 4;
            button1.Width -= 4;
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if (button2.Text == "RESTART")
            {
                button2.Text = "STOP";
                button2.BackColor = Color.Red;
                FaultyCylinderAndGauge(2, "normal");
                KeepColorWires(true, "2");
            }
            else
            {
                button2.Text = "RESTART";
                button2.BackColor = Color.Green;
                FaultyCylinderAndGauge(2, "off");
                KeepColorWires(true, "2off");

            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            if (button2.Text == "RESTART")
            {
                button2.BackColor = Color.Green;

            }
            else
            {
                button2.BackColor = Color.Red;

            }
            button2.ForeColor = SystemColors.HighlightText;
            button2.Height += 4;
            button2.Width += 4;

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (button2.Text == "RESTART")
            {
                button2.BackColor = Color.FromArgb(0, 192, 0);

            }
            else
            {
                button2.BackColor = Color.OrangeRed;

            }
            button2.ForeColor = SystemColors.HighlightText;
            button2.Height -= 4;
            button2.Width -= 4;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "RESTART")
            {
                button3.Text = "STOP";
                button3.BackColor = Color.Red;
                FaultyCylinderAndGauge(3, "normal");
                KeepColorWires(true, "3");
            }
            else
            {
                button3.Text = "RESTART";
                button3.BackColor = Color.Green;
                KeepColorWires(true, "3off");
                FaultyCylinderAndGauge(3, "off");
            }
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            if (button3.Text == "RESTART")
            {
                button3.BackColor = Color.Green;

            }
            else
            {
                button3.BackColor = Color.Red;

            }
            button3.ForeColor = SystemColors.HighlightText;
            button3.Height += 4;
            button3.Width += 4;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (button3.Text == "RESTART")
            {
                button3.BackColor = Color.FromArgb(0, 192, 0);

            }
            else
            {
                button3.BackColor = Color.OrangeRed;

            }
            button3.ForeColor = SystemColors.HighlightText;
            button3.Height -= 4;
            button3.Width -= 4;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "RESTART")
            {
                button4.Text = "STOP";
                button4.BackColor = Color.Red;
                FaultyCylinderAndGauge(4, "normal");
                KeepColorWires(true, "4");
            }
            else
            {
                button4.Text = "RESTART";
                button4.BackColor = Color.Green;
                KeepColorWires(true, "4off");
                FaultyCylinderAndGauge(4, "off");
            }
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            if (button4.Text == "RESTART")
            {
                button4.BackColor = Color.Green;

            }
            else
            {
                button4.BackColor = Color.Red;

            }
            button4.ForeColor = SystemColors.HighlightText;
            button4.Height += 4;
            button4.Width += 4;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            if (button4.Text == "RESTART")
            {
                button4.BackColor = Color.FromArgb(0, 192, 0);

            }
            else
            {
                button4.BackColor = Color.OrangeRed;

            }
            button4.ForeColor = SystemColors.HighlightText;
            button4.Height -= 4;
            button4.Width -= 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "RESTART")
            {
                button5.Text = "STOP";
                button5.BackColor = Color.Red;
                FaultyCylinderAndGauge(5, "normal");
                KeepColorWires(true, "5");
            }
            else
            {
                button5.Text = "RESTART";
                button5.BackColor = Color.Green;
                KeepColorWires(true, "5off");
                FaultyCylinderAndGauge(5, "off");
            }
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            if (button5.Text == "RESTART")
            {
                button5.BackColor = Color.Green;

            }
            else
            {
                button5.BackColor = Color.Red;

            }
            button5.ForeColor = SystemColors.HighlightText;
            button5.Height += 4;
            button5.Width += 4;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {

        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            if (button5.Text == "RESTART")
            {
                button5.BackColor = Color.FromArgb(0, 192, 0);

            }
            else
            {
                button5.BackColor = Color.OrangeRed;

            }
            button5.ForeColor = SystemColors.HighlightText;
            button5.Height -= 4;
            button5.Width -= 4;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "RESTART")
            {
                button6.Text = "STOP";
                button6.BackColor = Color.Red;
                FaultyCylinderAndGauge(6, "normal");
                KeepColorWires(true, "6");
            }
            else
            {
                button6.Text = "RESTART";
                button6.BackColor = Color.Green;
                KeepColorWires(true, "6off");
                FaultyCylinderAndGauge(6, "off");
            }
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            if (button6.Text == "RESTART")
            {
                button6.BackColor = Color.Green;

            }
            else
            {
                button6.BackColor = Color.Red;

            }
            button6.ForeColor = SystemColors.HighlightText;
            button6.Height += 4;
            button6.Width += 4;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {

        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            if (button6.Text == "RESTART")
            {
                button6.BackColor = Color.FromArgb(0, 192, 0);

            }
            else
            {
                button6.BackColor = Color.OrangeRed;

            }
            button6.ForeColor = SystemColors.HighlightText;
            button6.Height -= 4;
            button6.Width -= 4;
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (dt.Rows.Count < 1)
                {
                    button7.Text = "No Data";
                }
                else
                {
                    button7.Text = "Data Exported";
                    var dataSet = new DataSet();
                    dataSet.Tables.Add(dt);
                    // Writing dataset to xml file or stream
                    dataSet.WriteXml("ExportedXmlFile.xml");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Unable to export file");
            }
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            
            button7.BackColor = Color.DarkViolet;
            button7.ForeColor = SystemColors.HighlightText;
            button7.Height += 4;
            button7.Width += 4;

        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            //button7.Text = "Exported";
            button7.BackColor = Color.DarkViolet;
            button7.ForeColor = SystemColors.HighlightText;
            button7.Height -= 4;
            button7.Width -= 4;

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
    }
}
