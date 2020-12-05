using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Memory;

namespace Amongusoveraly
{
    public partial class Form1 : Form
    {

        Mem m = new Mem();
        bool ProcOpen = false;
        public const string WINDOW_NAME = "Among Us";
        public int map = 1;
        public int initialStyle = 0;
        public IntPtr Handlee;
        public int RADARX = -999;
        public int RADARY = -999;
        public bool HIDERADAR = false;
        bool opa0 = false;
        bool tpuse = true;

        //on every startup, these values get filled

        


        bool pe1 = true;
        bool pe2 = true;
        bool pe3 = true;
        bool pe4 = true;
        bool pe5 = true;
        bool pe6 = true;
        bool pe7 = true;
        bool pe8 = true;
        bool pe9 = true;
        bool pe10 = true;


        public Form1()
        {

            InitializeComponent();


            //so it wont get called at first startup
            if(resc.firstrun == false)
            {
                //RADAR
                panel5.Location = new Point(resc.MainRadarX, resc.MainRadarY);

                //PLAYER
                panel4.Location = new Point(resc.MainNameX, resc.MainNameY);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCPNN9XllVelxDIX93wxDd_Q");
            CheckForIllegalCrossThreadCalls = false;
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            theskeld.Visible = true;
            Mirahq.Visible = false;
            polus.Visible = false;
            Handlee = this.Handle;
            initialStyle = imports.GetWindowLong(this.Handle, -20);
            imports.SetWindowLong(Handlee, -20, initialStyle | 0x8000 | 0x20);

            imports.GetWindowRect(imports.handle, out imports.rect);
            this.Size = new Size(imports.rect.right - imports.rect.left, imports.rect.bottom - imports.rect.top);
            this.Left = imports.rect.left;

            this.Top = imports.rect.top;




            ProcOpen = m.OpenProcess("Among Us");
            if (!ProcOpen)
            {

                Thread.Sleep(1000);
                return;

            }
            else {
                setnewSize.RunWorkerAsync();
                hotkeys.RunWorkerAsync();
                timer1.Enabled = true;
                timer2.Enabled = true;
                label3.Text = "Cheat enabled!";
            }
        }

        private void setnewSize_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {

                imports.GetWindowRect(imports.handle, out imports.rect);
                //this.Size = new Size(imports.rect.right - imports.rect.left, imports.rect.bottom - imports.rect.top);
                this.Left = imports.rect.left;

                this.Top = imports.rect.top;
                this.TopMost = true;
                Thread.Sleep(10);

            }
        }

        private void hotkeys_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (imports.GetAsyncKeyState(Keys.RShiftKey) < 0)
                {
                    this.TopMost = false;
                    this.Opacity = 0;
                    Form2 f2 = new Form2();
                    f2.TopMost = true;
                    f2.ShowDialog();
                    if(resc.killprogram == true)
                    {
                        this.Close();
                    }
                    this.Opacity = 100;
                    this.TopMost = true;

                    //RADAR
                    panel5.Location = new Point(resc.MainRadarX, resc.MainRadarY);

                    if(resc.HideRadar == true)
                    {
                        panel5.Visible = false;
                    }

                    if (resc.HideRadar == false)
                    {
                        panel5.Visible = true;
                    }

                    //PLAYER
                    panel4.Location = new Point(resc.MainNameX, resc.MainNameY);

                    if (resc.HidePlayer == true)
                    {
                        panel4.Visible = false;
                    }

                    if (resc.HidePlayer == false)
                    {
                        panel4.Visible = true;
                    }


                }
                if (imports.GetAsyncKeyState(Keys.F1) < 0)
                {
                    map = 1;
                    theskeld.Visible = true;
                    Mirahq.Visible = false;
                    polus.Visible = false;
                }
                if (imports.GetAsyncKeyState(Keys.F2) < 0)
                {
                    map = 2;
                    theskeld.Visible = false;
                    Mirahq.Visible = true;
                    polus.Visible = false;
                }
                if (imports.GetAsyncKeyState(Keys.F3) < 0)
                {
                    map = 3;
                    theskeld.Visible = false;
                    Mirahq.Visible = false;
                    polus.Visible = true;
                }
                if (imports.GetAsyncKeyState(Keys.F4) < 0)
                {
                    map = 0;
                    theskeld.Visible = false;
                    Mirahq.Visible = false;
                    polus.Visible = false;
                }
                if (imports.GetAsyncKeyState(Keys.F5) < 0)
                {
                    if(opa0 == false)
                    {
                        this.Opacity = 0;
                        opa0 = true;
                    }
                    else
                    {
                        this.Opacity = 100;
                        opa0 = false;
                    }
                    Thread.Sleep(200);
                }
                if (imports.GetAsyncKeyState(Keys.F7) < 0)
                {
                    if(tpuse == true)
                    {
                        tpuse = false;
                    }
                    else
                    {
                        tpuse = true;
                    }
                }

                if (imports.GetAsyncKeyState(Keys.F6) < 0)
                {
                    this.Close();
                }
                if(tpuse == true)
                {
                    if (imports.GetAsyncKeyState(Keys.J) < 0)
                    {
                        float xcoord = m.ReadFloat("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c");
                        xcoord = xcoord - 1;
                        m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", xcoord + "");
                    }
                    if (imports.GetAsyncKeyState(Keys.I) < 0)
                    {
                        float ycoord = m.ReadFloat("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30");
                        ycoord = ycoord + 1;
                        m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", ycoord + "");
                    }
                    if (imports.GetAsyncKeyState(Keys.K) < 0)
                    {
                        float ycoord = m.ReadFloat("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30");
                        ycoord = ycoord - 1;
                        m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", ycoord + "");
                    }
                    if (imports.GetAsyncKeyState(Keys.L) < 0)
                    {
                        float xcoord = m.ReadFloat("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c");
                        xcoord = xcoord + 1;
                        m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", xcoord + "");
                    }
                }
               
