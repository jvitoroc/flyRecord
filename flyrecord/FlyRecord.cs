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
        private Point startingMousePositionFormRelative;

        public FlyRecord(Settings settings = null)
        {
            InitializeComponent();

            if(settings != null)
            {
                comboFileFormat.SelectedIndex = (int)settings.VideoFileFormat;
                txtOutputPath.Text = settings.OutputPath;
                txtDelimiterHeight.Text = settings.DelimiterHeight.ToString();
                txtDelimiterWidth.Text = settings.DelimiterWidth.ToString();
                cboxFollowCursor.Checked = settings.FollowCursor;
                cboxRecordEntireScreen.Checked = settings.EntireScreen;
                enabledDelimiter(!settings.EntireScreen);
            }
            Recorder.OnRecordStart += OnRecordStartEventHandler;
            Recorder.OnRecordStopComplete += OnRecordStopCompleteEventHandler;
        }

        private void OnRecordStopCompleteEventHandler()
        {
            btnRecord.Enabled = true;
            btnStopRecording.Enabled = false;
        }

        private void OnRecordStartEventHandler()
        {
            btnRecord.Enabled = false;
            btnStopRecording.Enabled = true;
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //globalKeyboardHook = new GlobalKeyboardHook();
            //globalKeyboardHook.KeyboardPressed += KeyPressed;
        }

        //private void KeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        //{
        //    if (e.KeyboardData.VirtualCode != GlobalKeyboardHook.VkSnapshot)
        //        return;

        //    // seems, not needed in the life.
        //    //if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.SysKeyDown &&
        //    //    e.KeyboardData.Flags == GlobalKeyboardHook.LlkhfAltdown)
        //    //{
        //    //    MessageBox.Show("Alt + Print Screen");
        //    //    e.Handled = true;
        //    //}
        //    //else

        //    if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
        //    {
        //        MessageBox.Show("Print Screen");
        //        e.Handled = true;
        //    }
        //}

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (Recorder.Instance.Recording)
                throw new InvalidOperationException();
            Recorder.Instance.Start(VideoFileFormat.GIF, 60, "./ola.gif");
        }

        private void cboxRecordEntireScreen_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.EntireScreen = cboxRecordEntireScreen.Checked;
            enabledDelimiter(!cboxRecordEntireScreen.Checked);
        }

        private void enabledDelimiter(bool enabled)
        {
            panelDelimiterSettings.Enabled = enabled;
            if (enabled)
                Delimiter.Enable();
            else
                Delimiter.Disable();
        }

        private bool enabledDelimiter()
        {
            return panelDelimiterSettings.Enabled;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            globalKeyboardHook?.Dispose();
            if (Recorder.Instance.Recording)
                Recorder.Instance.Stop();
            Settings.Instance.Sync();
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
            Settings.Instance.DelimiterWidth = int.Parse(txtDelimiterWidth.Text);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!Recorder.Instance.Recording)
                throw new InvalidOperationException();
            Recorder.Instance.Stop();
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog();
            if(res == DialogResult.OK)
            {
                txtOutputPath.Text = folderBrowserDialog1.SelectedPath;
            }

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
