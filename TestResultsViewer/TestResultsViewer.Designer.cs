namespace TestResultsViewer
{
	partial class form_Viewer
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.msi_File = new System.Windows.Forms.ToolStripMenuItem();
			this.TestStatusTreeView = new System.Windows.Forms.TreeView();
			this.msi_File_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msi_File});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(996, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "ms_viewerMenu";
			// 
			// msi_File
			// 
			this.msi_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msi_File_Open});
			this.msi_File.Name = "msi_File";
			this.msi_File.Size = new System.Drawing.Size(37, 20);
			this.msi_File.Text = "File";
			// 
			// TestStatusTreeView
			// 
			this.TestStatusTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TestStatusTreeView.Location = new System.Drawing.Point(509, 27);
			this.TestStatusTreeView.Name = "TestStatusTreeView";
			this.TestStatusTreeView.Size = new System.Drawing.Size(475, 622);
			this.TestStatusTreeView.TabIndex = 1;
			// 
			// msi_File_Open
			// 
			this.msi_File_Open.Name = "msi_File_Open";
			this.msi_File_Open.Size = new System.Drawing.Size(152, 22);
			this.msi_File_Open.Text = "Open";
			this.msi_File_Open.Click += new System.EventHandler(this.msi_File_Open_Click);
			// 
			// form_Viewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(996, 661);
			this.Controls.Add(this.TestStatusTreeView);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "form_Viewer";
			this.Text = "Test Results Viewer";
			this.Load += new System.EventHandler(this.TestResultsViewer_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem msi_File;
		private System.Windows.Forms.ToolStripMenuItem msi_File_Open;
		private System.Windows.Forms.TreeView TestStatusTreeView;
	}
}

