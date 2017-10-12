using Graph;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestGraph
{
	[TestFixture(typeof(GraphVertexList))]
	[TestFixture(typeof(GraphMatrix))]
	//[TestFixture(typeof(GraphEdgeList))]
	public class ListNUnitTests<TGraph> where TGraph : IGraph, new()
	{
		IGraph _graph = new TGraph();

		[SetUp]
		public void SetUp()
		{
			_graph.Clear();
		}

		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(5)]
		public void TestAddVertices(int n)
		{
			for (int i = 0; i < n; i++)
			{
				_graph.AddVertex(i.ToString());
				_graph.AddVertex(i.ToString());
			}

			Assert.AreEqual(n, _graph.VertexCount);
			Assert.AreEqual(0, _graph.EdgeCount);
		}

		[Test]
		public void TestDelVertex()
		{
			for (int i = 0; i < 5; i++)
			{
				_graph.AddVertex(i.ToString());
			}
			_graph.AddEdge("0", "3", 4);
			_graph.AddEdge("3", "4", 5);
			_graph.DelVertex("3");
			Assert.AreEqual(4, _graph.VertexCount);
			Assert.AreEqual(0, _graph.EdgeCount);
		}

		[Test]
		public void TestDelVertexEx()
		{
			Assert.Throws<KeyNotFoundException>(() => _graph.DelVertex("6"));
		}

		[Test]
		public void TestAddEdge()
		{
			_graph.AddVertex("-1");
			_graph.AddEdge("-1", "-2", 50);

			_graph.AddVertex("1");
			_graph.AddEdge("-1", "1", 5);

			Assert.AreEqual(3, _graph.VertexCount);
			Assert.AreEqual(2, _graph.EdgeCount);
		}

		[Test]
		public void TestDelEdge()
		{
			for (int i = 0; i < 5; i++)
			{
				_graph.AddVertex(i.ToString());
			}
			_graph.AddEdge("0", "1", 5);
			_graph.AddEdge("0", "2", 4);
			int w = _graph.DelEdge("0","1");
			Assert.AreEqual(5, _graph.VertexCount);
			Assert.AreEqual(1, _graph.EdgeCount);
			Assert.AreEqual(5, w);
		}

		[Test]
		public void TestDelEdgeEx()
		{
			Assert.Throws<KeyNotFoundException>(() => _graph.DelEdge("6", "7"));
		}

		[Test]
		public void TestGetEdge()
		{
			for (int i = 0; i < 5; i++)
			{
				_graph.AddVertex(i.ToString());
			}
			_graph.AddEdge("0", "1", 5);
			_graph.AddEdge("0", "2", 4);
			int w = _graph.GetEdge("0", "1");
			Assert.AreEqual(5, _graph.VertexCount);
			Assert.AreEqual(2, _graph.EdgeCount);
			Assert.AreEqual(5, w);
		}

		[Test]
		public void TestGetEdgeEx()
		{
			Assert.Throws<KeyNotFoundException>(() => _graph.GetEdge("6", "7"));
		}

		[Test]
		public void TestSetEdge()
		{
			for (int i = 0; i < 5; i++)
			{
				_graph.AddVertex(i.ToString());
			}
			_graph.AddEdge("0", "1", 5);
			_graph.AddEdge("0", "2", 4);
			_graph.SetEdge("0", "1", 6);
			Assert.AreEqual(5, _graph.VertexCount);
			Assert.AreEqual(2, _graph.EdgeCount);
			Assert.AreEqual(6, _graph.GetEdge("0","1"));
		}

		[Test]
		public void TestSetEdgeEx()
		{
			Assert.Throws<KeyNotFoundException>(() => _graph.SetEdge("6", "7", 1));
		}
	}
}
