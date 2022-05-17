namespace LiteDbTest2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
			this.btnDataAdd = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnSelectAll = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnDataAdd
			// 
			this.btnDataAdd.Location = new System.Drawing.Point(12, 37);
			this.btnDataAdd.Name = "btnDataAdd";
			this.btnDataAdd.Size = new System.Drawing.Size(100, 23);
			this.btnDataAdd.TabIndex = 0;
			this.btnDataAdd.Text = "Data add";
			this.btnDataAdd.UseVisualStyleBackColor = true;
			this.btnDataAdd.Click += new System.EventHandler(this.btnDataAdd_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(12, 10);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(100, 21);
			this.txtName.TabIndex = 1;
			this.txtName.Text = "Name";
			// 
			// btnSelectAll
			// 
			this.btnSelectAll.Location = new System.Drawing.Point(12, 66);
			this.btnSelectAll.Name = "btnSelectAll";
			this.btnSelectAll.Size = new System.Drawing.Size(100, 23);
			this.btnSelectAll.TabIndex = 2;
			this.btnSelectAll.Text = "Select All";
			this.btnSelectAll.UseVisualStyleBackColor = true;
			this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(12, 95);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(100, 23);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(229, 36);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(229, 65);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(551, 450);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSelectAll);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.btnDataAdd);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDataAdd;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSelectAll;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}

