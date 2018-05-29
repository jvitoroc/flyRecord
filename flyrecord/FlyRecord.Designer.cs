namespace flyrecord
{
    partial class FlyRecord
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRecord = new System.Windows.Forms.Button();
            this.comboFileFormat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnBrowseOutputPath = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelDelimiterSettings = new System.Windows.Forms.Panel();
            this.cboxFollowCursor = new System.Windows.Forms.CheckBox();
            this.txtDelimiterHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDelimiterWidth = new System.Windows.Forms.TextBox();
            this.cboxRecordEntireScreen = new System.Windows.Forms.CheckBox();
            this.btnStopRecording = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelDelimiterSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(262, 254);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(75, 23);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // comboFileFormat
            // 
            this.comboFileFormat.FormattingEnabled = true;
            this.comboFileFormat.Items.AddRange(new object[] {
            "GIF"});
            this.comboFileFormat.Location = new System.Drawing.Point(67, 57);
            this.comboFileFormat.Name = "comboFileFormat";
            this.comboFileFormat.Size = new System.Drawing.Size(121, 21);
            this.comboFileFormat.TabIndex = 1;
            this.comboFileFormat.SelectedIndexChanged += new System.EventHandler(this.comboFileFormat_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File format";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Path";
            // 
            // btnBrowseOutputPath
            // 
            this.btnBrowseOutputPath.Location = new System.Drawing.Point(244, 29);
            this.btnBrowseOutputPath.Name = "btnBrowseOutputPath";
            this.btnBrowseOutputPath.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseOutputPath.TabIndex = 4;
            this.btnBrowseOutputPath.Text = "Browse";
            this.btnBrowseOutputPath.UseVisualStyleBackColor = true;
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(67, 31);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(171, 20);
            this.txtOutputPath.TabIndex = 4;
            this.txtOutputPath.TextChanged += new System.EventHandler(this.txtOutputPath_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOutputPath);
            this.groupBox1.Controls.Add(this.comboFileFormat);
            this.groupBox1.Controls.Add(this.btnBrowseOutputPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 97);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelDelimiterSettings);
            this.groupBox2.Controls.Add(this.cboxRecordEntireScreen);
            this.groupBox2.Location = new System.Drawing.Point(12, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 119);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recording settings";
            // 
            // panelDelimiterSettings
            // 
            this.panelDelimiterSettings.Controls.Add(this.cboxFollowCursor);
            this.panelDelimiterSettings.Controls.Add(this.txtDelimiterHeight);
            this.panelDelimiterSettings.Controls.Add(this.label3);
            this.panelDelimiterSettings.Controls.Add(this.label4);
            this.panelDelimiterSettings.Controls.Add(this.txtDelimiterWidth);
            this.panelDelimiterSettings.Location = new System.Drawing.Point(9, 52);
            this.panelDelimiterSettings.Name = "panelDelimiterSettings";
            this.panelDelimiterSettings.Size = new System.Drawing.Size(316, 54);
            this.panelDelimiterSettings.TabIndex = 7;
            // 
            // cboxFollowCursor
            // 
            this.cboxFollowCursor.AutoSize = true;
            this.cboxFollowCursor.Location = new System.Drawing.Point(0, -1);
            this.cboxFollowCursor.Name = "cboxFollowCursor";
            this.cboxFollowCursor.Size = new System.Drawing.Size(127, 17);
            this.cboxFollowCursor.TabIndex = 1;
            this.cboxFollowCursor.Text = "Follow cursor position";
            this.cboxFollowCursor.UseVisualStyleBackColor = true;
            this.cboxFollowCursor.CheckedChanged += new System.EventHandler(this.cboxFollowCursor_CheckedChanged);
            // 
            // txtDelimiterHeight
            // 
            this.txtDelimiterHeight.Location = new System.Drawing.Point(235, 28);
            this.txtDelimiterHeight.Name = "txtDelimiterHeight";
            this.txtDelimiterHeight.Size = new System.Drawing.Size(64, 20);
            this.txtDelimiterHeight.TabIndex = 6;
            this.txtDelimiterHeight.TextChanged += new System.EventHandler(this.txtDelimiterHeight_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Demiliter width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Demiliter height";
            // 
            // txtDelimiterWidth
            // 
            this.txtDelimiterWidth.Location = new System.Drawing.Point(79, 28);
            this.txtDelimiterWidth.Name = "txtDelimiterWidth";
            this.txtDelimiterWidth.Size = new System.Drawing.Size(64, 20);
            this.txtDelimiterWidth.TabIndex = 4;
            this.txtDelimiterWidth.TextChanged += new System.EventHandler(this.txtDelimiterWidth_TextChanged);
            // 
            // cboxRecordEntireScreen
            // 
            this.cboxRecordEntireScreen.AutoSize = true;
            this.cboxRecordEntireScreen.Checked = true;
            this.cboxRecordEntireScreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxRecordEntireScreen.Location = new System.Drawing.Point(9, 29);
            this.cboxRecordEntireScreen.Name = "cboxRecordEntireScreen";
            this.cboxRecordEntireScreen.Size = new System.Drawing.Size(143, 17);
            this.cboxRecordEntireScreen.TabIndex = 0;
            this.cboxRecordEntireScreen.Text = "Record the entire screen";
            this.cboxRecordEntireScreen.UseVisualStyleBackColor = true;
            this.cboxRecordEntireScreen.CheckedChanged += new System.EventHandler(this.cboxRecordEntireScreen_CheckedChanged);
            // 
            // btnStopRecording
            // 
            this.btnStopRecording.Enabled = false;
            this.btnStopRecording.Location = new System.Drawing.Point(181, 254);
            this.btnStopRecording.Name = "btnStopRecording";
            this.btnStopRecording.Size = new System.Drawing.Size(75, 23);
            this.btnStopRecording.TabIndex = 8;
            this.btnStopRecording.Text = "Stop";
            this.btnStopRecording.UseVisualStyleBackColor = true;
            this.btnStopRecording.Click += new System.EventHandler(this.button1_Click);
            // 
            // FlyRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 289);
            this.Controls.Add(this.btnStopRecording);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FlyRecord";
            this.Text = "FlyRecord";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelDelimiterSettings.ResumeLayout(false);
            this.panelDelimiterSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.ComboBox comboFileFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnBrowseOutputPath;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cboxFollowCursor;
        private System.Windows.Forms.CheckBox cboxRecordEntireScreen;
        private System.Windows.Forms.TextBox txtDelimiterHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDelimiterWidth;
        private System.Windows.Forms.Panel panelDelimiterSettings;
        private System.Windows.Forms.Button btnStopRecording;
    }
}

