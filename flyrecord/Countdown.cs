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
                txtCountdown.Text = currentSec.ToString();
                currentSec -= 1;
            }
        }
    }
}
