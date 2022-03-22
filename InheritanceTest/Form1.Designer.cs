namespace InheritanceTest
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
			this.btnParent1List = new System.Windows.Forms.Button();
			this.btnParent1ListRestore = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnParent1List
			// 
			this.btnParent1List.Location = new System.Drawing.Point(12, 25);
			this.btnParent1List.Name = "btnParent1List";
			this.btnParent1List.Size = new System.Drawing.Size(141, 23);
			this.btnParent1List.TabIndex = 0;
			this.btnParent1List.Text = "부모1 리스트 테스트";
			this.btnParent1List.UseVisualStyleBackColor = true;
			this.btnParent1List.Click += new System.EventHandler(this.btnParent1List_Click);
			// 
			// btnParent1ListRestore
			// 
			this.btnParent1ListRestore.Location = new System.Drawing.Point(12, 54);
			this.btnParent1ListRestore.Name = "btnParent1ListRestore";
			this.btnParent1ListRestore.Size = new System.Drawing.Size(141, 23);
			this.btnParent1ListRestore.TabIndex = 1;
			this.btnParent1ListRestore.Text = "리스트 복원";
			this.btnParent1ListRestore.UseVisualStyleBackColor = true;
			this.btnParent1ListRestore.Click += new System.EventHandler(this.btnParent1ListRestore_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(545, 450);
			this.Controls.Add(this.btnParent1ListRestore);
			this.Controls.Add(this.btnParent1List);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnParent1List;
		private System.Windows.Forms.Button btnParent1ListRestore;
	}
}
