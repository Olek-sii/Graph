using Graph;
using NUnit.Framework;

namespace TestGraph
{
	[TestFixture(typeof(GraphVertexList))]
	public class ListNUnitTests<TGraph> where TGraph : IGraph, new()
	{
		IGraph _graph = new TGraph();

		[SetUp]
		public void SetUp()
		{
			_graph.Clear();
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
