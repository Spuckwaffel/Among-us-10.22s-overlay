using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace Amongusoveraly
{

    public partial class Form2 : Form
    {
        Mem m = new Mem();
        public Point mouseLocation;
        bool ProcOpen = false;
        public const string WINDOW_NAME = "Among Us";
        bool dowork = true;
        public float forval = 1f;


        public Form2()
        {
            InitializeComponent();

            this.TopMost = true;

            ControlExtension.Draggable(panel5, true);
            ControlExtension.Draggable(panel1, true);
            ControlExtension.Draggable(panel2, true);
            ControlExtension.Draggable(panel3, true);
            ControlExtension.Draggable(panel4, true);
            ControlExtension.Draggable(panel6, true);

            if (resc.firstrun == false)
            {
                panel5.Location = new Point(resc.MainRadarX, resc.MainRadarY + 22);
                panel4.Location = new Point(resc.MainNameX, resc.MainNameY);
                panel3.Location = new Point(resc.GUIHostX, resc.GUIHostY);
                panel2.Location = new Point(resc.GUIShortcutsX, resc.GUIShortcutsY);
                panel1.Location = new Point(resc.GUITPX, resc.GUITPY);
                panel6.Location = new Point(resc.GUICheatsX, resc.GUICheatsY);

                if(resc.HideRadar == true)
                {
                    checkBox1.Checked = true;
                }
                if (resc.HideRadar == false)
                {
                    checkBox1.Checked = false;
                }

                if (resc.HidePlayer == true)
                {
                    checkBox2.Checked = true;
                }
                if (resc.HidePlayer == false)
                {
                    checkBox2.Checked = false;
                }


                if(resc.GUIradarClosed == true)
                {
                    panel5.Size = new Size(panel5.Width, 25);
                    panel5.BackColor = Color.DarkSlateGray;
                    button20.Text = "Open";
                }
                if (resc.GUIradarClosed == false)
                {
                    panel5.Size = new Size(panel5.Width, 316);
                    panel5.BackColor = Color.Black;
                    button20.Text = "Close";
                }

                if (resc.GUINameClosed == true)
                {
                    panel4.Size = new Size(panel4.Width, 30);
                    panel4.BackColor = Color.DarkSlateGray;
                    button45.Text = "Open";
                }
                if (resc.GUINameClosed == false)
                {
                    panel4.Size = new Size(panel4.Width, 368);
                    panel4.BackColor = Color.Black;
                    button45.Text = "Close";
                }

                if (resc.GUITPClosed == true)
                {
                    panel1.Size = new Size(panel1.Width, 25);
                    panel1.BackColor = Color.DarkSlateGray;
                    button41.Text = "Open";
                }
                if (resc.GUITPClosed == false)
                {
                    panel1.Size = new Size(panel1.Width, 329);
                    panel1.BackColor = Color.Black;
                    button41.Text = "Close";
                }

                //l
                if (resc.GUIHostClosed == true)
                {
                    panel3.Size = new Size(panel3.Width, 25);
                    panel3.BackColor = Color.DarkSlateGray;
                    button1.Text = "Open";
                }
                if (resc.GUIHostClosed == false)
                {
                    panel3.Size = new Size(panel3.Width, 480);
                    panel3.BackColor = Color.Black;
                    button1.Text = "Close";
                }

                //ll
                if (resc.GUIShortcutsClosed == true)
                {
                    panel2.Size = new Size(panel2.Width, 30);
                    panel2.BackColor = Color.DarkSlateGray;
                    button2.Text = "Open";
                }
                if (resc.GUIShortcutsClosed == false)
                {
                    panel2.Size = new Size(panel2.Width, 322);
                    panel2.BackColor = Color.Black;
                    button2.Text = "Close";
                }

                if (resc.GUICheatsClosed == true)
                {
                    panel6.Size = new Size(panel6.Width, 30);
                    panel6.BackColor = Color.DarkSlateGray;
                    button46.Text = "Open";
                }
                if (resc.GUICheatsClosed == false)
                {
                    panel6.Size = new Size(panel6.Width, 192);
                    panel6.BackColor = Color.Black;
                    button46.Text = "Close";
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            theskeld.Visible = true;
            Mirahq.Visible = false;
            polus.Visible = false;

            CheckForIllegalCrossThreadCalls = false;
            this.BackColor = Color.Gray;
            this.TransparencyKey = Color.Gray;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Opacity = 100;
            this.Left = imports.rect.left;

            this.Top = imports.rect.top;
            ProcOpen = m.OpenProcess("Among Us");
            if (!ProcOpen)
            {

                Thread.Sleep(1000);
                return;

            }
            else
            {

                hotkeys.RunWorkerAsync();
                setnewSize1.RunWorkerAsync();
                label32.Text = "Cheat enabled!";
            }
        }

        private void setnewSize(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                this.TopLevel = true;
                this.TopMost = true;
                this.Left = imports.rect.left;

                this.Top = imports.rect.top;


                Thread.Sleep(10);
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            theskeld.Visible = true;
            Mirahq.Visible = false;
            polus.Visible = false;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            theskeld.Visible = false;
            Mirahq.Visible = true;
            polus.Visible = false;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            theskeld.Visible = false;
            Mirahq.Visible = false;
            polus.Visible = true;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCPNN9XllVelxDIX93wxDd_Q");
        }

        private void hotkeys_DoWork(object sender, DoWorkEventArgs e)
        {
            while (dowork == true)
            {
                if (imports.GetAsyncKeyState(Keys.Escape) < 0)
                {

                    dowork = false;
                    //RADAR
                    if (button20.Text.Equals("Close"))
                    {
                        resc.GUIradarClosed = false;
                    }
                    if (button20.Text.Equals("Open"))
                    {
                        resc.GUIradarClosed = true;
                    }
                    resc.MainRadarX = panel5.Location.X;
                    resc.MainRadarY = panel5.Location.Y - 22;
                    if(checkBox1.Checked == true)
                    {
                        resc.HideRadar = true;
                    }
                    if (checkBox1.Checked == false)
                    {
                        resc.HideRadar = false;
                    }


                    //NAMES
                    if (button45.Text.Equals("Close"))
                    {
                        resc.GUINameClosed = false;
                    }
                    if (button45.Text.Equals("Open"))
                    {
                        resc.GUINameClosed = true;
                    }
                    resc.MainNameX = panel4.Location.X;
                    resc.MainNameY = panel4.Location.Y;
                    if (checkBox2.Checked == true)
                    {
                        resc.HidePlayer = true;
                    }
                    if (checkBox2.Checked == false)
                    {
                        resc.HidePlayer = false;
                    }

                    //PLAYER TP
                    if (button41.Text.Equals("Close"))
                    {
                        resc.GUITPClosed = false;
                    }
                    if (button41.Text.Equals("Open"))
                    {
                        resc.GUITPClosed = true;
                    }
                    resc.GUITPX = panel1.Location.X;
                    resc.GUITPY = panel1.Location.Y;

                    //cheats
                    if (button46.Text.Equals("Close"))
                    {
                        resc.GUICheatsClosed = false;
                    }
                    if (button46.Text.Equals("Open"))
                    {
                        resc.GUICheatsClosed = true;
                    }
                    resc.GUICheatsX = panel6.Location.X;
                    resc.GUICheatsY = panel6.Location.Y;

                    //HOST
                    if (button1.Text.Equals("Close"))
                    {
                        resc.GUIHostClosed = false;
                    }
                    if (button1.Text.Equals("Open"))
                    {
                        resc.GUIHostClosed = true;
                    }
                    resc.GUIHostX = panel3.Location.X;
                    resc.GUIHostY = panel3.Location.Y;

                    //SHORTCUTS
                    if (button2.Text.Equals("Close"))
                    {
                        resc.GUIShortcutsClosed = false;
                    }
                    if (button2.Text.Equals("Open"))
                    {
                        resc.GUIShortcutsClosed = true;
                    }
                    resc.GUIShortcutsX = panel2.Location.X;
                    resc.GUIShortcutsY = panel2.Location.Y;

                    resc.firstrun = false;

                    this.TopMost = false;


                    Thread.Sleep(10);
                    this.Close();
                }
                Thread.Sleep(100);
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X + 1500, mouseLocation.Y - 20);
                panel5.Location = mousePose;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if(button20.Text.Equals("Close"))
            {
                panel5.Size = new Size(panel5.Width, 25);
                panel5.BackColor = Color.DarkSlateGray;
                button20.Text = "Open";
            }
            else
            {
                panel5.Size = new Size(panel5.Width, 316);
                panel5.BackColor = Color.Black;
                button20.Text = "Close";
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (button41.Text.Equals("Close"))
            {
                panel1.Size = new Size(panel1.Width, 25);
                panel1.BackColor = Color.DarkSlateGray;
                button41.Text = "Open";
            }
            else
            {
                panel1.Size = new Size(panel1.Width, 329);
                panel1.BackColor = Color.Black;
                button41.Text = "Close";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text.Equals("Close"))
            {
                panel2.Size = new Size(panel2.Width, 30);
                panel2.BackColor = Color.DarkSlateGray;
                button2.Text = "Open";
            }
            else
            {
                panel2.Size = new Size(panel2.Width, 284);
                panel2.BackColor = Color.Black;
                button2.Text = "Close";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Close"))
            {
                panel3.Size = new Size(panel3.Width, 25);
                panel3.BackColor = Color.DarkSlateGray;
                button1.Text = "Open";
            }
            else
            {
                panel3.Size = new Size(panel3.Width, 480);
                panel3.BackColor = Color.Black;
                button1.Text = "Close";
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (button45.Text.Equals("Close"))
            {
                panel4.Size = new Size(panel4.Width, 30);
                panel4.BackColor = Color.DarkSlateGray;
                button45.Text = "Open";
            }
            else
            {
                panel4.Size = new Size(panel4.Width, 368);
                panel4.BackColor = Color.Black;
                button45.Text = "Close";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "-5.575904846"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "-20.66352844"); //X

        }

        private void button3_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "-12.07517338"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "-15.24755573"); //X

        }

        private void button18_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "-0.9380099773"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "-15.39218712"); //X

        }

        private void button15_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "-5.331996918"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "-13.17671585"); //X

        }

        private void button4_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "-4.389159203"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "-9.004479408"); //X

        }

        private void button5_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "-8.705735207"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "-8.084013939"); //X

        }

        private void button6_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "-13.33019447"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "-3.724923134"); //X<

        }

        private void button19_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "-0.4331727028"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "-0.8126907349"); //X

        }

        private void button9_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "-8.727617264"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "2.893512249"); //X

        }

        private void button7_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "-16.00076866"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "4.151418686"); //X

        }

        private void button10_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "-3.676559925"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "6.860258102"); //X

        }

        private void button11_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "1.103766561"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "9.473914146"); //X

        }

        private void button8_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "-12.97463322"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "9.252508163"); //X

        }

        private void button14_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "3.566178799"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "13.35726261"); //X

        }

        private void button12_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", "-4.855072498"); // Y
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", "16.70541191"); //X

        }

        private void label9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click on any button on the map to teleport to that point");

        }

        private void label10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Say for how much your character should move each time you press a key in the free box");

        }

        private void label8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this is the free box. just press in there w, a, s or d to move a specific value (enter the value at the for box)");

        }

        private void label7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("enter a x coordinate and press go to tp");

        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("enter a y coordinate and press go to tp");

        }

        private void button37_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5C,24,10", "byte", "0");

        }

        private void button36_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5C,24,10", "byte", "1");

        }

        private void button31_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5C,24,10", "byte", "2");

        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                m.WriteMemory("GameAssembly.dll+01455658,05c,24,38", "int", impostorstextbox.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("You can only use numbers! \nFor example: 15");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,05c,24,4C", "int", "1");

        }

        private void button23_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,05c,24,4C", "int", "0");

        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                m.WriteMemory("GameAssembly.dll+01455658,5C,24,30", "int", emergencymeetingstextbox.Text);
            }
            catch
            {
                MessageBox.Show("You can only use numbers! \nFor example: 15");
            }

        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                m.WriteMemory("GameAssembly.dll+01455658,05c,24,34", "int", emergencycooldowntextbox.Text);
            }
            catch
            {
                MessageBox.Show("You can only use numbers! \nFor example: 15");
            }

        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                m.WriteMemory("GameAssembly.dll+01455658,05c,24,44", "int", discussiontimetextbox.Text);
            }
            catch
            {
                MessageBox.Show("You can only use numbers! \nFor example: 15");
            }

        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                m.WriteMemory("GameAssembly.dll+01455658,05c,24,48", "int", votingtimetextbox.Text);
            }
            catch
            {
                MessageBox.Show("You can only use numbers! \nFor example: 15");
            }

        }

        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                m.WriteMemory("GameAssembly.dll+01455658,5C,24,14", "float", playerspeedtextbox.Text);
            }
            catch
            {
                MessageBox.Show("You can only use numbers and . ! \nFor example: 15.593");
            }

        }

        private void button29_Click(object sender, EventArgs e)
        {
            try
            {
                m.WriteMemory("GameAssembly.dll+01455658,5C,24,18", "float", playervisiontextbox.Text);
            }
            catch
            {
                MessageBox.Show("You can only use numbers and . ! \nFor example: 15.593");
            }

        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                m.WriteMemory("GameAssembly.dll+01455658,5C,24,1C", "float", impostorvisiontextbox.Text);
            }
            catch
            {
                MessageBox.Show("You can only use numbers and . ! \nFor example: 15.593");
            }

        }

        private void button32_Click(object sender, EventArgs e)
        {
            try
            {
                m.WriteMemory("GameAssembly.dll+01455658,5C,24,20", "float", killcooldowntextbox.Text);
            }
            catch
            {
                MessageBox.Show("You can only use numbers and . ! \nFor example: 15.593");
            }

        }

        private void button35_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,05c,24,40", "int", "0");

        }

        private void button34_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,05c,24,40", "int", "1");

        }

        private void button33_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,05c,24,40", "int", "2");

        }

        private void button38_Click(object sender, EventArgs e)
        {
            try
            {
                m.WriteMemory("GameAssembly.dll+01455658,5C,24,24", "int", commontaskstextbox.Text);
            }
            catch
            {
                MessageBox.Show("You can only use numbers!");
            }

        }

        private void button39_Click(object sender, EventArgs e)
        {
            try
            {
                m.WriteMemory("GameAssembly.dll+01455658,5C,24,28", "int", longtaskstextbox.Text);
            }
            catch
            {
                MessageBox.Show("You can only use numbers!");
            }

        }

        private void button40_Click(object sender, EventArgs e)
        {
            try
            {
                m.WriteMemory("GameAssembly.dll+01455658,5c,24,2C", "int", shorttaskstextbox.Text);
            }
            catch
            {
                MessageBox.Show("You can only use numbers!");
            }

        }

        private void button47_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,34,29", "byte", "0");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           m.WriteMemory("GameAssembly.dll+01455658,5C,24,1a", "int", trackBar1.Value + "");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked == true)
            {
                m.WriteMemory("UnityPlayer.dll+960CA5", "bytes", "0F 85");
            }
            else
            {
                m.WriteMemory("UnityPlayer.dll+960CA5", "bytes", "0F 84");
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                m.FreezeValue("GameAssembly.dll+01455658,5c,20,44", "float", "0");
            }
            else
            {
                m.UnfreezeValue("GameAssembly.dll+01455658,5c,20,44");
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (button46.Text.Equals("Close"))
            {
                panel6.Size = new Size(panel6.Width, 30);
                panel6.BackColor = Color.DarkSlateGray;
                button46.Text = "Open";
            }
            else
            {
                panel6.Size = new Size(panel6.Width, 192);
                panel6.BackColor = Color.Black;
                button46.Text = "Close";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            forval = float.Parse(fortextbox.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals("w"))
            {
                float ycoord = m.ReadFloat("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30");
                ycoord = ycoord + forval;
                m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", ycoord + "");
            }
            if (textBox3.Text.Equals("a"))
            {
                float xcoord = m.ReadFloat("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c");
                xcoord = xcoord - forval;
                m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", xcoord + "");
            }
            if (textBox3.Text.Equals("s"))
            {
                float ycoord = m.ReadFloat("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30");
                ycoord = ycoord - forval;
                m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", ycoord + "");
            }
            if (textBox3.Text.Equals("d"))
            {
                float xcoord = m.ReadFloat("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c");
                xcoord = xcoord + forval;
                m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", xcoord + "");
            }
            textBox3.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", xcoordstextbox.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("You can only use numbers and . ! \nFor example: 15.3002");
            }
        }

        private void ycoordsbutton_Click(object sender, EventArgs e)
        {
            try
            {
                m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", ycoordstextbox.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("You can only use numbers and . ! \nFor example: 15.3002");
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,34,28", "int", "1");
        }

        private void button49_Click(object sender, EventArgs e)
        {
            m.WriteMemory("GameAssembly.dll+01455658,5c,20,34,28", "int", "0");
        }

        private void button50_Click(object sender, EventArgs e)
        {
            resc.killprogram = true;
            this.Close();
        }
    }
}
