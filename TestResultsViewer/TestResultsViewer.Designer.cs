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
			this.msi_File_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.TestStatusTreeView = new System.Windows.Forms.TreeView();
			this.panel_NodeName = new System.Windows.Forms.Panel();
			this.label_NodeName = new System.Windows.Forms.Label();
			this.panel_TestDetail = new System.Windows.Forms.Panel();
			this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
			this.splitContainer_Left = new System.Windows.Forms.SplitContainer();
			this.menuStrip1.SuspendLayout();
			this.panel_NodeName.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
			this.splitContainer_Main.Panel1.SuspendLayout();
			this.splitContainer_Main.Panel2.SuspendLayout();
			this.splitContainer_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Left)).BeginInit();
			this.splitContainer_Left.Panel2.SuspendLayout();
			this.splitContainer_Left.SuspendLayout();
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
			// msi_File_Open
			// 
			this.msi_File_Open.Name = "msi_File_Open";
			this.msi_File_Open.Size = new System.Drawing.Size(103, 22);
			this.msi_File_Open.Text = "Open";
			this.msi_File_Open.Click += new System.EventHandler(this.msi_File_Open_Click);
			// 
			// TestStatusTreeView
			// 
			this.TestStatusTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TestStatusTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TestStatusTreeView.Location = new System.Drawing.Point(0, 0);
			this.TestStatusTreeView.Name = "TestStatusTreeView";
			this.TestStatusTreeView.Size = new System.Drawing.Size(352, 622);
			this.TestStatusTreeView.TabIndex = 1;
			this.TestStatusTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TestStatusTreeView_NodeMouseClick);
			// 
			// panel_NodeName
			// 
			this.panel_NodeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_NodeName.Controls.Add(this.label_NodeName);
			this.panel_NodeName.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel_NodeName.Location = new System.Drawing.Point(0, 0);
			this.panel_NodeName.Name = "panel_NodeName";
			this.panel_NodeName.Size = new System.Drawing.Size(616, 46);
			this.panel_NodeName.TabIndex = 1;
			// 
			// label_NodeName
			// 
			this.label_NodeName.AutoSize = true;
			this.label_NodeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_NodeName.Location = new System.Drawing.Point(3, 14);
			this.label_NodeName.Name = "label_NodeName";
			this.label_NodeName.Size = new System.Drawing.Size(85, 20);
			this.label_NodeName.TabIndex = 0;
			this.label_NodeName.Text = "Test Detail";
			// 
			// panel_TestDetail
			// 
			this.panel_TestDetail.AutoScroll = true;
			this.panel_TestDetail.BackColor = System.Drawing.SystemColors.Window;
			this.panel_TestDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_TestDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_TestDetail.Location = new System.Drawing.Point(0, 46);
			this.panel_TestDetail.Name = "panel_TestDetail";
			this.panel_TestDetail.Size = new System.Drawing.Size(616, 243);
			this.panel_TestDetail.TabIndex = 0;
			// 
			// splitContainer_Main
			// 
			this.splitContainer_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer_Main.Location = new System.Drawing.Point(12, 27);
			this.splitContainer_Main.Name = "splitContainer_Main";
			// 
			// splitContainer_Main.Panel1
			// 
			this.splitContainer_Main.Panel1.Controls.Add(this.splitContainer_Left);
			// 
			// splitContainer_Main.Panel2
			// 
			this.splitContainer_Main.Panel2.Controls.Add(this.TestStatusTreeView);
			this.splitContainer_Main.Size = new System.Drawing.Size(972, 622);
			this.splitContainer_Main.SplitterDistance = 616;
			this.splitContainer_Main.TabIndex = 3;
			// 
			// splitContainer_Left
			// 
			this.splitContainer_Left.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer_Left.Location = new System.Drawing.Point(0, 0);
			this.splitContainer_Left.Name = "splitContainer_Left";
			this.splitContainer_Left.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer_Left.Panel2
			// 
			this.splitContainer_Left.Panel2.Controls.Add(this.panel_TestDetail);
			this.splitContainer_Left.Panel2.Controls.Add(this.panel_NodeName);
			this.splitContainer_Left.Size = new System.Drawing.Size(616, 622);
			this.splitContainer_Left.SplitterDistance = 329;
			this.splitContainer_Left.TabIndex = 3;
			// 
			// form_Viewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(996, 661);
			this.Controls.Add(this.splitContainer_Main);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "form_Viewer";
			this.Text = "Test Results Viewer";
			this.Load += new System.EventHandler(this.TestResultsViewer_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel_NodeName.ResumeLayout(false);
			this.panel_NodeName.PerformLayout();
			this.splitContainer_Main.Panel1.ResumeLayout(false);
			this.splitContainer_Main.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
			this.splitContainer_Main.ResumeLayout(false);
			this.splitContainer_Left.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Left)).EndInit();
			this.splitContainer_Left.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem msi_File;
		private System.Windows.Forms.ToolStripMenuItem msi_File_Open;
		private System.Windows.Forms.TreeView TestStatusTreeView;
		private System.Windows.Forms.Panel panel_NodeName;
		private System.Windows.Forms.Label label_NodeName;
		private System.Windows.Forms.Panel panel_TestDetail;
		private System.Windows.Forms.SplitContainer splitContainer_Main;
		private System.Windows.Forms.SplitContainer splitContainer_Left;
	}
}

