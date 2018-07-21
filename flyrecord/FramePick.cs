﻿using System;
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

        public FramePick()
        {
            InitializeComponent();

            Recorder.OnRecordStart += OnRecordStartEventHandler;
            Recorder.OnRecordStopComplete += OnRecordStopCompleteEventHandler;
            Recorder.OnPreparing += OnPreparingEventHandler;
            Properties.Settings.Default.SettingChanging += OnSettingsChangeEventHandler;
            Properties.Settings.Default.SettingsLoaded += OnSettingsLoadedEventHandler;

            txtOutputPath.Text = Properties.Settings.Default.outputPath;
            ddlFPS.SelectedIndex = Properties.Settings.Default.frameRateIndex;
            cboxEntireScreen.Checked = Properties.Settings.Default.entireScreen;
            cboxFollowCursor.Checked = Properties.Settings.Default.followCursor;
        }

        private void OnSettingsLoadedEventHandler(object sender, SettingsLoadedEventArgs e)
        {
            enableDelimiter(!Properties.Settings.Default.entireScreen);
        }

        private void OnSettingsChangeEventHandler(object sender, SettingChangingEventArgs e)
        {
            switch (e.SettingName)
            {
                case "outputPath":
                    txtOutputPath.Text = e.NewValue.ToString();
                    break;

                case "frameRateIndex":
                    ddlFPS.SelectedIndex = (int)e.NewValue;
                    break;

                case "entireScreen":
                    cboxEntireScreen.Checked = (bool)e.NewValue;
                    enableDelimiter(!cboxEntireScreen.Checked);
                    break;

                case "followCursor":
                    cboxFollowCursor.Checked = (bool)e.NewValue;
                    break;
            }
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
            enableDelimiter(Properties.Settings.Default.entireScreen);
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
            Properties.Settings.Default.Save();
        }

        private void txtOutputPath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.outputPath = txtOutputPath.Text;
        }

        private void cboxFollowCursor_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.followCursor = cboxFollowCursor.Checked;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (Recorder.Instance.Status == RecorderStatus.Recording || Recorder.Instance.Status == RecorderStatus.Preparing)
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
                Properties.Settings.Default.outputPath = folderBrowserDialogOutputPath.SelectedPath;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.frameRate = float.Parse(ddlFPS.Text);
            Properties.Settings.Default.frameRateIndex = ddlFPS.SelectedIndex;
        }
    }
}