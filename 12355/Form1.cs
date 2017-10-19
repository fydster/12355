using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace _12355
{  
    public partial class Form1 : Form
    {
        /*
        private const int SW_HIDE = 0;  //隐藏任务栏
        private const int SW_RESTORE = 9;//显示任务栏
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int ShowWindow(int hwnd, int nCmdShow);
        */

        System.Timers.Timer t = new System.Timers.Timer(1000);   //实例化Timer类，设置间隔时间为10000毫秒；   
        public int second = 0;
        public int tempSecond = 0;
        public int MinuteNum = 0;
        public int SecondNum = 0;
        public bool isStart = false;
        public bool isFirst = true;
        public int fenzh = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void DJS(object source, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke((EventHandler)delegate
            {
                tempSecond++;

                int Minu = Convert.ToInt16((second - tempSecond) / 60);
                int Secos = (second - tempSecond) % 60;
                string MinuteS = Minu.ToString();
                if (MinuteS.Length == 1)
                {
                    MinuteS = "0" + MinuteS;
                }
                string SecondS = Secos.ToString();
                if (SecondS.Length == 1)
                {
                    SecondS = "0" + SecondS;
                }

                if (second >= tempSecond)
                {
                    label7.Text = MinuteS;
                    label7.Refresh();

                    label9.Text = SecondS;
                    label9.Refresh();
                }

                if ((second - tempSecond) == 60)
                {
                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = "60.wav";
                    player.Load();
                    player.Play();
                }
                if ((second - tempSecond) <= 5)
                {
                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = "5.wav";
                    player.Load();
                    player.Play();
                }
                if (second == (tempSecond-1))
                {
                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = "0.wav";
                    player.Load();
                    player.Play();
                    t.Stop();
                    label17.Text = "开始";
                    isStart = false;
                }
            });
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowSet(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImage = Image.FromFile("bg.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.BackColor = System.Drawing.Color.FromArgb(255, 199, 10, 38);
            label16.Enabled = true;

            //Hide();

            panel3.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
        }

        /*
        public static void Hide()
        {
            ShowWindow(FindWindow("Shell_TrayWnd", null), SW_HIDE);
        }

        public static void Show()
        {
            ShowWindow(FindWindow("Shell_TrayWnd", null), SW_RESTORE);
        }
        */
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void SetAll()
        {
            panel3.Show();
            label7.Show();
            label8.Show();
            label9.Show();
            if (fenzh == 60)
            {
                MinuteNum = 60;
                SecondNum = 0;
            }
            if (fenzh == 10)
            {
                MinuteNum = 10;
                SecondNum = 0;
            }
            if (fenzh == 5)
            {
                MinuteNum = 5;
                SecondNum = 0;
            }
            if (fenzh == 3)
            {
                MinuteNum = 3;
                SecondNum = 0;
            }
            if (fenzh == 2)
            {
                MinuteNum = 2;
                SecondNum = 0;
            }
            if (fenzh == 1)
            {
                MinuteNum = 1;
                SecondNum = 0;
            }

            second = MinuteNum * 60;

            string MinuteS = MinuteNum.ToString();
            if (MinuteS.Length == 1)
            {
                MinuteS = "0" + MinuteS;
            }
            if (second > 0)
            {
                label7.Text = MinuteS;
                label9.Text = "00";
                tempSecond = 0;
                label17.Text = "开始";
                label16.Enabled = true;
                t.Stop();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            label16.Show();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void StartD(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (second > 0)
            {
                if (isStart)
                {
                    isStart = false;
                    label17.Text = "开始";
                    t.Stop();
                }
                else
                {
                    label16.Enabled = false;
                    isStart = true;
                    label17.Text = "暂停";
                    if (isFirst)
                    {
                        isFirst = false;
                        t.Elapsed += new System.Timers.ElapsedEventHandler(DJS); //到达时间的时候执行事件；   
                        t.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   
                    }
                    t.Start();
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click_1(object sender, EventArgs e)
        {
            Show();
            System.Environment.Exit(0); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fenzh = 1;
            SetAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fenzh = 2;
            SetAll();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fenzh = 3;
            SetAll();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fenzh = 5;
            SetAll();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fenzh = 10;
            SetAll();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            fenzh = 60;
            SetAll();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label10.Hide();
            label11.Hide();
            label15.Hide();
            label13.Hide();
            label14.Hide();

            if (second > 0)
            {
                if (isStart)
                {
                    isStart = false;
                    label17.Text = "开始";
                    t.Stop();
                }
                else
                {
                    isStart = true;
                    label17.Text = "暂停";
                    if (isFirst)
                    {
                        isFirst = false;
                        t.Elapsed += new System.Timers.ElapsedEventHandler(DJS); //到达时间的时候执行事件；   
                        t.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   
                    }
                    t.Start();
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            label10.Show();
            label11.Show();
            label15.Show();
            label13.Show();
            label14.Show();
            panel3.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label7.Text = "00";
            label9.Text = "00";
            tempSecond = 0;
            label17.Text = "开始";
            t.Stop();
        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            fenzh = 2;
            SetAll();
        }

        private void label11_Click_1(object sender, EventArgs e)
        {
            fenzh = 3;
            SetAll();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            fenzh = 5;
            SetAll();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            fenzh = 10;
            SetAll();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            fenzh = 60;
            SetAll();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            label10.Show();
            label11.Show();
            label15.Show();
            label13.Show();
            label14.Show();
            panel3.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label7.Text = "00";
            label9.Text = "00";
            tempSecond = 0;
            label17.Text = "开始";
            t.Stop();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            label10.Hide();
            label11.Hide();
            label15.Hide();
            label13.Hide();
            label14.Hide();

            if (second > 0)
            {
                if (isStart)
                {
                    isStart = false;
                    label17.Text = "开始";
                    t.Stop();
                }
                else
                {
                    isStart = true;
                    label17.Text = "暂停";
                    if (isFirst)
                    {
                        isFirst = false;
                        t.Elapsed += new System.Timers.ElapsedEventHandler(DJS); //到达时间的时候执行事件；   
                        t.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   
                    }
                    t.Start();
                }
            }
        }
    }
}
