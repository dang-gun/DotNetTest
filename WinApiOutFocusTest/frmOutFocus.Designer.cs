﻿namespace WinApiOutFocusTest
{
    partial class frmOutFocus
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
            this.listLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.labMove = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listLog
            // 
            this.listLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listLog.GridLines = true;
            this.listLog.Location = new System.Drawing.Point(-1, 366);
            this.listLog.MultiSelect = false;
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(520, 222);
            this.listLog.TabIndex = 2;
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
            this.columnHeader2.Width = 400;
            // 
            // labMove
            // 
            this.labMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labMove.Location = new System.Drawing.Point(0, 0);
            this.labMove.Name = "labMove";
            this.labMove.Size = new System.Drawing.Size(519, 363);
            this.labMove.TabIndex = 4;
            this.labMove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labMove_MouseDown);
            this.labMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labMove_MouseMove);
            this.labMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labMove_MouseUp);
            // 
            // frmOutFocus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 590);
            this.Controls.Add(this.labMove);
            this.Controls.Add(this.listLog);
            this.Name = "frmOutFocus";
            this.Text = "frmOutFocus";
            this.Load += new System.EventHandler(this.frmOutFocus_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listLog;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Label labMove;
    }
}