                if (imports.GetAsyncKeyState(Keys.D1) < 0)
                {
                    float eny1 = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,20,5c,2c,8,5c,30");
                    float enx1 = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,20,5c,2c,8,5c,2C");
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", eny1 + "");
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", enx1 + "");
                }
                if (imports.GetAsyncKeyState(Keys.D2) < 0)
                {
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", player2y.Text);
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", player2x.Text);
                }
                if (imports.GetAsyncKeyState(Keys.D3) < 0)
                {
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", player3y.Text);
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", player3x.Text);
                }
                if (imports.GetAsyncKeyState(Keys.D4) < 0)
                {
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", player4y.Text);
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", player4x.Text);
                }
                if (imports.GetAsyncKeyState(Keys.D5) < 0)
                {
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", player5y.Text);
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", player5x.Text);
                }
                if (imports.GetAsyncKeyState(Keys.D6) < 0)
                {
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", player6y.Text);
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", player6x.Text);
                }
                if (imports.GetAsyncKeyState(Keys.D7) < 0)
                {
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", player7y.Text);
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", player7x.Text);
                }
                if (imports.GetAsyncKeyState(Keys.D8) < 0)
                {
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", player8y.Text);
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", player8x.Text);
                }
                if (imports.GetAsyncKeyState(Keys.D9) < 0)
                {
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", player9y.Text);
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", player9x.Text);
                }
                if (imports.GetAsyncKeyState(Keys.D0) < 0)
                {
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,30", "float", player10y.Text);
                    m.WriteMemory("GameAssembly.dll+01455658,5c,20,5c,2c,8,5c,2c", "float", player10x.Text);
                }
                Thread.Sleep(100);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            purplepicbox.Image = Amongusoveraly.Properties.Resources.purple;
            pinkpicbox.Image = Amongusoveraly.Properties.Resources.pink;
            yellowpicbox.Image = Amongusoveraly.Properties.Resources.yellow;
            greenpicbox.Image = Amongusoveraly.Properties.Resources.green;
            bluepicbox.Image = Amongusoveraly.Properties.Resources.blue;
            lightbluepicbox.Image = Amongusoveraly.Properties.Resources.lightblue;
            whitepicbox.Image = Amongusoveraly.Properties.Resources.white;
            orangepicbox.Image = Amongusoveraly.Properties.Resources.orange;
            redpicbox.Image = Amongusoveraly.Properties.Resources.red;
            rosepicbox.Image = Amongusoveraly.Properties.Resources.rose;
            imp1.Visible = false;
            imp2.Visible = false;
            imp3.Visible = false;
            imp4.Visible = false;
            imp5.Visible = false;
            imp6.Visible = false;
            imp7.Visible = false;
            imp8.Visible = false;
            imp9.Visible = false;
            imp10.Visible = false;
            purplepicbox.Visible = false;
            pinkpicbox.Visible = false;
            yellowpicbox.Visible = false;
            greenpicbox.Visible = false;
            bluepicbox.Visible = false;
            lightbluepicbox.Visible = false;
            whitepicbox.Visible = false;
            orangepicbox.Visible = false;
            redpicbox.Visible = false;
            rosepicbox.Visible = false;
            int playerx1 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,20,5c,2c,8,5c,2C");
            int playery1 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,20,5c,2c,8,5c,30");
            int playerx2 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,24,5c,2c,8,5c,2C");
            int playery2 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,24,5c,2c,8,5c,30");
            int playerx3 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,28,5c,2c,8,5c,2C");
            int playery3 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,28,5c,2c,8,5c,30");
            int playerx4 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,2C,5c,2c,8,5c,2C");
            int playery4 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,2C,5c,2c,8,5c,30");
            int playerx5 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,30,5c,2c,8,5c,2C");
            int playery5 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,30,5c,2c,8,5c,30");
            int playerx6 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,1C,5c,2c,8,5c,2C");
            int playery6 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,1C,5c,2c,8,5c,30");
            int playerx7 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,34,5c,2c,8,5c,2C");
            int playery7 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,34,5c,2c,8,5c,30");
            int playerx8 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,14,5c,2c,8,5c,2C");
            int playery8 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,14,5c,2c,8,5c,30");
            int playerx9 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,18,5c,2c,8,5c,2C");
            int playery9 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,18,5c,2c,8,5c,30");
            int playerx10 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,10,5c,2c,8,5c,2C");
            int playery10 = (int)m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,10,5c,2c,8,5c,30");


