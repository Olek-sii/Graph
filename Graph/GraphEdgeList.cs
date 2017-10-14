//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Graph
//{
//	public class GraphEdgeList : IGraph
//	{
//		private List<Edge> _edges = new List<Edge>();
//		private List<Vertex> _verticesWithoutEdges = new List<Vertex>();

//		public int VertexCount
//		{
//			get
//			{
//				HashSet<Vertex> visitedVertices = new HashSet<Vertex>();
//				foreach (Edge edges in _edges)
//				{
//					visitedVertices.Add(edges.V1);
//					visitedVertices.Add(edges.V2);
//				}
//				return visitedVertices.Count + _verticesWithoutEdges.Count;
//			}

//		}

//		public int EdgeCount => _edges.Count;

//		public void AddEdge(string from, string to, int w)
//		{
//			throw new NotImplementedException();
//		}

//		public void AddVertex(string str)
//		{
//			throw new NotImplementedException();
//		}

//		public void Clear()
//		{
//			throw new NotImplementedException();
//		}

//		public int DelEdge(string v1, string v2)
//		{
//			throw new NotImplementedException();
//		}

//		public void DelVertex(string str)
//		{
//			throw new NotImplementedException();
//		}

//		public int GetEdge(string v1, string v2)
//		{
//			throw new NotImplementedException();
//		}

//		public void Print()
//		{
//			throw new NotImplementedException();
//		}

//		public void SetEdge(string v1, string v2, int w)
//		{
//			throw new NotImplementedException();
//		}
//	}
//}
