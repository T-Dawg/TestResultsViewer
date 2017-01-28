using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TestResultsViewer
{
	public partial class form_Viewer : Form
	{
		public OpenFileDialog _FileDialog;

		private Results _ResultsMaster;
		private Results _FilteredResults;
		private Parser _ResultsParser;
		private SortedSet<string> _CategorySet;

		public form_Viewer()
		{
			InitializeComponent();
			_CategorySet = new SortedSet<string>();
		}

		//Loads the results from the selected xml file
		private void LoadResults(string fileName)
		{
			_ResultsParser = new Parser(fileName);
			_ResultsMaster = _ResultsParser.Results();
			_FilteredResults = _ResultsMaster;
			PopulateTreeView();
			PopulateCategoriesList();
		}

		//populates the Test Status Tree View
		private void PopulateTreeView()
		{
			TestStatusTreeView.BeginUpdate(); //disable drawing of the tree view
			TestStatusTreeView.Nodes.Clear();
			//find the first TestSuite in the hierarchy that will have more than 1 sub node
			var startPoint = _FilteredResults.TestRun.TestSuite;
			while (startPoint.TestSuites != null && startPoint.TestSuites.Count <= 1 && (startPoint.TestCases?.Count ?? 0) == 0)
			{
				startPoint = startPoint.TestSuites[0];
			}
			TestStatusTreeView.Nodes.Add(MakeNode(startPoint)); //add this subtree
			TestStatusTreeView.Nodes[0].Text = startPoint.FullName; //reset the node text to include all the skipped TestSuites
			TestStatusTreeView.EndUpdate(); //enable and draw the tree view
		}

		//populates the categories list from the resutls master
		private void PopulateCategoriesList()
		{
			_CategorySet.Clear();
			AddCategories(_ResultsMaster.TestRun.TestSuite);
			clb_Categories.BeginUpdate();
			clb_Categories.Items.Clear();
			foreach (var category in _CategorySet)
			{
				clb_Categories.Items.Add(category, true);
			}

			clb_Categories.EndUpdate();
		}

		//recursively adds categories to the master category set from a TestSuite
		private void AddCategories(TestSuite testSuite)
		{
			foreach (var p in testSuite.Properties)
			{
				if (p.Name == "Category")
				{
					_CategorySet.Add(p.Value);
				}
			}

			foreach (var ts in testSuite.TestSuites)
			{
				AddCategories(ts);
			}
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

		//gets a corresponding muted color from an input color
		private Color GetMutedColor(Color color)
		{
			if (color == Color.Red) return Color.Pink;
			else if (color == Color.Green) return Color.LightGreen;
			else if (color == Color.Yellow) return Color.LightYellow;
			else if (color == Color.DimGray) return Color.LightGray;
			else return color;
		}

		#region Events
		private void TestResultsViewer_Load(object sender, EventArgs e)
		{
			_FileDialog = new OpenFileDialog();
			_FileDialog.RestoreDirectory = true;
			_FileDialog.Multiselect = false;
			_FileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
			_FileDialog.CheckFileExists = true;
		}
				
		private void msi_File_Open_Click(object sender, EventArgs e)
		{
			if (_FileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					LoadResults(_FileDialog.FileName);
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
			panel_NodeName.BackColor = GetMutedColor(e.Node.ForeColor);
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
