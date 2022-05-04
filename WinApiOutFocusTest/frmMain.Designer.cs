namespace WinApiOutFocusTest
{
    partial class frmMain
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
			this.btnDragDeley = new System.Windows.Forms.Button();
			this.btnOutFocus_Drag2 = new System.Windows.Forms.Button();
			this.btnOutFocus_Drag = new System.Windows.Forms.Button();
			this.btnThisDrag = new System.Windows.Forms.Button();
			this.btnImageClear = new System.Windows.Forms.Button();
			this.labMouseKeyShow = new System.Windows.Forms.Label();
			this.checkMouseEventEnable = new System.Windows.Forms.CheckBox();
			this.btnOpenOutFocus = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.listLog = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.pictureDraw = new System.Windows.Forms.PictureBox();
			this.btnOutFocus_Drag3 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureDraw)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnOutFocus_Drag3);
			this.panel1.Controls.Add(this.btnDragDeley);
			this.panel1.Controls.Add(this.btnOutFocus_Drag2);
			this.panel1.Controls.Add(this.btnOutFocus_Drag);
			this.panel1.Controls.Add(this.btnThisDrag);
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
			// btnDragDeley
			// 
			this.btnDragDeley.Location = new System.Drawing.Point(3, 337);
			this.btnDragDeley.Name = "btnDragDeley";
			this.btnDragDeley.Size = new System.Drawing.Size(157, 23);
			this.btnDragDeley.TabIndex = 8;
			this.btnDragDeley.Text = "Out Focus Drag Deley";
			this.btnDragDeley.UseVisualStyleBackColor = true;
			this.btnDragDeley.Click += new System.EventHandler(this.btnDragDeley_Click);
			// 
			// btnOutFocus_Drag2
			// 
			this.btnOutFocus_Drag2.Location = new System.Drawing.Point(3, 253);
			this.btnOutFocus_Drag2.Name = "btnOutFocus_Drag2";
			this.btnOutFocus_Drag2.Size = new System.Drawing.Size(157, 23);
			this.btnOutFocus_Drag2.TabIndex = 7;
			this.btnOutFocus_Drag2.Text = "Out focus Drag";
			this.btnOutFocus_Drag2.UseVisualStyleBackColor = true;
			this.btnOutFocus_Drag2.Click += new System.EventHandler(this.btnOutFocus_Drag2_Click);
			// 
			// btnOutFocus_Drag
			// 
			this.btnOutFocus_Drag.Location = new System.Drawing.Point(3, 224);
			this.btnOutFocus_Drag.Name = "btnOutFocus_Drag";
			this.btnOutFocus_Drag.Size = new System.Drawing.Size(157, 23);
			this.btnOutFocus_Drag.TabIndex = 6;
			this.btnOutFocus_Drag.Text = "Out focus Drag(Focus)";
			this.btnOutFocus_Drag.UseVisualStyleBackColor = true;
			this.btnOutFocus_Drag.Click += new System.EventHandler(this.btnOutFocus_Drag_Click);
			// 
			// btnThisDrag
			// 
			this.btnThisDrag.Location = new System.Drawing.Point(3, 103);
			this.btnThisDrag.Name = "btnThisDrag";
			this.btnThisDrag.Size = new System.Drawing.Size(157, 23);
			this.btnThisDrag.TabIndex = 5;
			this.btnThisDrag.Text = "This Drag";
			this.btnThisDrag.UseVisualStyleBackColor = true;
			this.btnThisDrag.Click += new System.EventHandler(this.btnThisDrag_Click);
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
			this.btnOpenOutFocus.Location = new System.Drawing.Point(3, 177);
			this.btnOpenOutFocus.Name = "btnOpenOutFocus";
			this.btnOpenOutFocus.Size = new System.Drawing.Size(157, 23);
			this.btnOpenOutFocus.TabIndex = 1;
			this.btnOpenOutFocus.Text = "Open out focus";
			this.btnOpenOutFocus.UseVisualStyleBackColor = true;
			this.btnOpenOutFocus.Click += new System.EventHandler(this.btnOpenOutFocus_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(3, 366);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
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
			// pictureDraw
			// 
			this.pictureDraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.pictureDraw.Location = new System.Drawing.Point(2, 2);
			this.pictureDraw.Name = "pictureDraw";
			this.pictureDraw.Size = new System.Drawing.Size(519, 357);
			this.pictureDraw.TabIndex = 4;
			this.pictureDraw.TabStop = false;
			// 
			// btnOutFocus_Drag3
			// 
			this.btnOutFocus_Drag3.Location = new System.Drawing.Point(3, 282);
			this.btnOutFocus_Drag3.Name = "btnOutFocus_Drag3";
			this.btnOutFocus_Drag3.Size = new System.Drawing.Size(157, 23);
			this.btnOutFocus_Drag3.TabIndex = 9;
			this.btnOutFocus_Drag3.Text = "button2";
			this.btnOutFocus_Drag3.UseVisualStyleBackColor = true;
			this.btnOutFocus_Drag3.Click += new System.EventHandler(this.btnOutFocus_Drag3_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 581);
			this.Controls.Add(this.pictureDraw);
			this.Controls.Add(this.listLog);
			this.Controls.Add(this.panel1);
			this.Name = "frmMain";
			this.Text = "Win32 Drag Test";
			this.Load += new System.EventHandler(this.frmMian_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureDraw)).EndInit();
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
		private Button btnImageClear;
        private PictureBox pictureDraw;
        private Button btnThisDrag;
        private Button btnOutFocus_Drag;
        private Button btnOutFocus_Drag2;
		private Button btnDragDeley;
		private Button btnOutFocus_Drag3;
	}
}