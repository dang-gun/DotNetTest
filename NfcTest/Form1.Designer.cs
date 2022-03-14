namespace NfcTest
{
	partial class Form1
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
			this.comboCardList = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCardListRefresh = new System.Windows.Forms.Button();
			this.listLog = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.btnSendApdu = new System.Windows.Forms.Button();
			this.btnReadReaderAttr = new System.Windows.Forms.Button();
			this.btnGetData = new System.Windows.Forms.Button();
			this.btnSetData = new System.Windows.Forms.Button();
			this.btnAuthBlock1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtUpdateBinary = new System.Windows.Forms.TextBox();
			this.btnBlock0UpdateBinary = new System.Windows.Forms.Button();
			this.btnBlock0ReadBinary = new System.Windows.Forms.Button();
			this.labInfo = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnBlockAuth = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnReadBinaryBlocks = new System.Windows.Forms.Button();
			this.btnAuthBlock = new System.Windows.Forms.Button();
			this.btnLoadKey = new System.Windows.Forms.Button();
			this.btnUpdateBinaryBlocks = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboCardList
			// 
			this.comboCardList.FormattingEnabled = true;
			this.comboCardList.Location = new System.Drawing.Point(118, 10);
			this.comboCardList.Name = "comboCardList";
			this.comboCardList.Size = new System.Drawing.Size(471, 23);
			this.comboCardList.TabIndex = 0;
			this.comboCardList.SelectedIndexChanged += new System.EventHandler(this.comboCardList_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Card List";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnCardListRefresh
			// 
			this.btnCardListRefresh.Location = new System.Drawing.Point(597, 10);
			this.btnCardListRefresh.Name = "btnCardListRefresh";
			this.btnCardListRefresh.Size = new System.Drawing.Size(100, 23);
			this.btnCardListRefresh.TabIndex = 2;
			this.btnCardListRefresh.Text = "Refresh";
			this.btnCardListRefresh.UseVisualStyleBackColor = true;
			this.btnCardListRefresh.Click += new System.EventHandler(this.btnCardListRefresh_Click);
			// 
			// listLog
			// 
			this.listLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listLog.HideSelection = false;
			this.listLog.Location = new System.Drawing.Point(12, 228);
			this.listLog.Name = "listLog";
			this.listLog.Size = new System.Drawing.Size(685, 350);
			this.listLog.TabIndex = 3;
			this.listLog.UseCompatibleStateImageBehavior = false;
			this.listLog.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Time";
			this.columnHeader1.Width = 80;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Contents";
			this.columnHeader2.Width = 580;
			// 
			// btnSendApdu
			// 
			this.btnSendApdu.Location = new System.Drawing.Point(12, 50);
			this.btnSendApdu.Name = "btnSendApdu";
			this.btnSendApdu.Size = new System.Drawing.Size(160, 23);
			this.btnSendApdu.TabIndex = 4;
			this.btnSendApdu.Text = "Send ISO7816 APDUs";
			this.btnSendApdu.UseVisualStyleBackColor = true;
			this.btnSendApdu.Click += new System.EventHandler(this.btnSendApdu_Click);
			// 
			// btnReadReaderAttr
			// 
			this.btnReadReaderAttr.Location = new System.Drawing.Point(12, 79);
			this.btnReadReaderAttr.Name = "btnReadReaderAttr";
			this.btnReadReaderAttr.Size = new System.Drawing.Size(160, 23);
			this.btnReadReaderAttr.TabIndex = 5;
			this.btnReadReaderAttr.Text = "Read reader attributes";
			this.btnReadReaderAttr.UseVisualStyleBackColor = true;
			this.btnReadReaderAttr.Click += new System.EventHandler(this.btnReadReaderAttr_Click);
			// 
			// btnGetData
			// 
			this.btnGetData.Location = new System.Drawing.Point(12, 108);
			this.btnGetData.Name = "btnGetData";
			this.btnGetData.Size = new System.Drawing.Size(160, 23);
			this.btnGetData.TabIndex = 6;
			this.btnGetData.Text = "Transmit - GetData";
			this.btnGetData.UseVisualStyleBackColor = true;
			this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
			// 
			// btnSetData
			// 
			this.btnSetData.Location = new System.Drawing.Point(12, 137);
			this.btnSetData.Name = "btnSetData";
			this.btnSetData.Size = new System.Drawing.Size(160, 23);
			this.btnSetData.TabIndex = 7;
			this.btnSetData.Text = "Transmit - SetData";
			this.btnSetData.UseVisualStyleBackColor = true;
			this.btnSetData.Click += new System.EventHandler(this.btnSetData_Click);
			// 
			// btnAuthBlock1
			// 
			this.btnAuthBlock1.Location = new System.Drawing.Point(6, 29);
			this.btnAuthBlock1.Name = "btnAuthBlock1";
			this.btnAuthBlock1.Size = new System.Drawing.Size(160, 23);
			this.btnAuthBlock1.TabIndex = 8;
			this.btnAuthBlock1.Text = "Block 0 - Auth ";
			this.btnAuthBlock1.UseVisualStyleBackColor = true;
			this.btnAuthBlock1.Click += new System.EventHandler(this.btnAuthBlock1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtUpdateBinary);
			this.groupBox1.Controls.Add(this.btnBlock0UpdateBinary);
			this.groupBox1.Controls.Add(this.btnBlock0ReadBinary);
			this.groupBox1.Controls.Add(this.btnAuthBlock1);
			this.groupBox1.Location = new System.Drawing.Point(366, 238);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(182, 172);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Custom Command";
			// 
			// txtUpdateBinary
			// 
			this.txtUpdateBinary.Location = new System.Drawing.Point(6, 116);
			this.txtUpdateBinary.Name = "txtUpdateBinary";
			this.txtUpdateBinary.Size = new System.Drawing.Size(160, 23);
			this.txtUpdateBinary.TabIndex = 11;
			// 
			// btnBlock0UpdateBinary
			// 
			this.btnBlock0UpdateBinary.Location = new System.Drawing.Point(6, 87);
			this.btnBlock0UpdateBinary.Name = "btnBlock0UpdateBinary";
			this.btnBlock0UpdateBinary.Size = new System.Drawing.Size(160, 23);
			this.btnBlock0UpdateBinary.TabIndex = 10;
			this.btnBlock0UpdateBinary.Text = "Block 0 - Update Binary";
			this.btnBlock0UpdateBinary.UseVisualStyleBackColor = true;
			this.btnBlock0UpdateBinary.Click += new System.EventHandler(this.btnBlock0UpdateBinary_Click);
			// 
			// btnBlock0ReadBinary
			// 
			this.btnBlock0ReadBinary.Location = new System.Drawing.Point(6, 58);
			this.btnBlock0ReadBinary.Name = "btnBlock0ReadBinary";
			this.btnBlock0ReadBinary.Size = new System.Drawing.Size(160, 23);
			this.btnBlock0ReadBinary.TabIndex = 9;
			this.btnBlock0ReadBinary.Text = "Block 0 - Read Binary";
			this.btnBlock0ReadBinary.UseVisualStyleBackColor = true;
			this.btnBlock0ReadBinary.Click += new System.EventHandler(this.btnBlock0ReadBinary_Click);
			// 
			// labInfo
			// 
			this.labInfo.Location = new System.Drawing.Point(597, 36);
			this.labInfo.Name = "labInfo";
			this.labInfo.Size = new System.Drawing.Size(100, 189);
			this.labInfo.TabIndex = 10;
			this.labInfo.Text = "Card List";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnBlockAuth);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.numericUpDown1);
			this.groupBox2.Location = new System.Drawing.Point(366, 50);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(174, 172);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Block Command";
			// 
			// btnBlockAuth
			// 
			this.btnBlockAuth.Location = new System.Drawing.Point(6, 51);
			this.btnBlockAuth.Name = "btnBlockAuth";
			this.btnBlockAuth.Size = new System.Drawing.Size(160, 23);
			this.btnBlockAuth.TabIndex = 3;
			this.btnBlockAuth.Text = "Block Auth";
			this.btnBlockAuth.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Use Block";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(112, 22);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(54, 23);
			this.numericUpDown1.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnUpdateBinaryBlocks);
			this.groupBox3.Controls.Add(this.btnReadBinaryBlocks);
			this.groupBox3.Controls.Add(this.btnAuthBlock);
			this.groupBox3.Controls.Add(this.btnLoadKey);
			this.groupBox3.Location = new System.Drawing.Point(178, 50);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(172, 172);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Device Test";
			// 
			// btnReadBinaryBlocks
			// 
			this.btnReadBinaryBlocks.Location = new System.Drawing.Point(6, 80);
			this.btnReadBinaryBlocks.Name = "btnReadBinaryBlocks";
			this.btnReadBinaryBlocks.Size = new System.Drawing.Size(160, 23);
			this.btnReadBinaryBlocks.TabIndex = 2;
			this.btnReadBinaryBlocks.Text = "Read Binary Blocks";
			this.btnReadBinaryBlocks.UseVisualStyleBackColor = true;
			this.btnReadBinaryBlocks.Click += new System.EventHandler(this.btnReadBinaryBlocks_Click);
			// 
			// btnAuthBlock
			// 
			this.btnAuthBlock.Location = new System.Drawing.Point(6, 51);
			this.btnAuthBlock.Name = "btnAuthBlock";
			this.btnAuthBlock.Size = new System.Drawing.Size(160, 23);
			this.btnAuthBlock.TabIndex = 1;
			this.btnAuthBlock.Text = "Auth Block";
			this.btnAuthBlock.UseVisualStyleBackColor = true;
			this.btnAuthBlock.Click += new System.EventHandler(this.btnAuthBlock_Click);
			// 
			// btnLoadKey
			// 
			this.btnLoadKey.Location = new System.Drawing.Point(6, 22);
			this.btnLoadKey.Name = "btnLoadKey";
			this.btnLoadKey.Size = new System.Drawing.Size(160, 23);
			this.btnLoadKey.TabIndex = 0;
			this.btnLoadKey.Text = "Load Key";
			this.btnLoadKey.UseVisualStyleBackColor = true;
			this.btnLoadKey.Click += new System.EventHandler(this.btnLoadKey_Click);
			// 
			// btnUpdateBinaryBlocks
			// 
			this.btnUpdateBinaryBlocks.Location = new System.Drawing.Point(6, 109);
			this.btnUpdateBinaryBlocks.Name = "btnUpdateBinaryBlocks";
			this.btnUpdateBinaryBlocks.Size = new System.Drawing.Size(160, 23);
			this.btnUpdateBinaryBlocks.TabIndex = 3;
			this.btnUpdateBinaryBlocks.Text = "Update Binary Blocks";
			this.btnUpdateBinaryBlocks.UseVisualStyleBackColor = true;
			this.btnUpdateBinaryBlocks.Click += new System.EventHandler(this.btnUpdateBinaryBlocks_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(710, 590);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.labInfo);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnSetData);
			this.Controls.Add(this.btnGetData);
			this.Controls.Add(this.btnReadReaderAttr);
			this.Controls.Add(this.btnSendApdu);
			this.Controls.Add(this.listLog);
			this.Controls.Add(this.btnCardListRefresh);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboCardList);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboCardList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCardListRefresh;
		private System.Windows.Forms.ListView listLog;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button btnSendApdu;
		private System.Windows.Forms.Button btnReadReaderAttr;
		private System.Windows.Forms.Button btnGetData;
		private System.Windows.Forms.Button btnSetData;
		private System.Windows.Forms.Button btnAuthBlock1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label labInfo;
		private System.Windows.Forms.Button btnBlock0ReadBinary;
		private System.Windows.Forms.Button btnBlock0UpdateBinary;
		private System.Windows.Forms.TextBox txtUpdateBinary;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnBlockAuth;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnLoadKey;
		private System.Windows.Forms.Button btnAuthBlock;
		private System.Windows.Forms.Button btnReadBinaryBlocks;
		private System.Windows.Forms.Button btnUpdateBinaryBlocks;
	}
}
