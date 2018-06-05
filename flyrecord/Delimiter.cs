using System;
using System.Drawing;
using System.Windows.Forms;

namespace flyrecord
{

    public enum DelimiterStatus
    {
        Idle,
        Resizing,
        Moving
    }

    public partial class Delimiter : Form
    {

        private DelimiterStatus DelimiterStatus = DelimiterStatus.Idle;
        private Point startingMousePositionFormRelative;
        private Point startingBottomLeftPosition;

        private delegate void ButtonFunctionEventHandler();
        private ButtonFunctionEventHandler ButtonFunction;

        private static Delimiter instance = null;
        private static readonly object padlock = new object();

        private bool locked = false;

        private Size minimumDelimiterSize = new Size(100, 45);

        private Point previousMousePosition;

        public static Delimiter Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Delimiter();
                    }
                    return instance;
                }
            }
        }

        public Delimiter()
        {
            InitializeComponent();
      
            this.Size = new Size(300, 300);
            pnlInner.Location = new Point(5, 35);
            pnlInner.Size = new Size(290, 260);

            changeButtonState(Recorder.Instance.Recording);
            Recorder.OnRecordStart += OnRecordStartEventHandler;
            Recorder.OnRecordStopComplete += OnRecordStopCompleteEventHandler;
        }

        public static void Enable()
        {
            if(Application.OpenForms["Delimiter"] == null)
                Delimiter.Instance.Show();
        }

        public static void Disable()
        {
            if (Application.OpenForms["Delimiter"] != null)
                Delimiter.Instance.Close();
        }

        private void changeButtonState(bool recording)
        {
            if (recording)
            {
                btnStartOrRecord.BackColor = Color.DarkRed;
                btnStartOrRecord.Text = "STOP";
                ButtonFunction = new ButtonFunctionEventHandler(onStopRecordingButtonHandler);
            }
            else
            {
                btnStartOrRecord.BackColor = Color.DarkGreen;
                btnStartOrRecord.Text = "START";
                ButtonFunction = new ButtonFunctionEventHandler(onStartRecordingButtonHandler);
            }
        }

        private void onStartRecordingButtonHandler()
        {
            if (Recorder.Instance.Recording)
                throw new InvalidOperationException();
            Recorder.Instance.Start();
        }

        private void onStopRecordingButtonHandler()
        {
            if (!Recorder.Instance.Recording)
                throw new InvalidOperationException();
            Recorder.Instance.Stop();
        }

        private void OnRecordStopCompleteEventHandler()
        {
            changeButtonState(false);
        }

        private void OnRecordStartEventHandler()
        {
            changeButtonState(true);
        }

        public void Lock()
        {
            locked = true;
        }

        public void Unlock()
        {
            locked = false;
        }

        public Point getInnerDelimiterUpperLeftLocation()
        {
            return new Point(Location.X + 5, Location.Y + 35);
        }

        public Size getInnerDelimiterSize()
        {
            return pnlInner.Size;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (locked)
                return;
            if(e.Button == MouseButtons.Right)
            {
                DelimiterStatus = DelimiterStatus.Moving;
            }
            else
            {
                DelimiterStatus = DelimiterStatus.Resizing;
                
            }
            startingMousePositionFormRelative.X = 5 - e.X;
            startingMousePositionFormRelative.Y = 5 - e.Y;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (locked)
                return;
            if (DelimiterStatus == DelimiterStatus.Resizing)
            {
                
                int width = (Cursor.Position.X - DesktopLocation.X) + startingMousePositionFormRelative.X;
                int height = (Cursor.Position.Y - DesktopLocation.Y) + startingMousePositionFormRelative.Y;

                Size newSize = new Size(width, height);
                if (newSize.Width <= minimumDelimiterSize.Width)
                    newSize.Width = minimumDelimiterSize.Width;
                if(newSize.Height <= minimumDelimiterSize.Height)
                    newSize.Height = minimumDelimiterSize.Height;
                this.Size = newSize;

            }else if (DelimiterStatus == DelimiterStatus.Moving)
            {
                int newLocationX = Cursor.Position.X - this.Size.Width + startingMousePositionFormRelative.X;
                int newLocationY = Cursor.Position.Y - this.Size.Height + startingMousePositionFormRelative.Y;

                this.Location = new Point(newLocationX, newLocationY);

            }
            
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            DelimiterStatus = DelimiterStatus.Idle;
        }

        private void topLeftResizer_MouseDown(object sender, MouseEventArgs e)
        {
            if (locked)
                return;
            if (e.Button == MouseButtons.Right)
            {
                DelimiterStatus = DelimiterStatus.Moving;
            }
            else
            {
                DelimiterStatus = DelimiterStatus.Resizing;

            }
            startingBottomLeftPosition.X = this.Size.Width + DesktopLocation.X;
            startingBottomLeftPosition.Y = this.Size.Height + DesktopLocation.Y;
            startingMousePositionFormRelative.X = e.X;
            startingMousePositionFormRelative.Y = e.Y;
        }

        private void topLeftResizer_MouseMove(object sender, MouseEventArgs e)
        {
            if (locked)
                return;
            if (DelimiterStatus == DelimiterStatus.Resizing)
            {

                int newLocationX = Cursor.Position.X - startingMousePositionFormRelative.X;
                int newLocationY = Cursor.Position.Y - startingMousePositionFormRelative.Y;

                int newSizeWidth = startingBottomLeftPosition.X - newLocationX;
                int newSizeHeight = startingBottomLeftPosition.Y - newLocationY;

                Size newSize = new Size(newSizeWidth, newSizeHeight);
                Point newLocation = new Point(newLocationX, newLocationY);

                if (newSize.Width <= minimumDelimiterSize.Width)
                {
                    newSize.Width = minimumDelimiterSize.Width;
                    newLocation.X = previousMousePosition.X;
                }
                if (newSize.Height <= minimumDelimiterSize.Height) {
                    newSize.Height = minimumDelimiterSize.Height;
                    newLocation.Y = previousMousePosition.Y;
                }

                this.Size = newSize;
                this.Location = newLocation;
                previousMousePosition = newLocation;
            }


            else if (DelimiterStatus == DelimiterStatus.Moving)
            {
                int newLocationX = Cursor.Position.X - this.Size.Width + startingMousePositionFormRelative.X;
                int newLocationY = Cursor.Position.Y - this.Size.Height + startingMousePositionFormRelative.Y;

                this.Location = new Point(newLocationX, newLocationY);

            }
        }

        private void topLeftResizer_MouseUp(object sender, MouseEventArgs e)
        {
            DelimiterStatus = DelimiterStatus.Idle;
        }

        private void Delimiter_MouseDown(object sender, MouseEventArgs e)
        {
            if (locked)
                return;
            if (e.Button == MouseButtons.Left)
            {
                DelimiterStatus = DelimiterStatus.Moving;
            }
            startingMousePositionFormRelative.X = e.X;
            startingMousePositionFormRelative.Y = e.Y;
        }

        private void Delimiter_MouseMove(object sender, MouseEventArgs e)
        {
            if (locked)
                return;
            if (DelimiterStatus == DelimiterStatus.Moving) {
                int newLocationX = Cursor.Position.X - startingMousePositionFormRelative.X;
                int newLocationY = Cursor.Position.Y - startingMousePositionFormRelative.Y;

                this.Location = new Point(newLocationX, newLocationY);
            }
        }

        private void Delimiter_MouseUp(object sender, MouseEventArgs e)
        {
            if (locked)
                return;
            DelimiterStatus = DelimiterStatus.Idle;
        }

        private void Delimiter_Load(object sender, EventArgs e)
        {

        }

        private void btnStartOrRecord_Click(object sender, EventArgs e)
        {
            ButtonFunction();
        }
    }
}
