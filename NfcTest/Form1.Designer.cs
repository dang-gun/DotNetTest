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
			((System.ComponentModel.ISupportInitialize)(this.numericBlockNumber)).BeginInit();
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
			// btnGetData
			// 
			this.btnGetData.Location = new System.Drawing.Point(537, 162);
			this.btnGetData.Name = "btnGetData";
			this.btnGetData.Size = new System.Drawing.Size(160, 23);
			this.btnGetData.TabIndex = 6;
			this.btnGetData.Text = "Transmit - GetData";
			this.btnGetData.UseVisualStyleBackColor = true;
			this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
			// 
			// btnSetData
			// 
			this.btnSetData.Location = new System.Drawing.Point(537, 191);
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(710, 590);
			this.Controls.Add(this.listviewCard);
			this.Controls.Add(this.listviewDevice);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btnSetData);
			this.Controls.Add(this.btnGetData);
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
	}
}
