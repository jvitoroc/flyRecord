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
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelDelimiterSettings = new System.Windows.Forms.Panel();
            this.txtDelimiterHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxFollowCursor = new System.Windows.Forms.CheckBox();
            this.txtDelimiterWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxRecordEntireScreen = new System.Windows.Forms.CheckBox();
            this.btnStopRecording = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelDelimiterSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRecord.FlatAppearance.BorderSize = 0;
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecord.ForeColor = System.Drawing.Color.White;
            this.btnRecord.Location = new System.Drawing.Point(271, 303);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(70, 25);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.Text = "RECORD";
            this.btnRecord.UseVisualStyleBackColor = false;
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
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File format";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Path";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutputPath.Location = new System.Drawing.Point(67, 31);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(162, 20);
            this.txtOutputPath.TabIndex = 4;
            this.txtOutputPath.TextChanged += new System.EventHandler(this.txtOutputPath_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOutputPath);
            this.groupBox1.Controls.Add(this.comboFileFormat);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(16, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 97);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output settings";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Roboto", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(235, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "BROWSE";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelDelimiterSettings);
            this.groupBox2.Controls.Add(this.cboxRecordEntireScreen);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(16, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 119);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recording settings";
            // 
            // panelDelimiterSettings
            // 
            this.panelDelimiterSettings.Controls.Add(this.txtDelimiterHeight);
            this.panelDelimiterSettings.Controls.Add(this.label3);
            this.panelDelimiterSettings.Controls.Add(this.cboxFollowCursor);
            this.panelDelimiterSettings.Controls.Add(this.txtDelimiterWidth);
            this.panelDelimiterSettings.Controls.Add(this.label4);
            this.panelDelimiterSettings.Location = new System.Drawing.Point(9, 52);
            this.panelDelimiterSettings.Name = "panelDelimiterSettings";
            this.panelDelimiterSettings.Size = new System.Drawing.Size(310, 54);
            this.panelDelimiterSettings.TabIndex = 7;
            // 
            // txtDelimiterHeight
            // 
            this.txtDelimiterHeight.Location = new System.Drawing.Point(79, 28);
            this.txtDelimiterHeight.Name = "txtDelimiterHeight";
            this.txtDelimiterHeight.Size = new System.Drawing.Size(64, 20);
            this.txtDelimiterHeight.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Demiliter height";
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
            // txtDelimiterWidth
            // 
            this.txtDelimiterWidth.Location = new System.Drawing.Point(235, 28);
            this.txtDelimiterWidth.Name = "txtDelimiterWidth";
            this.txtDelimiterWidth.Size = new System.Drawing.Size(64, 20);
            this.txtDelimiterWidth.TabIndex = 6;
            this.txtDelimiterWidth.TextChanged += new System.EventHandler(this.txtDelimiterHeight_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Demiliter width";
            this.label4.Click += new System.EventHandler(this.label4_Click);
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
            this.btnStopRecording.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnStopRecording.Enabled = false;
            this.btnStopRecording.FlatAppearance.BorderSize = 0;
            this.btnStopRecording.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopRecording.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopRecording.ForeColor = System.Drawing.Color.White;
            this.btnStopRecording.Location = new System.Drawing.Point(195, 303);
            this.btnStopRecording.Name = "btnStopRecording";
            this.btnStopRecording.Size = new System.Drawing.Size(70, 25);
            this.btnStopRecording.TabIndex = 8;
            this.btnStopRecording.Text = "STOP";
            this.btnStopRecording.UseVisualStyleBackColor = false;
            this.btnStopRecording.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "FlyRecord";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 37);
            this.panel1.TabIndex = 10;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SteelBlue;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(312, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 22);
            this.button3.TabIndex = 12;
            this.button3.Text = "_";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(334, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 22);
            this.button2.TabIndex = 11;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FlyRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(356, 340);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.btnStopRecording);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.ComboBox comboFileFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cboxFollowCursor;
        private System.Windows.Forms.CheckBox cboxRecordEntireScreen;
        private System.Windows.Forms.TextBox txtDelimiterWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelDelimiterSettings;
        private System.Windows.Forms.Button btnStopRecording;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtDelimiterHeight;
        private System.Windows.Forms.Label label3;
    }
}

