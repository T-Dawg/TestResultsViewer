using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TestResultsViewer
{
	public partial class form_Viewer : Form
	{
		public OpenFileDialog FileDialog;
		public Results Results;
		public Parser ResultsParser;

		public form_Viewer()
		{
			InitializeComponent();
		}

		//Loads the results from the selected xml file
		private void LoadResults(string fileName)
		{
			ResultsParser = new Parser(fileName);
			Results = ResultsParser.Results();
			TestStatusTreeView.BeginUpdate(); //disable drawing of the tree view
			//find the first TestSuite in the hierarchy that will have more than 1 sub node
			var startPoint = Results.TestRun.TestSuite;
			while (startPoint.TestSuites != null && startPoint.TestSuites.Count <= 1 && (startPoint.TestCases?.Count ?? 0) == 0)
			{
				startPoint = startPoint.TestSuites[0];
			}
			TestStatusTreeView.Nodes.Add(MakeNode(startPoint)); //add this subtree
			TestStatusTreeView.Nodes[0].Text = startPoint.FullName; //reset the node text to include all the skipped TestSuites
			TestStatusTreeView.EndUpdate(); //enable and draw the tree view
		}

		//makes a TreeNode from a supplied TestSuite and its decendants
		private TestSuiteNode MakeNode(TestSuite testSuite)
		{
			var node = new TestSuiteNode(testSuite);
			node.ForeColor = GetNodeColor(testSuite.Passed, testSuite.Failed, testSuite.Inconclusive, testSuite.Skipped);
			node.ToolTipText = "Passed: " + testSuite.Passed + ", Failed: " + testSuite.Failed +
				", Skipped: " + testSuite.Skipped + ", Inconclusive: " + testSuite.Inconclusive;
			foreach (var ts in testSuite.TestSuites)
			{
				node.Nodes.Add(MakeNode(ts)); //add this subtree
			}

			foreach (var tc in testSuite.TestCases)
			{
				node.Nodes.Add(MakeNode(tc)); //add the test case
			}

			return node;
		}

		//makes a TreeNode from a supplied TestCase
		private TestCaseNode MakeNode(TestCase testCase)
		{
			var node = new TestCaseNode(testCase);
			node.ForeColor = GetNodeColor(testCase.Result);
			return node;
		}

		//determies the color of a node based on status of tests
		private Color GetNodeColor(int passed, int failed, int inconclusive, int skipped)
		{
			if (failed > 0)
			{
				return Color.Red;
			}
			else if (passed > 0)
			{
				return Color.Green;
			}
			else if (skipped > 0)
			{
				return Color.DimGray;
			}
			else if (inconclusive > 0)
			{
				return Color.Yellow;
			}
			else
				return Color.DimGray;
		}

		//determines the color of a node based on the result string
		private Color GetNodeColor(string result)
		{
			switch (result.ToLower())
			{
				case "failed":
					return Color.Red;
				case "passed":
					return Color.Green;
				case "skipped":
					return Color.DimGray;
				default:
					return Color.Yellow;
			}
		}

		#region Events
		private void TestResultsViewer_Load(object sender, EventArgs e)
		{
			FileDialog = new OpenFileDialog();
			FileDialog.RestoreDirectory = true;
			FileDialog.Multiselect = false;
			FileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
			FileDialog.CheckFileExists = true;
		}
				
		private void msi_File_Open_Click(object sender, EventArgs e)
		{
			if (FileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					LoadResults(FileDialog.FileName);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error parsing file.\n" + ex.Message);
				}
			}
		}

		private void TestStatusTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			label_NodeName.Text = e.Node.Text;
			panel_NodeName.BackColor = e.Node.ForeColor;
			panel_TestDetail.Controls.Clear();
			var nodeType = e.Node.GetType();
			if (nodeType == typeof(TestSuiteNode))
			{
				
			}
			else if (nodeType == typeof(TestCaseNode))
			{
				var node = (TestCaseNode)e.Node;
				var textBox = new TextBox();
				textBox.Dock = DockStyle.Fill;
				textBox.Multiline = true;
				textBox.ScrollBars = ScrollBars.Vertical;
				textBox.AcceptsReturn = true;
				textBox.AcceptsTab = true;
				textBox.ReadOnly = true;
				textBox.BackColor = Color.White;
				textBox.Font = new Font("Microsoft Sans Serif", 10.0f);
				var lines = new List<string>();
				if (node.TestCase.Failure?.Message != null)
				{
					lines.AddRange(node.TestCase.Failure?.Message.Split('\n'));
				}
				
				if (node.TestCase.Failure?.StackTrace != null)
				{
					lines.Add(string.Empty);
					lines.Add("Stack Trace:");
					lines.AddRange(node.TestCase.Failure?.StackTrace.Split('\n'));
				}
								
				textBox.Lines = lines.ToArray();
				panel_TestDetail.Controls.Add(textBox);
			}
		}
		#endregion
	}
}
