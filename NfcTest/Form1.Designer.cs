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
			this.btnGetData = new System.Windows.Forms.Button();
			this.btnSetData = new System.Windows.Forms.Button();
			this.txtUpdateBinary = new System.Windows.Forms.TextBox();
			this.labInfo = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.numericBlockNumber = new System.Windows.Forms.NumericUpDown();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnGetStatus = new System.Windows.Forms.Button();
			this.btnGetArt = new System.Windows.Forms.Button();
			this.btnUpdateBinaryBlocks = new System.Windows.Forms.Button();
			this.btnReadBinaryBlocks = new System.Windows.Forms.Button();
			this.btnAuthBlock = new System.Windows.Forms.Button();
			this.btnLoadKey = new System.Windows.Forms.Button();
			this.listviewDevice = new System.Windows.Forms.ListView();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.listviewCard = new System.Windows.Forms.ListView();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnUseBlockSet = new System.Windows.Forms.Button();
			this.btnReadBinary = new System.Windows.Forms.Button();
			this.numericBlockCount = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.numericStartBlock = new System.Windows.Forms.NumericUpDown();
			this.btnUpdateBinary = new System.Windows.Forms.Button();
			this.txtNfcReaderData = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.numericBlockNumber)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericBlockCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericStartBlock)).BeginInit();
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
			this.listLog.Size = new System.Drawing.Size(692, 350);
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
			// btnGetData
			// 
			this.btnGetData.Location = new System.Drawing.Point(496, 262);
			this.btnGetData.Name = "btnGetData";
			this.btnGetData.Size = new System.Drawing.Size(160, 23);
			this.btnGetData.TabIndex = 6;
			this.btnGetData.Text = "Transmit - GetData";
			this.btnGetData.UseVisualStyleBackColor = true;
			this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
			// 
			// btnSetData
			// 
			this.btnSetData.Location = new System.Drawing.Point(496, 291);
			this.btnSetData.Name = "btnSetData";
			this.btnSetData.Size = new System.Drawing.Size(160, 23);
			this.btnSetData.TabIndex = 7;
			this.btnSetData.Text = "Transmit - SetData";
			this.btnSetData.UseVisualStyleBackColor = true;
			this.btnSetData.Click += new System.EventHandler(this.btnSetData_Click);
			// 
			// txtUpdateBinary
			// 
			this.txtUpdateBinary.Location = new System.Drawing.Point(172, 138);
			this.txtUpdateBinary.Name = "txtUpdateBinary";
			this.txtUpdateBinary.Size = new System.Drawing.Size(160, 23);
			this.txtUpdateBinary.TabIndex = 11;
			// 
			// labInfo
			// 
			this.labInfo.Location = new System.Drawing.Point(6, 109);
			this.labInfo.Name = "labInfo";
			this.labInfo.Size = new System.Drawing.Size(160, 52);
			this.labInfo.TabIndex = 10;
			this.labInfo.Text = "Card List";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(172, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Use Block";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// numericBlockNumber
			// 
			this.numericBlockNumber.Location = new System.Drawing.Point(278, 24);
			this.numericBlockNumber.Name = "numericBlockNumber";
			this.numericBlockNumber.Size = new System.Drawing.Size(54, 23);
			this.numericBlockNumber.TabIndex = 0;
			this.numericBlockNumber.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnGetStatus);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.labInfo);
			this.groupBox3.Controls.Add(this.btnGetArt);
			this.groupBox3.Controls.Add(this.numericBlockNumber);
			this.groupBox3.Controls.Add(this.txtUpdateBinary);
			this.groupBox3.Controls.Add(this.btnUpdateBinaryBlocks);
			this.groupBox3.Controls.Add(this.btnReadBinaryBlocks);
			this.groupBox3.Controls.Add(this.btnAuthBlock);
			this.groupBox3.Controls.Add(this.btnLoadKey);
			this.groupBox3.Location = new System.Drawing.Point(195, 39);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(336, 175);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Card Test";
			// 
			// btnGetStatus
			// 
			this.btnGetStatus.Location = new System.Drawing.Point(6, 22);
			this.btnGetStatus.Name = "btnGetStatus";
			this.btnGetStatus.Size = new System.Drawing.Size(160, 23);
			this.btnGetStatus.TabIndex = 14;
			this.btnGetStatus.Text = "Get Status";
			this.btnGetStatus.UseVisualStyleBackColor = true;
			this.btnGetStatus.Click += new System.EventHandler(this.btnGetStatus_Click);
			// 
			// btnGetArt
			// 
			this.btnGetArt.Location = new System.Drawing.Point(6, 51);
			this.btnGetArt.Name = "btnGetArt";
			this.btnGetArt.Size = new System.Drawing.Size(160, 23);
			this.btnGetArt.TabIndex = 13;
			this.btnGetArt.Text = "Get ATR";
			this.btnGetArt.UseVisualStyleBackColor = true;
			this.btnGetArt.Click += new System.EventHandler(this.btnGetArt_Click);
			// 
			// btnUpdateBinaryBlocks
			// 
			this.btnUpdateBinaryBlocks.Location = new System.Drawing.Point(172, 109);
			this.btnUpdateBinaryBlocks.Name = "btnUpdateBinaryBlocks";
			this.btnUpdateBinaryBlocks.Size = new System.Drawing.Size(160, 23);
			this.btnUpdateBinaryBlocks.TabIndex = 3;
			this.btnUpdateBinaryBlocks.Text = "Update Binary Blocks";
			this.btnUpdateBinaryBlocks.UseVisualStyleBackColor = true;
			this.btnUpdateBinaryBlocks.Click += new System.EventHandler(this.btnUpdateBinaryBlocks_Click);
			// 
			// btnReadBinaryBlocks
			// 
			this.btnReadBinaryBlocks.Location = new System.Drawing.Point(172, 80);
			this.btnReadBinaryBlocks.Name = "btnReadBinaryBlocks";
			this.btnReadBinaryBlocks.Size = new System.Drawing.Size(160, 23);
			this.btnReadBinaryBlocks.TabIndex = 2;
			this.btnReadBinaryBlocks.Text = "Read Binary Blocks";
			this.btnReadBinaryBlocks.UseVisualStyleBackColor = true;
			this.btnReadBinaryBlocks.Click += new System.EventHandler(this.btnReadBinaryBlocks_Click);
			// 
			// btnAuthBlock
			// 
			this.btnAuthBlock.Location = new System.Drawing.Point(172, 51);
			this.btnAuthBlock.Name = "btnAuthBlock";
			this.btnAuthBlock.Size = new System.Drawing.Size(160, 23);
			this.btnAuthBlock.TabIndex = 1;
			this.btnAuthBlock.Text = "Auth Block";
			this.btnAuthBlock.UseVisualStyleBackColor = true;
			this.btnAuthBlock.Click += new System.EventHandler(this.btnAuthBlock_Click);
			// 
			// btnLoadKey
			// 
			this.btnLoadKey.Location = new System.Drawing.Point(6, 80);
			this.btnLoadKey.Name = "btnLoadKey";
			this.btnLoadKey.Size = new System.Drawing.Size(160, 23);
			this.btnLoadKey.TabIndex = 0;
			this.btnLoadKey.Text = "Load Key";
			this.btnLoadKey.UseVisualStyleBackColor = true;
			this.btnLoadKey.Click += new System.EventHandler(this.btnLoadKey_Click);
			// 
			// listviewDevice
			// 
			this.listviewDevice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
			this.listviewDevice.HideSelection = false;
			this.listviewDevice.Location = new System.Drawing.Point(11, 39);
			this.listviewDevice.Name = "listviewDevice";
			this.listviewDevice.Size = new System.Drawing.Size(180, 85);
			this.listviewDevice.TabIndex = 15;
			this.listviewDevice.UseCompatibleStateImageBehavior = false;
			this.listviewDevice.View = System.Windows.Forms.View.Details;
			this.listviewDevice.SelectedIndexChanged += new System.EventHandler(this.listviewDevice_SelectedIndexChanged);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Device";
			this.columnHeader3.Width = 155;
			// 
			// listviewCard
			// 
			this.listviewCard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
			this.listviewCard.HideSelection = false;
			this.listviewCard.Location = new System.Drawing.Point(11, 129);
			this.listviewCard.Name = "listviewCard";
			this.listviewCard.Size = new System.Drawing.Size(180, 85);
			this.listviewCard.TabIndex = 16;
			this.listviewCard.UseCompatibleStateImageBehavior = false;
			this.listviewCard.View = System.Windows.Forms.View.Details;
			this.listviewCard.SelectedIndexChanged += new System.EventHandler(this.listviewCard_SelectedIndexChanged);
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Card";
			this.columnHeader4.Width = 155;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtNfcReaderData);
			this.groupBox1.Controls.Add(this.btnUpdateBinary);
			this.groupBox1.Controls.Add(this.btnUseBlockSet);
			this.groupBox1.Controls.Add(this.btnReadBinary);
			this.groupBox1.Controls.Add(this.numericBlockCount);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.numericStartBlock);
			this.groupBox1.Location = new System.Drawing.Point(534, 40);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(170, 175);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Nfc Reader";
			// 
			// btnUseBlockSet
			// 
			this.btnUseBlockSet.Location = new System.Drawing.Point(123, 52);
			this.btnUseBlockSet.Name = "btnUseBlockSet";
			this.btnUseBlockSet.Size = new System.Drawing.Size(40, 23);
			this.btnUseBlockSet.TabIndex = 9;
			this.btnUseBlockSet.Text = "Set";
			this.btnUseBlockSet.UseVisualStyleBackColor = true;
			this.btnUseBlockSet.Click += new System.EventHandler(this.btnUseBlockSet_Click);
			// 
			// btnReadBinary
			// 
			this.btnReadBinary.Location = new System.Drawing.Point(3, 81);
			this.btnReadBinary.Name = "btnReadBinary";
			this.btnReadBinary.Size = new System.Drawing.Size(160, 23);
			this.btnReadBinary.TabIndex = 8;
			this.btnReadBinary.Text = "Read Binary";
			this.btnReadBinary.UseVisualStyleBackColor = true;
			this.btnReadBinary.Click += new System.EventHandler(this.btnReadBinary_Click);
			// 
			// numericBlockCount
			// 
			this.numericBlockCount.Location = new System.Drawing.Point(63, 52);
			this.numericBlockCount.Name = "numericBlockCount";
			this.numericBlockCount.Size = new System.Drawing.Size(54, 23);
			this.numericBlockCount.TabIndex = 7;
			this.numericBlockCount.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Start Block            Count";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericStartBlock
			// 
			this.numericStartBlock.Location = new System.Drawing.Point(3, 52);
			this.numericStartBlock.Name = "numericStartBlock";
			this.numericStartBlock.Size = new System.Drawing.Size(54, 23);
			this.numericStartBlock.TabIndex = 3;
			this.numericStartBlock.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// btnUpdateBinary
			// 
			this.btnUpdateBinary.Location = new System.Drawing.Point(3, 110);
			this.btnUpdateBinary.Name = "btnUpdateBinary";
			this.btnUpdateBinary.Size = new System.Drawing.Size(160, 23);
			this.btnUpdateBinary.TabIndex = 10;
			this.btnUpdateBinary.Text = "Update Binary";
			this.btnUpdateBinary.UseVisualStyleBackColor = true;
			this.btnUpdateBinary.Click += new System.EventHandler(this.btnUpdateBinary_Click);
			// 
			// txtNfcReaderData
			// 
			this.txtNfcReaderData.Location = new System.Drawing.Point(3, 137);
			this.txtNfcReaderData.Name = "txtNfcReaderData";
			this.txtNfcReaderData.Size = new System.Drawing.Size(160, 23);
			this.txtNfcReaderData.TabIndex = 11;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(713, 590);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.listviewCard);
			this.Controls.Add(this.listviewDevice);
			this.Controls.Add(this.btnGetData);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btnSetData);
			this.Controls.Add(this.listLog);
			this.Controls.Add(this.btnCardListRefresh);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboCardList);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.numericBlockNumber)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericBlockCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericStartBlock)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboCardList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCardListRefresh;
		private System.Windows.Forms.ListView listLog;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button btnGetData;
		private System.Windows.Forms.Button btnSetData;
		private System.Windows.Forms.Label labInfo;
		private System.Windows.Forms.TextBox txtUpdateBinary;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericBlockNumber;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnLoadKey;
		private System.Windows.Forms.Button btnAuthBlock;
		private System.Windows.Forms.Button btnReadBinaryBlocks;
		private System.Windows.Forms.Button btnUpdateBinaryBlocks;
		private System.Windows.Forms.Button btnGetArt;
		private System.Windows.Forms.Button btnGetStatus;
		private System.Windows.Forms.ListView listviewDevice;
		private System.Windows.Forms.ListView listviewCard;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numericBlockCount;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericStartBlock;
		private System.Windows.Forms.Button btnReadBinary;
		private System.Windows.Forms.Button btnUseBlockSet;
		private System.Windows.Forms.TextBox txtNfcReaderData;
		private System.Windows.Forms.Button btnUpdateBinary;
	}
}
