using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace flyrecord
{
    public enum FramePickStatus
    {
        Idle,
        Moving
    }

    public partial class FramePick : Form
    {
        private GlobalKeyboardHook globalKeyboardHook;
        private FramePickStatus FramePickStatus = FramePickStatus.Idle;
        private Point startingMousePositionFormRelative;

        public FramePick(Settings settings = null)
        {
            InitializeComponent();

            if(settings != null)
            {
                txtOutputPath.Text = settings.OutputPath;
                cboxFollowCursor.Checked = settings.FollowCursor;
                cboxEntireScreen.Checked = settings.EntireScreen;
                enableDelimiter(!settings.EntireScreen);
                ddlFPS.SelectedIndex = settings.FrameRateIndex;
            }
            Recorder.OnRecordStart += OnRecordStartEventHandler;
            Recorder.OnRecordStopComplete += OnRecordStopCompleteEventHandler;
            Recorder.OnPreparing += OnPreparingEventHandler;
            Properties.Settings.Default.SettingChanging += OnSettingsChangeEventHandler;
        }

        private void OnSettingsChangeEventHandler(object sender, SettingChangingEventArgs e)
        {
            
        }

        private void OnRecordStopCompleteEventHandler()
        {
            btnRecord.Enabled = true;
            btnStop.Enabled = false;
        }

        private void OnPreparingEventHandler()
        {
            btnRecord.Enabled = false;
            btnStop.Enabled = true;
        }

        private void OnRecordStartEventHandler()
        {
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
            if (Recorder.Instance.Status == RecorderStatus.Recording)
                throw new InvalidOperationException();
            Recorder.Instance.Start(Settings.Instance.FrameRate);
        }

        private void cboxRecordEntireScreen_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.EntireScreen = cboxEntireScreen.Checked;
            enableDelimiter(!cboxEntireScreen.Checked);
        }

        private void enableDelimiter(bool enabled)
        {
            cboxFollowCursor.Enabled = enabled;
            if (enabled)
                Delimiter.Enable();
            else
                Delimiter.Disable();
        }

        private void FramePick_FormClosing(object sender, FormClosingEventArgs e)
        {
            globalKeyboardHook?.Dispose();
            if (Recorder.Instance.Status == RecorderStatus.Recording)
                Recorder.Instance.Stop();
            Settings.Instance.Sync(true);
        }

        private void txtOutputPath_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.OutputPath = txtOutputPath.Text;
        }

        private void cboxFollowCursor_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.FollowCursor = cboxFollowCursor.Checked;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (Recorder.Instance.Status == RecorderStatus.Recording)
                Recorder.Instance.Stop();
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FramePickStatus = FramePickStatus.Moving;
            }
            startingMousePositionFormRelative.X = e.X;
            startingMousePositionFormRelative.Y = e.Y;
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (FramePickStatus == FramePickStatus.Moving)
            {
                int newLocationX = Cursor.Position.X - startingMousePositionFormRelative.X;
                int newLocationY = Cursor.Position.Y - startingMousePositionFormRelative.Y;

                this.Location = new Point(newLocationX, newLocationY);
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            FramePickStatus = FramePickStatus.Idle;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialogOutputPath.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtOutputPath.Text = folderBrowserDialogOutputPath.SelectedPath;
                Settings.Instance.OutputPath = folderBrowserDialogOutputPath.SelectedPath;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Instance.FrameRate = float.Parse(ddlFPS.Text);
            Settings.Instance.FrameRateIndex = ddlFPS.SelectedIndex;
        }
    }
}
