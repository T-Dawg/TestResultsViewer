using System.Windows.Forms;

namespace TestResultsViewer
{
	//this is a cusom System.Windows.Forms.TreeNode that stores test information in the node
	class TestSuiteNode : TreeNode
	{
		public TestSuite TestSuite { get; set; }

		public TestSuiteNode(TestSuite ts)
			: base(ts.Name)
		{
			TestSuite = ts;
		}
	}
}
