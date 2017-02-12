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
		private SortedSet<string> _CheckedCategories;
		private EventHandler _StatusFilterClickHandler;
		private ItemCheckEventHandler _CategoryFilterClickHandler;

		public form_Viewer()
		{
			InitializeComponent();
			_CategorySet = new SortedSet<string>();
			_CheckedCategories = new SortedSet<string>();
			_StatusFilterClickHandler = new EventHandler(Begin_Filter_Event);
			_CategoryFilterClickHandler = new ItemCheckEventHandler(clb_Categories_ItemCheck);
		}

		//Loads the results from the selected xml file
		private void LoadResults(string fileName)
		{
			_ResultsParser = new Parser(fileName);
			_ResultsMaster = _ResultsParser.Results();
			_FilteredResults = new Results(_ResultsMaster);
			PopulateTreeView();
			PopulateCategoriesList();
			cb_Passed.Checked = true;
			cb_Failed.Checked = true;
			cb_Ignored.Checked = true;
			cb_Inconclusive.Checked = true;
			cb_Passed.Enabled = true;
			cb_Failed.Enabled = true;
			cb_Ignored.Enabled = true;
			cb_Inconclusive.Enabled = true;
		}

		//Filters the results set
		private void FilterResults()
		{
			if (_ResultsMaster == null) return;

			_FilteredResults = new Results(_ResultsMaster);
			ApplyFilters(_FilteredResults.TestRun.TestSuite);
			PopulateTreeView();
		}

		private bool ApplyFilters(TestSuite testSuite)
		{
			testSuite.TestSuites.RemoveAll(ts => !ApplyFilters(ts));
			testSuite.TestCases.RemoveAll(tc => !ApplyFilters(tc));

			return (testSuite.TestSuites.Count > 0 || testSuite.TestCases.Count > 0) &&
				(_CategorySet.Count == 0 || ContainsAnIcludedCategory(testSuite));
		}

		private bool ApplyFilters(TestCase tc)
		{
			switch (tc.Result.ToLower())
			{
				case "failed":
					return cb_Failed.Checked;
				case "passed":
					return cb_Passed.Checked;
				case "skipped":
					return cb_Ignored.Checked;
				default:
					return cb_Inconclusive.Checked;
			}
		}

		//checks if a given test Suite has an included category somewhere in its subtree
		private bool ContainsAnIcludedCategory(TestSuite testSuite)
		{
			//test the current node
			foreach (var p in testSuite.Properties)
			{
				if (p.Name == "Category" && _CheckedCategories.Contains(p.Value))
				{
					return true;
				}
			}

			//test the any child node contains an included category
			foreach (var ts in testSuite.TestSuites)
			{
				if (ContainsAnIcludedCategory(ts))
				{
					return true;
				}
			}

			return false;
		}

		//populates the Test Status Tree View
		private void PopulateTreeView()
		{
			TestStatusTreeView.BeginUpdate(); //disable drawing of the tree view
			//find the first TestSuite in the hierarchy that will have more than 1 sub node
			var startPoint = _FilteredResults.TestRun.TestSuite;
			while (startPoint.TestSuites != null && startPoint.TestSuites.Count == 1 && (startPoint.TestCases?.Count ?? 0) == 0)
			{
				startPoint = startPoint.TestSuites[0];
			}

			if (startPoint.TestSuites.Count == 0 && startPoint.TestCases.Count == 0)
			{
				//empty results
				TestStatusTreeView.Nodes.Clear();
				TestStatusTreeView.Nodes.Add("No results to display");
			}
			else if (TestStatusTreeView.Nodes.Count == 0 ||
				TestStatusTreeView.Nodes[0].Text != startPoint.FullName)
			{
				//this is new test results load or the inital node has changed
				TestStatusTreeView.Nodes.Clear();
				TestStatusTreeView.Nodes.Add(MakeNode(startPoint)); //add this subtree
				TestStatusTreeView.Nodes[0].Text = startPoint.FullName; //reset the node text to include all the skipped TestSuites
			}
			else
			{
				//this is a test results filter update
				UpdateTreeViewNode(TestStatusTreeView.Nodes[0], startPoint);
				TestStatusTreeView.Nodes[0].Text = startPoint.FullName;
			}

			TestStatusTreeView.EndUpdate(); //enable and draw the tree view
		}

		//populates the categories list from the resutls master
		private void PopulateCategoriesList()
		{
			clb_Categories.ItemCheck -= _CategoryFilterClickHandler;
			_CategorySet.Clear();
			AddCategories(_ResultsMaster.TestRun.TestSuite);
			cb_SelectAllCategories.Checked = true;
			clb_Categories.BeginUpdate();
			clb_Categories.Items.Clear();
			foreach (var category in _CategorySet)
			{
				clb_Categories.Items.Add(category, true);
			}

			clb_Categories.EndUpdate();
			clb_Categories.ItemCheck += _CategoryFilterClickHandler;
			if (clb_Categories.Items.Count > 0)
			{
				cb_SelectAllCategories.Enabled = true;
			}
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

		private void UpdateTreeViewNode(TreeNode currentNode, TestSuite testSuite)
		{
			//delete non-matching nodes
			List<TreeNode> nodesToDelete = new List<TreeNode>();
			List<TestSuite> matchedTestSuites = new List<TestSuite>();
			List<TestCase> matchedTestCases = new List<TestCase>();
			SortedSet<TestSuite> testSuitesToAdd = new SortedSet<TestSuite>();
			SortedSet<TestCase> testCasesToAdd = new SortedSet<TestCase>();

			foreach (TreeNode node in currentNode.Nodes)
			{
				var deleteThisNode = true;
				foreach (var ts in testSuite.TestSuites)
				{
					if (ts.Name == node.Text) //update this node
					{
						UpdateTreeViewNode(node, ts);
						matchedTestSuites.Add(ts);
						deleteThisNode = false;
					}
					else //add a new node for this test suite
					{
						testSuitesToAdd.Add(ts);
					}
				}

				foreach (var tc in testSuite.TestCases)
				{
					if (tc.Name == node.Text)
					{
						matchedTestCases.Add(tc);
						deleteThisNode = false;
					}
					else
					{
						testCasesToAdd.Add(tc);
					}
				}

				if (deleteThisNode)
				{
					nodesToDelete.Add(node);
				}
			}

			//prune nodes from the tree that were filtered out
			foreach(var node in nodesToDelete)
			{
				currentNode.Nodes.Remove(node);
			}

			//add any necessary new nodes to the tree
			testSuitesToAdd.RemoveWhere(ts => matchedTestSuites.Exists(m => m == ts));
			foreach(var ts in testSuitesToAdd)
			{
				currentNode.Nodes.Add(MakeNode(ts));
			}

			testCasesToAdd.RemoveWhere(tc => matchedTestCases.Exists(m => m == tc));
			foreach(var tc in testCasesToAdd)
			{
				currentNode.Nodes.Add(MakeNode(tc));
			}
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

		private void GetCheckedCategorySet()
		{
			_CheckedCategories.Clear();
			foreach (var item in clb_Categories.CheckedItems)
			{
				_CheckedCategories.Add(item.ToString());
			}
		}

		#region Events
		private void TestResultsViewer_Load(object sender, EventArgs e)
		{
			_FileDialog = new OpenFileDialog();
			_FileDialog.RestoreDirectory = true;
			_FileDialog.Multiselect = false;
			_FileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
			_FileDialog.CheckFileExists = true;

			cb_Passed.Click += _StatusFilterClickHandler;
			cb_Failed.Click += _StatusFilterClickHandler;
			cb_Ignored.Click += _StatusFilterClickHandler;
			cb_Inconclusive.Click += _StatusFilterClickHandler;
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

			tb_Details.Clear();
			var lines = new List<string>();
			var nodeType = e.Node.GetType();
			if (nodeType == typeof(TestSuiteNode))
			{
				var node = (TestSuiteNode)e.Node;
				var description = node.TestSuite.Properties.Find(p => p.Name == "Description");
				if (description != null)
				{
					lines.Add(description.Value);
					lines.Add(string.Empty);
				}

				if (node.TestSuite.Result == "Failed")
				{
					lines.Add(node.TestSuite.Failure?.Message ?? string.Empty);
				}
				else if (node.TestSuite.Result == "Skipped")
				{
					lines.Add(node.TestSuite.Reason?.Message ?? string.Empty);
				}
			}
			else if (nodeType == typeof(TestCaseNode))
			{
				var node = (TestCaseNode)e.Node;
				if (node.TestCase.Failure?.Message != null)
				{
					lines.AddRange(node.TestCase.Failure.Message.Split('\n'));
				}
				
				if (node.TestCase.Failure?.StackTrace != null)
				{
					lines.Add(string.Empty);
					lines.Add("Stack Trace:");
					lines.AddRange(node.TestCase.Failure.StackTrace.Split('\n'));
				}

				if (node.TestCase.Reason?.Message != null)
				{
					lines.Add(node.TestCase.Reason.Message);
				}
			}

			tb_Details.Lines = lines.ToArray();
		}

		private void Begin_Filter_Event(object sender, EventArgs e)
		{
			GetCheckedCategorySet();
			FilterResults();
		}

		private void clb_Categories_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			GetCheckedCategorySet();
			if (e.NewValue == CheckState.Checked)
			{
				_CheckedCategories.Add(clb_Categories.Items[e.Index].ToString());
			}
			else if (e.NewValue == CheckState.Unchecked)
			{
				_CheckedCategories.Remove(clb_Categories.Items[e.Index].ToString());
			}

			FilterResults();
		}

		private void cb_SelectAllCategories_Click(object sender, EventArgs e)
		{
			clb_Categories.BeginUpdate();
			clb_Categories.ItemCheck -= _CategoryFilterClickHandler;
			for (int i = 0; i < clb_Categories.Items.Count; ++i)
			{
				clb_Categories.SetItemChecked(i, cb_SelectAllCategories.Checked);
			}

			clb_Categories.EndUpdate();
			clb_Categories.ItemCheck += _CategoryFilterClickHandler;
			GetCheckedCategorySet();
			FilterResults();
		}
		#endregion
	}
}
