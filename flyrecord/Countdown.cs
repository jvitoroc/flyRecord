using System;
using System.Windows.Forms;

namespace flyrecord
{
    public partial class Countdown : Form
    {

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private int currentSec = 3;

        public delegate void OnTimeoutEventHandler();
        public static OnTimeoutEventHandler OnTimeout;

        public Countdown()
        {
            InitializeComponent();
            this.TopMost = true;
            if (Settings.Instance.EntireScreen)
            {
                this.Location = new System.Drawing.Point(0, 0);
                this.Size = new System.Drawing.Size(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            }
            else
            {
                this.Location = Delimiter.Instance.getInnerDelimiterUpperLeftLocation();
                this.Size = Delimiter.Instance.getInnerDelimiterSize();
            }
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += tickCountdownHandler;
        }

        private void Countdown_Load(object sender, EventArgs e)
        {
            tickCountdown();
            Start();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
            timer.Dispose();
        }

        private void updateCountdown(int number)
        {
            switch (number)
            {
                case 1:
                    picCountdown.Image = Properties.Resources.number1;
                    break;
                case 2:
                    picCountdown.Image = Properties.Resources.number2;
                    break;
                case 3:
                    picCountdown.Image = Properties.Resources.number3;
                    break;
            }
        }

        private void tickCountdownHandler(object sender, System.EventArgs e)
        {
            tickCountdown();
        }

        private void tickCountdown()
        {
            if (currentSec == 0)
            {
                timer.Dispose();
                this.Close();
                OnTimeout?.Invoke();
                
            }
            else
            {
                updateCountdown(currentSec);
                currentSec -= 1;
            }
        }

        private void picCountdown_Click(object sender, EventArgs e)
        {

        }
    }
}
