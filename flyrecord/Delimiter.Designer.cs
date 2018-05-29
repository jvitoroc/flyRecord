namespace flyrecord
{
    partial class Delimiter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.topLeftResizer = new System.Windows.Forms.Button();
            this.bottomRightResizer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(5, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 260);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // topLeftResizer
            // 
            this.topLeftResizer.BackColor = System.Drawing.Color.Black;
            this.topLeftResizer.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.topLeftResizer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.topLeftResizer.FlatAppearance.BorderSize = 0;
            this.topLeftResizer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.topLeftResizer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.topLeftResizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.topLeftResizer.Location = new System.Drawing.Point(0, 0);
            this.topLeftResizer.Name = "topLeftResizer";
            this.topLeftResizer.Size = new System.Drawing.Size(5, 5);
            this.topLeftResizer.TabIndex = 1;
            this.topLeftResizer.UseVisualStyleBackColor = false;
            this.topLeftResizer.Click += new System.EventHandler(this.topLeftResizer_Click);
            this.topLeftResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topLeftResizer_MouseDown);
            this.topLeftResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topLeftResizer_MouseMove);
            this.topLeftResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topLeftResizer_MouseUp);
            // 
            // bottomRightResizer
            // 
            this.bottomRightResizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomRightResizer.BackColor = System.Drawing.Color.Black;
            this.bottomRightResizer.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.bottomRightResizer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bottomRightResizer.FlatAppearance.BorderSize = 0;
            this.bottomRightResizer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.bottomRightResizer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.bottomRightResizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bottomRightResizer.Location = new System.Drawing.Point(295, 295);
            this.bottomRightResizer.Name = "bottomRightResizer";
            this.bottomRightResizer.Size = new System.Drawing.Size(5, 5);
            this.bottomRightResizer.TabIndex = 1;
            this.bottomRightResizer.UseVisualStyleBackColor = false;
            this.bottomRightResizer.Click += new System.EventHandler(this.bottomRightResizer_Click);
            this.bottomRightResizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.bottomRightResizer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            this.bottomRightResizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(115, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Delimiter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bottomRightResizer);
            this.Controls.Add(this.topLeftResizer);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Delimiter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delimiter";
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.Load += new System.EventHandler(this.Delimiter_Load);
            this.Click += new System.EventHandler(this.Delimiter_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Delimiter_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Delimiter_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Delimiter_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button topLeftResizer;
        private System.Windows.Forms.Button bottomRightResizer;
        private System.Windows.Forms.Button button1;
    }
}