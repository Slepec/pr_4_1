using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace pr_4_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 5000;

        }
        byte status = 0;
        Graphics g;
         Timer myTimer = new Timer();
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = CreateGraphics();
            
            g.FillEllipse(new SolidBrush(Color.FromArgb(255,69,8,8)),50,50,70,70);
            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 110, 77, 1)), 50, 125, 70, 70);
            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 11, 69, 1)), 50, 200, 70, 70);
            g.DrawRectangle(new Pen(Color.Black,3),new Rectangle(40,40,90,240));
            
            
        }
        private  void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            Console.WriteLine("Tick. status="+status);
           if(status == 0)
            {
                g.FillEllipse(new SolidBrush(Color.Red), 50, 50, 70, 70);
                g.FillEllipse(new SolidBrush(Color.FromArgb(255, 11, 69, 1)), 50, 200, 70, 70);
                status = 1;
                label1.Text = "Стійте!";
            }
           else if (status==1)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(255, 69, 8, 8)), 50, 50, 70, 70);
                g.FillEllipse(new SolidBrush(Color.Yellow), 50, 125, 70, 70);
                status = 2;
                
            }
           else if (status == 2)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(255, 110, 77, 1)), 50, 125, 70, 70);
                g.FillEllipse(new SolidBrush(Color.Green), 50, 200, 70, 70);
                status = 0;
                label1.Text = "Йдіть";
            }

        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            myTimer.Start();
            button1.Visible = false;
        }
    }
}
