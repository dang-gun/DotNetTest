namespace WinApiOutFocusTest
{
    partial class frmMian
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnImageClear = new System.Windows.Forms.Button();
			this.labMouseKeyShow = new System.Windows.Forms.Label();
			this.checkMouseEventEnable = new System.Windows.Forms.CheckBox();
			this.btnOpenOutFocus = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.listLog = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.labMove = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnImageClear);
			this.panel1.Controls.Add(this.labMouseKeyShow);
			this.panel1.Controls.Add(this.checkMouseEventEnable);
			this.panel1.Controls.Add(this.btnOpenOutFocus);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(527, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(163, 581);
			this.panel1.TabIndex = 0;
			// 
			// btnImageClear
			// 
			this.btnImageClear.Location = new System.Drawing.Point(3, 51);
			this.btnImageClear.Name = "btnImageClear";
			this.btnImageClear.Size = new System.Drawing.Size(157, 23);
			this.btnImageClear.TabIndex = 4;
			this.btnImageClear.Text = "Image Clear";
			this.btnImageClear.UseVisualStyleBackColor = true;
			this.btnImageClear.Click += new System.EventHandler(this.btnImageClear_Click);
			// 
			// labMouseKeyShow
			// 
			this.labMouseKeyShow.Location = new System.Drawing.Point(3, 25);
			this.labMouseKeyShow.Name = "labMouseKeyShow";
			this.labMouseKeyShow.Size = new System.Drawing.Size(157, 23);
			this.labMouseKeyShow.TabIndex = 3;
			this.labMouseKeyShow.Text = "label1";
			this.labMouseKeyShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkMouseEventEnable
			// 
			this.checkMouseEventEnable.AutoSize = true;
			this.checkMouseEventEnable.Checked = true;
			this.checkMouseEventEnable.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkMouseEventEnable.Location = new System.Drawing.Point(3, 3);
			this.checkMouseEventEnable.Name = "checkMouseEventEnable";
			this.checkMouseEventEnable.Size = new System.Drawing.Size(134, 19);
			this.checkMouseEventEnable.TabIndex = 2;
			this.checkMouseEventEnable.Text = "Mouse Event Enable";
			this.checkMouseEventEnable.UseVisualStyleBackColor = true;
			this.checkMouseEventEnable.CheckedChanged += new System.EventHandler(this.checkMouseEventEnable_CheckedChanged);
			// 
			// btnOpenOutFocus
			// 
			this.btnOpenOutFocus.Location = new System.Drawing.Point(3, 146);
			this.btnOpenOutFocus.Name = "btnOpenOutFocus";
			this.btnOpenOutFocus.Size = new System.Drawing.Size(157, 23);
			this.btnOpenOutFocus.TabIndex = 1;
			this.btnOpenOutFocus.Text = "Open out focus";
			this.btnOpenOutFocus.UseVisualStyleBackColor = true;
			this.btnOpenOutFocus.Click += new System.EventHandler(this.btnOpenOutFocus_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 236);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// listLog
			// 
			this.listLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listLog.GridLines = true;
			this.listLog.Location = new System.Drawing.Point(2, 366);
			this.listLog.MultiSelect = false;
			this.listLog.Name = "listLog";
			this.listLog.Size = new System.Drawing.Size(519, 212);
			this.listLog.TabIndex = 1;
			this.listLog.UseCompatibleStateImageBehavior = false;
			this.listLog.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "time";
			this.columnHeader1.Width = 100;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Log";
			this.columnHeader2.Width = 390;
			// 
			// labMove
			// 
			this.labMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.labMove.Location = new System.Drawing.Point(2, 0);
			this.labMove.Name = "labMove";
			this.labMove.Size = new System.Drawing.Size(519, 363);
			this.labMove.TabIndex = 3;
			this.labMove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
			this.labMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
			this.labMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
			// 
			// frmMian
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 581);
			this.Controls.Add(this.labMove);
			this.Controls.Add(this.listLog);
			this.Controls.Add(this.panel1);
			this.Name = "frmMian";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.frmMian_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button button1;
        private ListView listLog;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button btnOpenOutFocus;
        private CheckBox checkMouseEventEnable;
        private Label labMouseKeyShow;
        private Label labMove;
		private Button btnImageClear;
	}
}