            if (map == 1)
            {
                //radar

                playerx1 = playerx1 * 9;
                playery1 = playery1 * 9;
                int actualyway1 = 0;
                //calculate
                if (playery1 < 0)
                {
                    actualyway1 = playery1 - (playery1) - (playery1);
                }
                if (playery1 > 0)
                {
                    actualyway1 = playery1 - (playery1) - (playery1);
                }
                playerx1 = playerx1 + 215;
                actualyway1 = actualyway1 + 143;
                yellowpicbox.Location = new Point(playerx1, actualyway1);

                if (!playerinfo1.Text.Equals("Dead"))
                {
                    if (player1imp.Text.Equals("1"))
                    {
                        imp1.Location = new Point(yellowpicbox.Location.X + 6, yellowpicbox.Location.Y + 6);
                        imp1.Visible = true;
                    }
                    if (!player1name.Text.Equals(""))
                    {
                        yellowpicbox.Visible = true;
                    }
                }

                playerx2 = playerx2 * 9;
                playery2 = playery2 * 9;
                int actualyway2 = 0;
                //calculate
                if (playery2 < 0)
                {
                    actualyway2 = playery2 - (playery2) - (playery2);
                }
                if (playery2 > 0)
                {
                    actualyway2 = playery2 - (playery2) - (playery2);
                }
                playerx2 = playerx2 + 215;
                actualyway2 = actualyway2 + 143;
                pinkpicbox.Location = new Point(playerx2, actualyway2);

                if (!playerinfo2.Text.Equals("Dead"))
                {
                    if (player2imp.Text.Equals("1"))
                    {
                        imp2.Location = new Point(pinkpicbox.Location.X + 6, pinkpicbox.Location.Y + 6);
                        imp2.Visible = true;
                    }
                    if (!player2name.Text.Equals(""))
                    {
                        pinkpicbox.Visible = true;
                    }
                }

                playerx3 = playerx3 * 9;
                playery3 = playery3 * 9;
                int actualyway3 = 0;
                //calculate
                if (playery3 < 0)
                {
                    actualyway3 = playery3 - (playery3) - (playery3);
                }
                if (playery3 > 0)
                {
                    actualyway3 = playery3 - (playery3) - (playery3);
                }
                playerx3 = playerx3 + 215;
                actualyway3 = actualyway3 + 143;
                greenpicbox.Location = new Point(playerx3, actualyway3);

                if (!playerinfo3.Text.Equals("Dead"))
                {
                    if (player3imp.Text.Equals("1"))
                    {
                        imp3.Location = new Point(greenpicbox.Location.X + 6, greenpicbox.Location.Y + 6);
                        imp3.Visible = true;
                    }
                    if (!player3name.Text.Equals(""))
                    {
                        greenpicbox.Visible = true;
                    }
                }

                playerx4 = playerx4 * 9;
                playery4 = playery4 * 9;
                int actualyway4 = 0;
                //calculate
                if (playery4 < 0)
                {
                    actualyway4 = playery4 - (playery4) - (playery4);
                }
                if (playery4 > 0)
                {
                    actualyway4 = playery4 - (playery4) - (playery4);
                }
                playerx4 = playerx4 + 215;
                actualyway4 = actualyway4 + 143;
                bluepicbox.Location = new Point(playerx4, actualyway4);
                if (!playerinfo4.Text.Equals("Dead"))
                {
                    if (player4imp.Text.Equals("1"))
                    {
                        imp4.Location = new Point(bluepicbox.Location.X + 6, bluepicbox.Location.Y + 6);
                        imp4.Visible = true;
                    }
                    if (!player4name.Text.Equals(""))
                    {
                        bluepicbox.Visible = true;
                    }
                }

                    playerx5 = playerx5 * 9;
                playery5 = playery5 * 9;
                int actualyway5 = 0;
                //calculate
                if (playery5 < 0)
                {
                    actualyway5 = playery5 - (playery5) - (playery5);
                }
                if (playery5 > 0)
                {
                    actualyway5 = playery5 - (playery5) - (playery5);
                }
                playerx5 = playerx5 + 215;
                actualyway5 = actualyway5 + 143;
                lightbluepicbox.Location = new Point(playerx5, actualyway5);
                if (!playerinfo5.Text.Equals("Dead"))
                {
                    if (player5imp.Text.Equals("1"))
                    {
                        imp5.Location = new Point(lightbluepicbox.Location.X + 6, lightbluepicbox.Location.Y + 6);
                        imp5.Visible = true;
                    }
                    if (!player5name.Text.Equals(""))
                    {
                        lightbluepicbox.Visible = true;
                    }
                }

                playerx6 = playerx6 * 9;
                playery6 = playery6 * 9;
                int actualyway6 = 0;
                //calculate
                if (playery6 < 0)
                {
                    actualyway6 = playery6 - (playery6) - (playery6);
                }
                if (playery6 > 0)
                {
                    actualyway6 = playery6 - (playery6) - (playery6);
                }
                playerx6 = playerx6 + 215;
                actualyway6 = actualyway6 + 143;
                whitepicbox.Location = new Point(playerx6, actualyway6);
                if (!playerinfo6.Text.Equals("Dead"))
                {
                    if (player6imp.Text.Equals("1"))
                    {
                        imp6.Location = new Point(whitepicbox.Location.X + 6, whitepicbox.Location.Y + 6);
                        imp6.Visible = true;
                    }
                    if (!player6name.Text.Equals(""))
                    {
                        whitepicbox.Visible = true;
                    }
                }

                playerx7 = playerx7 * 9;
                playery7 = playery7 * 9;
                int actualyway7 = 0;
                //calculate
                if (playery7 < 0)
                {
                    actualyway7 = playery7 - (playery7) - (playery7);
                }
                if (playery7 > 0)
                {
                    actualyway7 = playery7 - (playery7) - (playery7);
                }
                playerx7 = playerx7 + 215;
                actualyway7 = actualyway7 + 143;
                orangepicbox.Location = new Point(playerx7, actualyway7);
                if (!playerinfo7.Text.Equals("Dead"))
                {
                    if (player7imp.Text.Equals("1"))
                    {
                        imp7.Location = new Point(orangepicbox.Location.X + 6, orangepicbox.Location.Y + 6);
                        imp7.Visible = true;
                    }
                    if (!player7name.Text.Equals(""))
                    {
                        orangepicbox.Visible = true;
                    }
                }

                playerx8 = playerx8 * 9;
                playery8 = playery8 * 9;
                int actualyway8 = 0;
                //calculate
                if (playery8 < 0)
                {
                    actualyway8 = playery8 - (playery8) - (playery8);
                }
                if (playery8 > 0)
                {
                    actualyway8 = playery8 - (playery8) - (playery8);
                }
                playerx8 = playerx8 + 215;
                actualyway8 = actualyway8 + 143;
                redpicbox.Location = new Point(playerx8, actualyway8);
                if (!playerinfo8.Text.Equals("Dead"))
                {
                    if (player8imp.Text.Equals("1"))
                    {
                        imp8.Location = new Point(redpicbox.Location.X + 6, redpicbox.Location.Y + 6);
                        imp8.Visible = true;
                    }
                    if (!player8name.Text.Equals(""))
                    {
                        redpicbox.Visible = true;
                    }
                }


                playerx9 = playerx9 * 9;
                playery9 = playery9 * 9;
                int actualyway9 = 0;
                //calculate
                if (playery9 < 0)
                {
                    actualyway9 = playery9 - (playery9) - (playery9);
                }
                if (playery9 > 0)
                {
                    actualyway9 = playery9 - (playery9) - (playery9);
                }
                playerx9 = playerx9 + 215;
                actualyway9 = actualyway9 + 143;
                purplepicbox.Location = new Point(playerx9, actualyway9);
                if (!playerinfo9.Text.Equals("Dead"))
                {
                    if (player9imp.Text.Equals("1"))
                    {
                        imp9.Location = new Point(purplepicbox.Location.X + 6, purplepicbox.Location.Y + 6);
                        imp9.Visible = true;
                    }
                    if (!player9name.Text.Equals(""))
                    {
                        purplepicbox.Visible = true;
                    }
                }



                playerx10 = playerx10 * 9;
                playery10 = playery10 * 9;
                int actualyway10 = 0;
                //calculate
                if (playery10 < 0)
                {
                    actualyway10 = playery10 - (playery10) - (playery10);
                }
                if (playery10 > 0)
                {
                    actualyway10 = playery10 - (playery10) - (playery10);
                }
                playerx10 = playerx10 + 215;
                actualyway10 = actualyway10 + 143;
                rosepicbox.Location = new Point(playerx10, actualyway10);
                if (!playerinfo10.Text.Equals("Dead"))
                {
                    if (player10imp.Text.Equals("1"))
                    {
                        imp10.Location = new Point(rosepicbox.Location.X + 6, rosepicbox.Location.Y + 6);
                        imp10.Visible = true;
                    }
                    if (!player10name.Text.Equals(""))
                    {
                        rosepicbox.Visible = true;
                    }
                }
            }
            if (map == 2)
            {
                //radar

                playerx1 = playerx1 * 9;
                playery1 = playery1 * 9;
                int actualyway1 = 0;
                //calculate
                if (playery1 < 0)
                {
                    actualyway1 = playery1 - (playery1) - (playery1);
                }
                if (playery1 > 0)
                {
                    actualyway1 = playery1 - (playery1) - (playery1);
                }
                playerx1 = playerx1 + 100;
                actualyway1 = actualyway1 + 258;
                yellowpicbox.Location = new Point(playerx1, actualyway1);
                if (player1imp.Text.Equals("1"))
                {
                    imp1.Location = new Point(yellowpicbox.Location.X + 6, yellowpicbox.Location.Y + 6);
                    imp1.Visible = true;
                }
                if (!player1name.Text.Equals(""))
                {
                    yellowpicbox.Visible = true;
                }

                playerx2 = playerx2 * 9;
                playery2 = playery2 * 9;
                int actualyway2 = 0;
                //calculate
                if (playery2 < 0)
                {
                    actualyway2 = playery2 - (playery2) - (playery2);
                }
                if (playery2 > 0)
                {
                    actualyway2 = playery2 - (playery2) - (playery2);
                }
                playerx2 = playerx2 + 100;
                actualyway2 = actualyway2 + 258;
                pinkpicbox.Location = new Point(playerx2, actualyway2);
                if (player2imp.Text.Equals("1"))
                {
                    imp2.Location = new Point(pinkpicbox.Location.X + 6, pinkpicbox.Location.Y + 6);
                    imp2.Visible = true;
                }
                if (!player2name.Text.Equals(""))
                {
                    pinkpicbox.Visible = true;
                }

                playerx3 = playerx3 * 9;
                playery3 = playery3 * 9;
                int actualyway3 = 0;
                //calculate
                if (playery3 < 0)
                {
                    actualyway3 = playery3 - (playery3) - (playery3);
                }
                if (playery3 > 0)
                {
                    actualyway3 = playery3 - (playery3) - (playery3);
                }
                playerx3 = playerx3 + 100;
                actualyway3 = actualyway3 + 258;
                greenpicbox.Location = new Point(playerx3, actualyway3);
                if (player3imp.Text.Equals("1"))
                {
                    imp3.Location = new Point(greenpicbox.Location.X + 6, greenpicbox.Location.Y + 6);
                    imp3.Visible = true;
                }
                if (!player3name.Text.Equals(""))
                {
                    greenpicbox.Visible = true;
                }

                playerx4 = playerx4 * 9;
                playery4 = playery4 * 9;
                int actualyway4 = 0;
                //calculate
                if (playery4 < 0)
                {
                    actualyway4 = playery4 - (playery4) - (playery4);
                }
                if (playery4 > 0)
                {
                    actualyway4 = playery4 - (playery4) - (playery4);
                }
                playerx4 = playerx4 + 100;
                actualyway4 = actualyway4 + 258;
                bluepicbox.Location = new Point(playerx4, actualyway4);
                if (player4imp.Text.Equals("1"))
                {
                    imp4.Location = new Point(bluepicbox.Location.X + 6, bluepicbox.Location.Y + 6);
                    imp4.Visible = true;
                }
                if (!player4name.Text.Equals(""))
                {
                    bluepicbox.Visible = true;
                }

                playerx5 = playerx5 * 9;
                playery5 = playery5 * 9;
                int actualyway5 = 0;
                //calculate
                if (playery5 < 0)
                {
                    actualyway5 = playery5 - (playery5) - (playery5);
                }
                if (playery5 > 0)
                {
                    actualyway5 = playery5 - (playery5) - (playery5);
                }
                playerx5 = playerx5 + 100;
                actualyway5 = actualyway5 + 258;
                lightbluepicbox.Location = new Point(playerx5, actualyway5);
                if (player5imp.Text.Equals("1"))
                {
                    imp5.Location = new Point(lightbluepicbox.Location.X + 6, lightbluepicbox.Location.Y + 6);
                    imp5.Visible = true;
                }
                if (!player5name.Text.Equals(""))
                {
                    lightbluepicbox.Visible = true;
                }

                playerx6 = playerx6 * 9;
                playery6 = playery6 * 9;
                int actualyway6 = 0;
                //calculate
                if (playery6 < 0)
                {
                    actualyway6 = playery6 - (playery6) - (playery6);
                }
                if (playery6 > 0)
                {
                    actualyway6 = playery6 - (playery6) - (playery6);
                }
                playerx6 = playerx6 + 100;
                actualyway6 = actualyway6 + 258;
                whitepicbox.Location = new Point(playerx6, actualyway6);
                if (player6imp.Text.Equals("1"))
                {
                    imp6.Location = new Point(whitepicbox.Location.X + 6, whitepicbox.Location.Y + 6);
                    imp6.Visible = true;
                }
                if (!player6name.Text.Equals(""))
                {
                    whitepicbox.Visible = true;
                }

                playerx7 = playerx7 * 9;
                playery7 = playery7 * 9;
                int actualyway7 = 0;
                //calculate
                if (playery7 < 0)
                {
                    actualyway7 = playery7 - (playery7) - (playery7);
                }
                if (playery7 > 0)
                {
                    actualyway7 = playery7 - (playery7) - (playery7);
                }
                playerx7 = playerx7 + 100;
                actualyway7 = actualyway7 + 258;
                orangepicbox.Location = new Point(playerx7, actualyway7);
                if (player7imp.Text.Equals("1"))
                {
                    imp7.Location = new Point(orangepicbox.Location.X + 6, orangepicbox.Location.Y + 6);
                    imp7.Visible = true;
                }
                if (!player7name.Text.Equals(""))
                {
                    orangepicbox.Visible = true;
                }

                playerx8 = playerx8 * 9;
                playery8 = playery8 * 9;
                int actualyway8 = 0;
                //calculate
                if (playery8 < 0)
                {
                    actualyway8 = playery8 - (playery8) - (playery8);
                }
                if (playery8 > 0)
                {
                    actualyway8 = playery8 - (playery8) - (playery8);
                }
                playerx8 = playerx8 + 100;
                actualyway8 = actualyway8 + 258;
                redpicbox.Location = new Point(playerx8, actualyway8);
                if (player8imp.Text.Equals("1"))
                {
                    imp8.Location = new Point(redpicbox.Location.X + 6, redpicbox.Location.Y + 6);
                    imp8.Visible = true;
                }
                if (!player8name.Text.Equals(""))
                {
                    redpicbox.Visible = true;
                }


                playerx9 = playerx9 * 9;
                playery9 = playery9 * 9;
                int actualyway9 = 0;
                //calculate
                if (playery9 < 0)
                {
                    actualyway9 = playery9 - (playery9) - (playery9);
                }
                if (playery9 > 0)
                {
                    actualyway9 = playery9 - (playery9) - (playery9);
                }
                playerx9 = playerx9 + 100;
                actualyway9 = actualyway9 + 258;
                purplepicbox.Location = new Point(playerx9, actualyway9);
                if (player9imp.Text.Equals("1"))
                {
                    imp9.Location = new Point(purplepicbox.Location.X + 6, purplepicbox.Location.Y + 6);
                    imp9.Visible = true;
                }
                if (!player9name.Text.Equals(""))
                {
                    purplepicbox.Visible = true;
                }



                playerx10 = playerx10 * 9;
                playery10 = playery10 * 9;
                int actualyway10 = 0;
                //calculate
                if (playery10 < 0)
                {
                    actualyway10 = playery10 - (playery10) - (playery10);
                }
                if (playery10 > 0)
                {
                    actualyway10 = playery10 - (playery10) - (playery10);
                }
                playerx10 = playerx10 + 100;
                actualyway10 = actualyway10 + 258;
                rosepicbox.Location = new Point(playerx10, actualyway10);
                if (player10imp.Text.Equals("1"))
                {
                    imp10.Location = new Point(rosepicbox.Location.X + 6, rosepicbox.Location.Y + 6);
                    imp10.Visible = true;
                }
                if (!player10name.Text.Equals(""))
                {
                    rosepicbox.Visible = true;
                }

            }
            if (map == 3)
            {
                //radar

                playerx1 = playerx1 * 9;
                playery1 = playery1 * 9;
                int actualyway1 = 0;
                //calculate
                if (playery1 < 0)
                {
                    actualyway1 = playery1 - (playery1) - (playery1);
                }
                if (playery1 > 0)
                {
                    actualyway1 = playery1 - (playery1) - (playery1);
                }
                playerx1 = playerx1 + 55;
                actualyway1 = actualyway1 + 50;
                yellowpicbox.Location = new Point(playerx1, actualyway1);
                if (player1imp.Text.Equals("1"))
                {
                    imp1.Location = new Point(yellowpicbox.Location.X + 6, yellowpicbox.Location.Y + 6);
                    imp1.Visible = true;
                }
                if (!player1name.Text.Equals(""))
                {
                    yellowpicbox.Visible = true;
                }

                playerx2 = playerx2 * 9;
                playery2 = playery2 * 9;
                int actualyway2 = 0;
                //calculate
                if (playery2 < 0)
                {
                    actualyway2 = playery2 - (playery2) - (playery2);
                }
                if (playery2 > 0)
                {
                    actualyway2 = playery2 - (playery2) - (playery2);
                }
                playerx2 = playerx2 + 55;
                actualyway2 = actualyway2 + 50;
                pinkpicbox.Location = new Point(playerx2, actualyway2);
                if (player2imp.Text.Equals("1"))
                {
                    imp2.Location = new Point(pinkpicbox.Location.X + 6, pinkpicbox.Location.Y + 6);
                    imp2.Visible = true;
                }
                if (!player2name.Text.Equals(""))
                {
                    pinkpicbox.Visible = true;
                }

                playerx3 = playerx3 * 9;
                playery3 = playery3 * 9;
                int actualyway3 = 0;
                //calculate
                if (playery3 < 0)
                {
                    actualyway3 = playery3 - (playery3) - (playery3);
                }
                if (playery3 > 0)
                {
                    actualyway3 = playery3 - (playery3) - (playery3);
                }
                playerx3 = playerx3 + 55;
                actualyway3 = actualyway3 + 50;
                greenpicbox.Location = new Point(playerx3, actualyway3);
                if (player3imp.Text.Equals("1"))
                {
                    imp3.Location = new Point(greenpicbox.Location.X + 6, greenpicbox.Location.Y + 6);
                    imp3.Visible = true;
                }
                if (!player3name.Text.Equals(""))
                {
                    greenpicbox.Visible = true;
                }

                playerx4 = playerx4 * 9;
                playery4 = playery4 * 9;
                int actualyway4 = 0;
                //calculate
                if (playery4 < 0)
                {
                    actualyway4 = playery4 - (playery4) - (playery4);
                }
                if (playery4 > 0)
                {
                    actualyway4 = playery4 - (playery4) - (playery4);
                }
                playerx4 = playerx4 + 55;
                actualyway4 = actualyway4 + 50;
                bluepicbox.Location = new Point(playerx4, actualyway4);
                if (player4imp.Text.Equals("1"))
                {
                    imp4.Location = new Point(bluepicbox.Location.X + 6, bluepicbox.Location.Y + 6);
                    imp4.Visible = true;
                }
                if (!player4name.Text.Equals(""))
                {
                    bluepicbox.Visible = true;
                }

                playerx5 = playerx5 * 9;
                playery5 = playery5 * 9;
                int actualyway5 = 0;
                //calculate
                if (playery5 < 0)
                {
                    actualyway5 = playery5 - (playery5) - (playery5);
                }
                if (playery5 > 0)
                {
                    actualyway5 = playery5 - (playery5) - (playery5);
                }
                playerx5 = playerx5 + 55;
                actualyway5 = actualyway5 + 50;
                lightbluepicbox.Location = new Point(playerx5, actualyway5);
                if (player5imp.Text.Equals("1"))
                {
                    imp5.Location = new Point(lightbluepicbox.Location.X + 6, lightbluepicbox.Location.Y + 6);
                    imp5.Visible = true;
                }
                if (!player5name.Text.Equals(""))
                {
                    lightbluepicbox.Visible = true;
                }

                playerx6 = playerx6 * 9;
                playery6 = playery6 * 9;
                int actualyway6 = 0;
                //calculate
                if (playery6 < 0)
                {
                    actualyway6 = playery6 - (playery6) - (playery6);
                }
                if (playery6 > 0)
                {
                    actualyway6 = playery6 - (playery6) - (playery6);
                }
                playerx6 = playerx6 + 55;
                actualyway6 = actualyway6 + 50;
                whitepicbox.Location = new Point(playerx6, actualyway6);
                if (player6imp.Text.Equals("1"))
                {
                    imp6.Location = new Point(whitepicbox.Location.X + 6, whitepicbox.Location.Y + 6);
                    imp6.Visible = true;
                }
                if (!player6name.Text.Equals(""))
                {
                    whitepicbox.Visible = true;
                }

                playerx7 = playerx7 * 9;
                playery7 = playery7 * 9;
                int actualyway7 = 0;
                //calculate
                if (playery7 < 0)
                {
                    actualyway7 = playery7 - (playery7) - (playery7);
                }
                if (playery7 > 0)
                {
                    actualyway7 = playery7 - (playery7) - (playery7);
                }
                playerx7 = playerx7 + 55;
                actualyway7 = actualyway7 + 50;
                orangepicbox.Location = new Point(playerx7, actualyway7);
                if (player7imp.Text.Equals("1"))
                {
                    imp7.Location = new Point(orangepicbox.Location.X + 6, orangepicbox.Location.Y + 6);
                    imp7.Visible = true;
                }
                if (!player7name.Text.Equals(""))
                {
                    orangepicbox.Visible = true;
                }

                playerx8 = playerx8 * 9;
                playery8 = playery8 * 9;
                int actualyway8 = 0;
                //calculate
                if (playery8 < 0)
                {
                    actualyway8 = playery8 - (playery8) - (playery8);
                }
                if (playery8 > 0)
                {
                    actualyway8 = playery8 - (playery8) - (playery8);
                }
                playerx8 = playerx8 + 55;
                actualyway8 = actualyway8 + 50;
                redpicbox.Location = new Point(playerx8, actualyway8);
                if (player8imp.Text.Equals("1"))
                {
                    imp8.Location = new Point(redpicbox.Location.X + 6, redpicbox.Location.Y + 6);
                    imp8.Visible = true;
                }
                if (!player8name.Text.Equals(""))
                {
                    redpicbox.Visible = true;
                }


                playerx9 = playerx9 * 9;
                playery9 = playery9 * 9;
                int actualyway9 = 0;
                //calculate
                if (playery9 < 0)
                {
                    actualyway9 = playery9 - (playery9) - (playery9);
                }
                if (playery9 > 0)
                {
                    actualyway9 = playery9 - (playery9) - (playery9);
                }
                playerx9 = playerx9 + 55;
                actualyway9 = actualyway9 + 50;
                purplepicbox.Location = new Point(playerx9, actualyway9);
                if (player9imp.Text.Equals("1"))
                {
                    imp9.Location = new Point(purplepicbox.Location.X + 6, purplepicbox.Location.Y + 6);
                    imp9.Visible = true;
                }
                if (!player9name.Text.Equals(""))
                {
                    purplepicbox.Visible = true;
                }



                playerx10 = playerx10 * 9;
                playery10 = playery10 * 9;
                int actualyway10 = 0;
                //calculate
                if (playery10 < 0)
                {
                    actualyway10 = playery10 - (playery10) - (playery10);
                }
                if (playery10 > 0)
                {
                    actualyway10 = playery10 - (playery10) - (playery10);
                }
                playerx10 = playerx10 + 55;
                actualyway10 = actualyway10 + 50;
                rosepicbox.Location = new Point(playerx10, actualyway10);
                if (player10imp.Text.Equals("1"))
                {
                    imp10.Location = new Point(rosepicbox.Location.X + 6, rosepicbox.Location.Y + 6);
                    imp10.Visible = true;
                }
                if (!player10name.Text.Equals(""))
                {
                    rosepicbox.Visible = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(youxcoord.Text.Equals("0"))
            {
                youkillcooldown.Visible = false;
                youxcoord.Visible = false;
                youspeed.Visible = false;
                youemergencies.Visible = false;
                youimpostor.Visible = false;
                youycoord.Visible = false;
                yy.Visible = false;
                yspeed.Visible = false;
                yemergencies.Visible = false;
                yCC.Visible = false;
                yimp.Visible = false;

            }
            if (!youxcoord.Text.Equals("0"))
            {
                youkillcooldown.Visible = true;
                youxcoord.Visible = true;
                youspeed.Visible = true;
                youemergencies.Visible = true;
                youimpostor.Visible = true;
                youycoord.Visible = true;
                yy.Visible = true;
                yspeed.Visible = true;
                yemergencies.Visible = true;
                yCC.Visible = true;
                yimp.Visible = true;

            }

            if (!player1name.Text.Equals(""))
            {

                playerinfo1.Visible = true;
                player1x.Visible = true;
                player1y.Visible = true;
                player1imp.Visible = true;
                p1.Visible = true;
                pe1 = true;
            }
            if (!player2name.Text.Equals(""))
            {
                playerinfo2.Visible = true;
                player2x.Visible = true;
                player2y.Visible = true;
                player2imp.Visible = true;
                p2.Visible = true;
                pe2 = true;
            }
            if (!player3name.Text.Equals(""))
            {
                playerinfo3.Visible = true;
                player3x.Visible = true;
                player3y.Visible = true;
                player3imp.Visible = true;
                p3.Visible = true;
                pe3 = true;
            }
            if (!player4name.Text.Equals(""))
            {
                playerinfo4.Visible = true;
                player4x.Visible = true;
                player4y.Visible = true;
                player4imp.Visible = true;
                p4.Visible = true;
                pe4 = true;
            }
            if (!player5name.Text.Equals(""))
            {
                playerinfo5.Visible = true;
                player5x.Visible = true;
                player5y.Visible = true;
                player5imp.Visible = true;
                p5.Visible = true;
                pe5 = true;
            }
            if (!player6name.Text.Equals(""))
            {
                playerinfo6.Visible = true;
                player6x.Visible = true;
                player6y.Visible = true;
                player6imp.Visible = true;
                p6.Visible = true;
                pe6 = true;
            }
            if (!player7name.Text.Equals(""))
            {
                playerinfo7.Visible = true;
                player7x.Visible = true;
                player7y.Visible = true;
                player7imp.Visible = true;
                p7.Visible = true;
                pe7 = true;
            }
            if (!player8name.Text.Equals(""))
            {
                playerinfo8.Visible = true;
                player8x.Visible = true;
                player8y.Visible = true;
                player8imp.Visible = true;
                p8.Visible = true;
                pe8 = true;
            }
            if (!player9name.Text.Equals(""))
            {
                playerinfo9.Visible = true;
                player9x.Visible = true;
                player9y.Visible = true;
                player9imp.Visible = true;
                p9.Visible = true;
                pe9 = true;
            }
            if (!player10name.Text.Equals(""))
            {
                playerinfo10.Visible = true;
                player10x.Visible = true;
                player10y.Visible = true;
                player10imp.Visible = true;
                p10.Visible = true;
                pe10 = true;
            }



            if (player1name.Text.Equals(""))
            {

                playerinfo1.Visible = false;
                player1x.Visible = false;
                player1y.Visible = false;
                player1imp.Visible = false;
                p1.Visible = false;
                pe1 = false;
            }
            if (player2name.Text.Equals(""))
            {
                playerinfo2.Visible = false;
                player2x.Visible = false;
                player2y.Visible = false;
                player2imp.Visible = false;
                p2.Visible = false;
                pe2 = false;
            }
            if (player3name.Text.Equals(""))
            {
                playerinfo3.Visible = false;
                player3x.Visible = false;
                player3y.Visible = false;
                player3imp.Visible = false;
                p3.Visible = false;
                pe3 = false;
            }
            if (player4name.Text.Equals(""))
            {
                playerinfo4.Visible = false;
                player4x.Visible = false;
                player4y.Visible = false;
                player4imp.Visible = false;
                p4.Visible = false;
                pe4 = false;
            }
            if (player5name.Text.Equals(""))
            {
                playerinfo5.Visible = false;
                player5x.Visible = false;
                player5y.Visible = false;
                player5imp.Visible = false;
                p5.Visible = false;
                pe5 = false;
            }
            if (player6name.Text.Equals(""))
            {
                playerinfo6.Visible = false;
                player6x.Visible = false;
                player6y.Visible = false;
                player6imp.Visible = false;
                p6.Visible = false;
                pe6 = false;
            }
            if (player7name.Text.Equals(""))
            {
                playerinfo7.Visible = false;
                player7x.Visible = false;
                player7y.Visible = false;
                player7imp.Visible = false;
                p7.Visible = false;
                pe7 = false;
            }
            if (player8name.Text.Equals(""))
            {
                playerinfo8.Visible = false;
                player8x.Visible = false;
                player8y.Visible = false;
                player8imp.Visible = false;
                p8.Visible = false;
                pe8 = false;
            }
            if (player9name.Text.Equals(""))
            {
                playerinfo9.Visible = false;
                player9x.Visible = false;
                player9y.Visible = false;
                player9imp.Visible = false;
                p9.Visible = false;
                pe9 = false;
            }
            if (player10name.Text.Equals(""))
            {
                playerinfo10.Visible = false;
                player10x.Visible = false;
                player10y.Visible = false;
                player10imp.Visible = false;
                p10.Visible = false;
                pe10 = false;
            }

            if(pe1 == true)
            {
                if (player1imp.Text.Equals("1"))
                {
                    playerinfo1.Text = "Impostor";
                }
                if (player1imp.Text.Equals("0"))
                {
                    playerinfo1.Text = "Crewmate";
                }
                if (player1imp.Text.Equals("256"))
                {
                    yellowpicbox.Visible = false;
                    playerinfo1.Text = "Dead";
                    yellowpicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
                if (player1imp.Text.Equals("257"))
                {
                    yellowpicbox.Visible = false;
                    playerinfo1.Text = "Dead";
                    yellowpicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
            }

            if (pe2 == true)
            {
                if (player2imp.Text.Equals("1"))
                {
                    playerinfo2.Text = "Impostor";
                }
                if (player2imp.Text.Equals("0"))
                {
                    playerinfo2.Text = "Crewmate";
                }
                if (player2imp.Text.Equals("256"))
                {
                    pinkpicbox.Visible = false;
                    playerinfo2.Text = "Dead";
                    pinkpicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
                if (player2imp.Text.Equals("257"))
                {
                    pinkpicbox.Visible = false;
                    playerinfo2.Text = "Dead";
                    pinkpicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
            }

            if (pe3 == true)
            {
                if (player3imp.Text.Equals("1"))
                {
                    playerinfo3.Text = "Impostor";
                }
                if (player3imp.Text.Equals("0"))
                {
                    playerinfo3.Text = "Crewmate";
                }
                if (player3imp.Text.Equals("256"))
                {
                    greenpicbox.Visible = false;
                    playerinfo3.Text = "Dead";
                    greenpicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }

                if (player3imp.Text.Equals("257"))
                {
                    greenpicbox.Visible = false;
                    playerinfo3.Text = "Dead";
                    greenpicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
            }

            if (pe4 == true)
            {
                if (player4imp.Text.Equals("1"))
                {
                    playerinfo4.Text = "Impostor";
                }
                if (player4imp.Text.Equals("0"))
                {
                    playerinfo4.Text = "Crewmate";
                }
                if (player4imp.Text.Equals("256"))
                {
                    bluepicbox.Visible = false;
                    playerinfo4.Text = "Dead";
                    bluepicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
                if (player4imp.Text.Equals("257"))
                {
                    bluepicbox.Visible = false;
                    playerinfo4.Text = "Dead";
                    bluepicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
            }

            if (pe5 == true)
            {
                if (player5imp.Text.Equals("1"))
                {
                    playerinfo5.Text = "Impostor";
                }
                if (player5imp.Text.Equals("0"))
                {
                    playerinfo5.Text = "Crewmate";
                }
                if (player5imp.Text.Equals("256"))
                {
                    lightbluepicbox.Visible = false;
                    playerinfo5.Text = "Dead";
                    lightbluepicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
                if (player5imp.Text.Equals("257"))
                {
                    lightbluepicbox.Visible = false;
                    playerinfo5.Text = "Dead";
                    lightbluepicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
            }

            if (pe6 == true)
            {
                if (player6imp.Text.Equals("1"))
                {
                    playerinfo6.Text = "Impostor";
                }
                if (player6imp.Text.Equals("0"))
                {
                    playerinfo6.Text = "Crewmate";
                }
                if (player6imp.Text.Equals("256"))
                {
                    whitepicbox.Visible = false;
                    playerinfo6.Text = "Dead";
                    whitepicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
                if (player6imp.Text.Equals("257"))
                {
                    whitepicbox.Visible = false;
                    playerinfo6.Text = "Dead";
                    whitepicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
            }

            if (pe7 == true)
            {
                if (player7imp.Text.Equals("1"))
                {
                    playerinfo7.Text = "Impostor";
                }
                if (player7imp.Text.Equals("0"))
                {
                    playerinfo7.Text = "Crewmate";
                }
                if (player7imp.Text.Equals("256"))
                {
                    orangepicbox.Visible = false;
                    playerinfo7.Text = "Dead";
                    orangepicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
                if (player7imp.Text.Equals("257"))
                {
                    orangepicbox.Visible = false;
                    playerinfo7.Text = "Dead";
                    orangepicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
            }

            if (pe8 == true)
            {
                if (player8imp.Text.Equals("1"))
                {
                    playerinfo8.Text = "Impostor";
                }
                if (player8imp.Text.Equals("0"))
                {
                    playerinfo8.Text = "Crewmate";
                }
                if (player8imp.Text.Equals("256"))
                {
                    redpicbox.Visible = false;
                    playerinfo8.Text = "Dead";
                    redpicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
                if (player8imp.Text.Equals("257"))
                {
                    redpicbox.Visible = false;
                    playerinfo8.Text = "Dead";
                    redpicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }

            }

            if (pe9 == true)
            {
                if (player9imp.Text.Equals("1"))
                {
                    playerinfo9.Text = "Impostor";
                }
                if (player9imp.Text.Equals("0"))
                {
                    playerinfo9.Text = "Crewmate";
                }
                if (player9imp.Text.Equals("256"))
                {
                    purplepicbox.Visible = false;
                    playerinfo9.Text = "Dead";
                    purplepicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
                if (player9imp.Text.Equals("257"))
                {
                    purplepicbox.Visible = false;
                    playerinfo9.Text = "Dead";
                    purplepicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
            }

            if (pe10 == true)
            {
                if (player10imp.Text.Equals("1"))
                {
                    playerinfo10.Text = "Impostor";
                }
                if (player10imp.Text.Equals("0"))
                {
                    playerinfo10.Text = "Crewmate";
                }
                if (player10imp.Text.Equals("256"))
                {
                    rosepicbox.Visible = false;
                    playerinfo10.Text = "Dead";
                    rosepicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
                if (player10imp.Text.Equals("257"))
                {
                    rosepicbox.Visible = false;
                    playerinfo10.Text = "Dead";
                    rosepicbox.Image = Amongusoveraly.Properties.Resources.dead;
                }
            }

            //You
            youimpostor.Text = m.ReadInt("GameAssembly.dll+1468910,5c,0,34,28") + "";
            youxcoord.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,0,5c,2c,8,5c,2c") + "";
            youycoord.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,0,5c,2c,8,5c,30") + "";
            youspeed.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,0,5c,24") + "";
            youkillcooldown.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,0,44") + "";
            youemergencies.Text = m.ReadInt("GameAssembly.dll+01455658,5c,0,48") + "";

            //Player1
            player1name.Text = m.ReadString("GameAssembly.dll+01455658,5c,28,8,20,4c,2c,c", "", 32, true);
            player1imp.Text = m.ReadInt("GameAssembly.dll+01455658,5c,28,8,20,34,28") + "";
            player1x.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,20,5c,2c,8,5c,2C") + "";
            player1y.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,20,5c,2c,8,5c,30") + "";


            //Player2
            player2name.Text = m.ReadString("GameAssembly.dll+01455658,5c,28,8,24,4c,2c,c", "", 32, true);
            player2imp.Text = m.ReadInt("GameAssembly.dll+01455658,5c,28,8,24,34,28") + "";
            player2x.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,24,5c,2c,8,5c,2C") + "";
            player2y.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,24,5c,2c,8,5c,30") + "";


            //Player3
            player3name.Text = m.ReadString("GameAssembly.dll+01455658,5c,28,8,28,4c,2c,c", "", 32, true);
            player3imp.Text = m.ReadInt("GameAssembly.dll+01455658,5c,28,8,28,34,28") + "";
            player3x.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,28,5c,2c,8,5c,2C") + "";
            player3y.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,28,5c,2c,8,5c,30") + "";


            //Player4
            player4name.Text = m.ReadString("GameAssembly.dll+01455658,5c,28,8,2C,4c,2c,c", "", 32, true);
            player4imp.Text = m.ReadInt("GameAssembly.dll+01455658,5c,28,8,2C,34,28") + "";
            player4x.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,2C,5c,2c,8,5c,2C") + "";
            player4y.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,2C,5c,2c,8,5c,30") + "";


            //Player5
            player5name.Text = m.ReadString("GameAssembly.dll+01455658,5c,28,8,30,4c,2c,c", "", 32, true);
            player5imp.Text = m.ReadInt("GameAssembly.dll+01455658,5c,28,8,30,34,28") + "";
            player5x.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,30,5c,2c,8,5c,2C") + "";
            player5y.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,30,5c,2c,8,5c,30") + "";


            //Player6
            player6name.Text = m.ReadString("GameAssembly.dll+01455658,5c,28,8,1C,4c,2c,c", "", 32, true);
            player6imp.Text = m.ReadInt("GameAssembly.dll+01455658,5c,28,8,1C,34,28") + "";
            player6x.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,1C,5c,2c,8,5c,2C") + "";
            player6y.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,1C,5c,2c,8,5c,30") + "";


            //Player7
            player7name.Text = m.ReadString("GameAssembly.dll+01455658,5c,28,8,34,4c,2c,c", "", 32, true);
            player7imp.Text = m.ReadInt("GameAssembly.dll+01455658,5c,28,8,34,34,28") + "";
            player7x.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,34,5c,2c,8,5c,2C") + "";
            player7y.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,34,5c,2c,8,5c,30") + "";


            //Player8
            player8name.Text = m.ReadString("GameAssembly.dll+01455658,5c,28,8,14,4c,2c,c", "", 32, true);
            player8imp.Text = m.ReadInt("GameAssembly.dll+01455658,5c,28,8,14,34,28") + "";
            player8x.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,14,5c,2c,8,5c,2C") + "";
            player8y.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,14,5c,2c,8,5c,30") + "";

            //Player9
            player9name.Text = m.ReadString("GameAssembly.dll+01455658,5c,28,8,18,4c,2c,c", "", 32, true);
            player9imp.Text = m.ReadInt("GameAssembly.dll+01455658,5c,28,8,18,34,28") + "";
            player9x.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,18,5c,2c,8,5c,2C") + "";
            player9y.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,18,5c,2c,8,5c,30") + "";

            //Player10
            player10name.Text = m.ReadString("GameAssembly.dll+01455658,5c,28,8,10,4c,2c,c", "", 32, true);
            player10imp.Text = m.ReadInt("GameAssembly.dll+01455658,5c,28,8,10,34,28") + "";
            player10x.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,10,5c,2c,8,5c,2C") + "";
            player10y.Text = m.ReadFloat("GameAssembly.dll+01455658,5c,28,8,10,5c,2c,8,5c,30") + "";
        }

        private void wtimer_Tick(object sender, EventArgs e)
        {
            float ycoord = m.ReadFloat("GameAssembly.dll+01455658,5c,0,5c,2c,8,5c,30");
            ycoord = ycoord + 1;
            m.WriteMemory("GameAssembly.dll+01455658,5c,0,5c,2c,8,5c,30", "float", ycoord + "");
            wtimer.Enabled = false;
        }

        private void atimer_Tick(object sender, EventArgs e)
        {
            float xcoord = m.ReadFloat("GameAssembly.dll+01455658,5c,0,5c,2c,8,5c,2c");
            xcoord = xcoord - 1;
            m.WriteMemory("GameAssembly.dll+01455658,5c,0,5c,2c,8,5c,2c", "float", xcoord + "");
            atimer.Enabled = false;
        }

        private void stimer_Tick(object sender, EventArgs e)
        {
            float ycoord = m.ReadFloat("GameAssembly.dll+01455658,5c,0,5c,2c,8,5c,30");
            ycoord = ycoord - 1;
            m.WriteMemory("GameAssembly.dll+01455658,5c,0,5c,2c,8,5c,30", "float", ycoord + "");
            stimer.Enabled = false;
        }

        private void dtimer_Tick(object sender, EventArgs e)
        {
            float xcoord = m.ReadFloat("GameAssembly.dll+01455658,5c,0,5c,2c,8,5c,2c");
            xcoord = xcoord + 1;
            m.WriteMemory("GameAssembly.dll+01455658,5c,0,5c,2c,8,5c,2c", "float", xcoord + "");
            dtimer.Enabled = false;
        }

    }
}
