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
			this.ms_viewerMenu = new System.Windows.Forms.MenuStrip();
			this.msi_File = new System.Windows.Forms.ToolStripMenuItem();
			this.msi_File_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.TestStatusTreeView = new System.Windows.Forms.TreeView();
			this.panel_NodeName = new System.Windows.Forms.Panel();
			this.label_NodeName = new System.Windows.Forms.Label();
			this.panel_TestDetail = new System.Windows.Forms.Panel();
			this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
			this.splitContainer_Left = new System.Windows.Forms.SplitContainer();
			this.panel_TreeResultsHeader = new System.Windows.Forms.Panel();
			this.label_TreeResults = new System.Windows.Forms.Label();
			this.panel_Filters = new System.Windows.Forms.Panel();
			this.grpBox_StatusFilters = new System.Windows.Forms.GroupBox();
			this.cb_Passed = new System.Windows.Forms.CheckBox();
			this.cb_Failed = new System.Windows.Forms.CheckBox();
			this.cb_Ignored = new System.Windows.Forms.CheckBox();
			this.cb_Inconclusive = new System.Windows.Forms.CheckBox();
			this.grpBox_CategoryFilters = new System.Windows.Forms.GroupBox();
			this.clb_Categories = new System.Windows.Forms.CheckedListBox();
			this.ms_viewerMenu.SuspendLayout();
			this.panel_NodeName.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
			this.splitContainer_Main.Panel1.SuspendLayout();
			this.splitContainer_Main.Panel2.SuspendLayout();
			this.splitContainer_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Left)).BeginInit();
			this.splitContainer_Left.Panel1.SuspendLayout();
			this.splitContainer_Left.Panel2.SuspendLayout();
			this.splitContainer_Left.SuspendLayout();
			this.panel_TreeResultsHeader.SuspendLayout();
			this.panel_Filters.SuspendLayout();
			this.grpBox_StatusFilters.SuspendLayout();
			this.grpBox_CategoryFilters.SuspendLayout();
			this.SuspendLayout();
			// 
			// ms_viewerMenu
			// 
			this.ms_viewerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msi_File});
			this.ms_viewerMenu.Location = new System.Drawing.Point(0, 0);
			this.ms_viewerMenu.Name = "ms_viewerMenu";
			this.ms_viewerMenu.Size = new System.Drawing.Size(996, 24);
			this.ms_viewerMenu.TabIndex = 0;
			this.ms_viewerMenu.Text = "Menu";
			// 
			// msi_File
			// 
			this.msi_File.DoubleClickEnabled = true;
			this.msi_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msi_File_Open});
			this.msi_File.Name = "msi_File";
			this.msi_File.Size = new System.Drawing.Size(37, 20);
			this.msi_File.Text = "File";
			// 
			// msi_File_Open
			// 
			this.msi_File_Open.Name = "msi_File_Open";
			this.msi_File_Open.Size = new System.Drawing.Size(152, 22);
			this.msi_File_Open.Text = "Open";
			this.msi_File_Open.Click += new System.EventHandler(this.msi_File_Open_Click);
			// 
			// TestStatusTreeView
			// 
			this.TestStatusTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TestStatusTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TestStatusTreeView.Location = new System.Drawing.Point(0, 24);
			this.TestStatusTreeView.Name = "TestStatusTreeView";
			this.TestStatusTreeView.ShowNodeToolTips = true;
			this.TestStatusTreeView.Size = new System.Drawing.Size(352, 598);
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
			this.panel_NodeName.Size = new System.Drawing.Size(616, 31);
			this.panel_NodeName.TabIndex = 1;
			// 
			// label_NodeName
			// 
			this.label_NodeName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_NodeName.AutoSize = true;
			this.label_NodeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_NodeName.Location = new System.Drawing.Point(2, 4);
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
			this.panel_TestDetail.Location = new System.Drawing.Point(0, 31);
			this.panel_TestDetail.Name = "panel_TestDetail";
			this.panel_TestDetail.Size = new System.Drawing.Size(616, 258);
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
			this.splitContainer_Main.Panel2.Controls.Add(this.panel_TreeResultsHeader);
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
			// splitContainer_Left.Panel1
			// 
			this.splitContainer_Left.Panel1.Controls.Add(this.panel_Filters);
			// 
			// splitContainer_Left.Panel2
			// 
			this.splitContainer_Left.Panel2.Controls.Add(this.panel_TestDetail);
			this.splitContainer_Left.Panel2.Controls.Add(this.panel_NodeName);
			this.splitContainer_Left.Size = new System.Drawing.Size(616, 622);
			this.splitContainer_Left.SplitterDistance = 329;
			this.splitContainer_Left.TabIndex = 3;
			// 
			// panel_TreeResultsHeader
			// 
			this.panel_TreeResultsHeader.Controls.Add(this.label_TreeResults);
			this.panel_TreeResultsHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel_TreeResultsHeader.Location = new System.Drawing.Point(0, 0);
			this.panel_TreeResultsHeader.Name = "panel_TreeResultsHeader";
			this.panel_TreeResultsHeader.Size = new System.Drawing.Size(352, 24);
			this.panel_TreeResultsHeader.TabIndex = 3;
			// 
			// label_TreeResults
			// 
			this.label_TreeResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_TreeResults.AutoSize = true;
			this.label_TreeResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_TreeResults.Location = new System.Drawing.Point(2, 2);
			this.label_TreeResults.Name = "label_TreeResults";
			this.label_TreeResults.Size = new System.Drawing.Size(122, 17);
			this.label_TreeResults.TabIndex = 2;
			this.label_TreeResults.Text = "Results Tree View";
			// 
			// panel_Filters
			// 
			this.panel_Filters.Controls.Add(this.grpBox_CategoryFilters);
			this.panel_Filters.Controls.Add(this.grpBox_StatusFilters);
			this.panel_Filters.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel_Filters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel_Filters.Location = new System.Drawing.Point(0, 0);
			this.panel_Filters.Name = "panel_Filters";
			this.panel_Filters.Size = new System.Drawing.Size(155, 329);
			this.panel_Filters.TabIndex = 0;
			// 
			// grpBox_StatusFilters
			// 
			this.grpBox_StatusFilters.Controls.Add(this.cb_Inconclusive);
			this.grpBox_StatusFilters.Controls.Add(this.cb_Ignored);
			this.grpBox_StatusFilters.Controls.Add(this.cb_Failed);
			this.grpBox_StatusFilters.Controls.Add(this.cb_Passed);
			this.grpBox_StatusFilters.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpBox_StatusFilters.Location = new System.Drawing.Point(0, 0);
			this.grpBox_StatusFilters.Name = "grpBox_StatusFilters";
			this.grpBox_StatusFilters.Size = new System.Drawing.Size(155, 139);
			this.grpBox_StatusFilters.TabIndex = 0;
			this.grpBox_StatusFilters.TabStop = false;
			this.grpBox_StatusFilters.Text = "Status Filters";
			// 
			// cb_Passed
			// 
			this.cb_Passed.AutoSize = true;
			this.cb_Passed.Location = new System.Drawing.Point(7, 24);
			this.cb_Passed.Name = "cb_Passed";
			this.cb_Passed.Size = new System.Drawing.Size(74, 21);
			this.cb_Passed.TabIndex = 0;
			this.cb_Passed.Text = "Passed";
			this.cb_Passed.UseVisualStyleBackColor = true;
			// 
			// cb_Failed
			// 
			this.cb_Failed.AutoSize = true;
			this.cb_Failed.Location = new System.Drawing.Point(7, 52);
			this.cb_Failed.Name = "cb_Failed";
			this.cb_Failed.Size = new System.Drawing.Size(65, 21);
			this.cb_Failed.TabIndex = 1;
			this.cb_Failed.Text = "Failed";
			this.cb_Failed.UseVisualStyleBackColor = true;
			// 
			// cb_Ignored
			// 
			this.cb_Ignored.AutoSize = true;
			this.cb_Ignored.Location = new System.Drawing.Point(7, 80);
			this.cb_Ignored.Name = "cb_Ignored";
			this.cb_Ignored.Size = new System.Drawing.Size(75, 21);
			this.cb_Ignored.TabIndex = 2;
			this.cb_Ignored.Text = "Ignored";
			this.cb_Ignored.UseVisualStyleBackColor = true;
			// 
			// cb_Inconclusive
			// 
			this.cb_Inconclusive.AutoSize = true;
			this.cb_Inconclusive.Location = new System.Drawing.Point(7, 108);
			this.cb_Inconclusive.Name = "cb_Inconclusive";
			this.cb_Inconclusive.Size = new System.Drawing.Size(104, 21);
			this.cb_Inconclusive.TabIndex = 3;
			this.cb_Inconclusive.Text = "Inconclusive";
			this.cb_Inconclusive.UseVisualStyleBackColor = true;
			// 
			// grpBox_CategoryFilters
			// 
			this.grpBox_CategoryFilters.Controls.Add(this.clb_Categories);
			this.grpBox_CategoryFilters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpBox_CategoryFilters.Location = new System.Drawing.Point(0, 139);
			this.grpBox_CategoryFilters.Name = "grpBox_CategoryFilters";
			this.grpBox_CategoryFilters.Size = new System.Drawing.Size(155, 190);
			this.grpBox_CategoryFilters.TabIndex = 1;
			this.grpBox_CategoryFilters.TabStop = false;
			this.grpBox_CategoryFilters.Text = "Category Filters";
			// 
			// clb_Categories
			// 
			this.clb_Categories.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clb_Categories.FormattingEnabled = true;
			this.clb_Categories.Location = new System.Drawing.Point(3, 19);
			this.clb_Categories.Name = "clb_Categories";
			this.clb_Categories.Size = new System.Drawing.Size(149, 168);
			this.clb_Categories.TabIndex = 0;
			// 
			// form_Viewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(996, 661);
			this.Controls.Add(this.splitContainer_Main);
			this.Controls.Add(this.ms_viewerMenu);
			this.MainMenuStrip = this.ms_viewerMenu;
			this.Name = "form_Viewer";
			this.Text = "Test Results Viewer";
			this.Load += new System.EventHandler(this.TestResultsViewer_Load);
			this.ms_viewerMenu.ResumeLayout(false);
			this.ms_viewerMenu.PerformLayout();
			this.panel_NodeName.ResumeLayout(false);
			this.panel_NodeName.PerformLayout();
			this.splitContainer_Main.Panel1.ResumeLayout(false);
			this.splitContainer_Main.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
			this.splitContainer_Main.ResumeLayout(false);
			this.splitContainer_Left.Panel1.ResumeLayout(false);
			this.splitContainer_Left.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Left)).EndInit();
			this.splitContainer_Left.ResumeLayout(false);
			this.panel_TreeResultsHeader.ResumeLayout(false);
			this.panel_TreeResultsHeader.PerformLayout();
			this.panel_Filters.ResumeLayout(false);
			this.grpBox_StatusFilters.ResumeLayout(false);
			this.grpBox_StatusFilters.PerformLayout();
			this.grpBox_CategoryFilters.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip ms_viewerMenu;
		private System.Windows.Forms.ToolStripMenuItem msi_File;
		private System.Windows.Forms.ToolStripMenuItem msi_File_Open;
		private System.Windows.Forms.TreeView TestStatusTreeView;
		private System.Windows.Forms.Panel panel_NodeName;
		private System.Windows.Forms.Label label_NodeName;
		private System.Windows.Forms.Panel panel_TestDetail;
		private System.Windows.Forms.SplitContainer splitContainer_Main;
		private System.Windows.Forms.SplitContainer splitContainer_Left;
		private System.Windows.Forms.Panel panel_TreeResultsHeader;
		private System.Windows.Forms.Label label_TreeResults;
		private System.Windows.Forms.Panel panel_Filters;
		private System.Windows.Forms.GroupBox grpBox_StatusFilters;
		private System.Windows.Forms.CheckBox cb_Inconclusive;
		private System.Windows.Forms.CheckBox cb_Ignored;
		private System.Windows.Forms.CheckBox cb_Failed;
		private System.Windows.Forms.CheckBox cb_Passed;
		private System.Windows.Forms.GroupBox grpBox_CategoryFilters;
		private System.Windows.Forms.CheckedListBox clb_Categories;
	}
}

