using System.Windows.Forms;

namespace TestResultsViewer
{
	//this is a cusom System.Windows.Forms.TreeNode that stores test information in the node
	class TestCaseNode : TreeNode
	{
		public TestCase TestCase { get; set; }

		public TestCaseNode(TestCase tc)
			: base(tc.Name)
		{
			TestCase = tc;
		}
	}
}
