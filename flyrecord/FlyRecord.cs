using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace flyrecord
{

    public enum FlyRecordStatus
    {
        Idle,
        Moving
    }

    public partial class FlyRecord : Form
    {
        private GlobalKeyboardHook globalKeyboardHook;
        private FlyRecordStatus FlyRecordStatus = FlyRecordStatus.Idle;
        private Delimiter delimiter;
        private Point startingMousePositionFormRelative;

        public FlyRecord()
        {
            InitializeComponent();

        }

        public void setControlSettings(string outputPath, bool entireScreen, bool followCursor, int delimiterWidth,
            int delimiterHeight, VideoFileFormat videoFileFormat = VideoFileFormat.None)
        {
            comboFileFormat.SelectedIndex = (int)videoFileFormat;
            txtOutputPath.Text = outputPath;
            txtDelimiterHeight.Text = delimiterHeight.ToString();
            txtDelimiterWidth.Text = delimiterWidth.ToString();
            cboxFollowCursor.Checked = followCursor;
            cboxRecordEntireScreen.Checked = entireScreen;
            enabledDelimiterSettings(!entireScreen);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            globalKeyboardHook = new GlobalKeyboardHook();
            globalKeyboardHook.KeyboardPressed += KeyPressed;
        }

        private void KeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (e.KeyboardData.VirtualCode != GlobalKeyboardHook.VkSnapshot)
                return;

            // seems, not needed in the life.
            //if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.SysKeyDown &&
            //    e.KeyboardData.Flags == GlobalKeyboardHook.LlkhfAltdown)
            //{
            //    MessageBox.Show("Alt + Print Screen");
            //    e.Handled = true;
            //}
            //else

            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                MessageBox.Show("Print Screen");
                e.Handled = true;
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            Size recordSize;
            if (Settings.Instance.EntireScreen)
                recordSize = new Size(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            else{
                if (Application.OpenForms.OfType<Delimiter>().Count() == 0)
                    throw new NullReferenceException();
                recordSize = delimiter.Size;
                delimiter.TopMost = true;
            }
                
            Recorder.Instance.start(VideoFileFormat.GIF, 60, "./ola.gif", recordSize);
            btnStopRecording.Enabled = true;
            btnRecord.Enabled = false;

        }

        private void cboxRecordEntireScreen_CheckedChanged(object sender, EventArgs e)
        {
            enabledDelimiterSettings(!cboxRecordEntireScreen.Checked);
            Settings.Instance.EntireScreen = cboxRecordEntireScreen.Checked;
            if (!cboxRecordEntireScreen.Checked)
            {
                delimiter = new Delimiter();
                delimiter.Show();
            }
            else
            {
                if (delimiter != null)
                {
                    delimiter.Close();
                    delimiter.Dispose();
                    delimiter = null;
                }     
            }
        }

        private void enabledDelimiterSettings(bool enabled)
        {
            panelDelimiterSettings.Enabled = enabled;
        }

        private bool enabledDelimiterSettings()
        {
            return panelDelimiterSettings.Enabled;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            globalKeyboardHook?.Dispose();
            if (Recorder.Instance.Recording())
                Recorder.Instance.stop();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(Program.SETTINGS_FILE_PATH, FileMode.Open);
            formatter.Serialize(fs, Settings.Instance);
            fs.Dispose();
            fs.Close();
        }

        private void comboFileFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Instance.VideoFileFormat = (VideoFileFormat)comboFileFormat.SelectedIndex;
        }

        private void txtOutputPath_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.OutputPath = txtOutputPath.Text;
        }

        private void cboxFollowCursor_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.FollowCursor = cboxFollowCursor.Checked;
        }

        private void txtDelimiterWidth_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.DelimiterWidth = int.Parse(txtDelimiterWidth.Text);
        }

        private void txtDelimiterHeight_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.DelimiterWidth = int.Parse(txtDelimiterHeight.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recorder.Instance.stop();
            if(delimiter != null)
                delimiter.TopMost = false;
            btnStopRecording.Enabled = false;
            btnRecord.Enabled = true;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FlyRecordStatus = FlyRecordStatus.Moving;
            }
            startingMousePositionFormRelative.X = e.X;
            startingMousePositionFormRelative.Y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (FlyRecordStatus == FlyRecordStatus.Moving)
            {
                int newLocationX = Cursor.Position.X - startingMousePositionFormRelative.X;
                int newLocationY = Cursor.Position.Y - startingMousePositionFormRelative.Y;

                this.Location = new Point(newLocationX, newLocationY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            FlyRecordStatus = FlyRecordStatus.Idle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
