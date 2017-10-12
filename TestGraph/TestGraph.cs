using Graph;
using NUnit.Framework;

namespace TestGraph
{
	[TestFixture]
	public class TestGraph
	{
		private IGraph _graph;

		[SetUp]
		public void SetUp()
		{
			_graph = new GraphVertexList();
		}

		[Test]
		public void TestAddVertex()
		{
			_graph.AddVertex("qwerty");
			GraphVertexList result = new GraphVertexList();
			result.AddVertex("qwerty");
			Assert.AreEqual(result, _graph);
		}
	}
}
