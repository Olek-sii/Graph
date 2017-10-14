using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
	public class GraphVertexList : IGraph
	{
		private class Edge
		{
			Vertex _from;
			Vertex _to;
			int _w;

			public int W { get => _w; set => _w = value; }
			public Vertex V1 { get => _from; }
			public Vertex V2 { get => _to; }


			public Edge(Vertex from, Vertex to, int w)
			{
				_from = from;
				_to = to;
				_w = w;
			}
		}

		private class Vertex
		{
			public string Data { get; set; }
			public List<Edge> Edges = new List<Edge>();

			public Vertex(string data)
			{
				Data = data;
			}
		}

		private List<Vertex> _vertices = new List<Vertex>();

		public int VertexCount => _vertices.Count;
		public int EdgeCount
		{
			get
			{
				HashSet<Edge> visitedEdges = new HashSet<Edge>();
				foreach (Vertex vertex in _vertices)
				{
					foreach (Edge edge in vertex.Edges)
					{
						visitedEdges.Add(edge);
					}
				}
				return visitedEdges.Count;
			}
		}

		public void Print()
		{
			Console.WriteLine("Vertices: {0}, Edges: {1}", VertexCount, EdgeCount);
			foreach (Vertex vertex in _vertices)
			{
				Console.WriteLine(vertex.Data);
				foreach (Edge edge in vertex.Edges)
				{
					Console.WriteLine("---> {0}: {1}", edge.V2.Data, edge.W);
				}
			}
		}

		public void AddEdge(string from, string to, int w)
		{
			Vertex vertexFrom = _vertices.FirstOrDefault((x) => x.Data == from);
			Vertex vertexTo = _vertices.FirstOrDefault((x) => x.Data == to);

			if (vertexFrom == null)
			{
				AddVertex(from);
				vertexFrom = _vertices.FirstOrDefault((x) => x.Data == from);
			}

			if (vertexTo == null)
			{
				AddVertex(to);
				vertexTo = _vertices.FirstOrDefault((x) => x.Data == to);
			}

			if (GetEdgeRef(from,to) == null)
			{
				Edge edge = new Edge(vertexFrom, vertexTo, w);
				vertexFrom.Edges.Add(edge);
			}
		}

		public void AddVertex(string str)
		{
			if (GetVertexRef(str) == null)
				_vertices.Add(new Vertex(str));
		}

		public int DelEdge(string v1, string v2)
		{
			Edge edge = GetEdgeRef(v1,v2);
			if (edge == null)
				throw new KeyNotFoundException();

			int w = edge.W;
			edge.V1.Edges.Remove(edge);
			return w;
		}

		public void DelVertex(string str)
		{
			Vertex vertex = GetVertexRef(str);
			if (vertex == null)
				throw new KeyNotFoundException();

			_vertices.Remove(vertex);
			foreach (Vertex v in _vertices)
			{
				v.Edges.RemoveAll((x) => x.V2 == vertex);
			}
		}

		private Edge GetEdgeRef(string v1, string v2)
		{
			Edge result = null;
			Vertex from = GetVertexRef(v1);
			Vertex to = GetVertexRef(v2);

			if (from == null || to == null)
				return null;

			foreach (Edge edge in from.Edges)
			{
				if (edge.V2 == to)
					result = edge;
			}

			return result;
		}

		private Vertex GetVertexRef(string data)
		{
			return _vertices.FirstOrDefault((x) => x.Data == data);
		}

		public int GetEdge(string v1, string v2)
		{
			Edge edge = GetEdgeRef(v1, v2);
			if (edge == null)
				throw new KeyNotFoundException();
			return edge.W;
		}

		public void SetEdge(string v1, string v2, int w)
		{
			Edge edge = GetEdgeRef(v1, v2);
			if (edge == null)
				throw new KeyNotFoundException();
			edge.W = w;
		}

		public void Clear()
		{
			_vertices.Clear();
		}

		public int GetInputEdgeCount(string v)
		{
			Vertex vertex = GetVertexRef(v);
			if (vertex == null)
				throw new KeyNotFoundException();

			int count = 0;
			foreach (Vertex ver in _vertices)
			{
				count += ver.Edges.FindAll((x) => x.V2.Data == v).Count;
			}
			return count;
		}

		public int GetOutputEdgeCount(string v)
		{
			Vertex vertex = GetVertexRef(v);
			if (vertex == null)
				throw new KeyNotFoundException();

			return vertex.Edges.Count;
		}

		public List<string> GetInputVertexNames(string v)
		{
			Vertex vertex = GetVertexRef(v);
			if (vertex == null)
				throw new KeyNotFoundException();

			List<string> result = new List<string>();
			foreach (Vertex ver in _vertices)
			{
				foreach (Edge edge in ver.Edges)
				{
					if (edge.V2.Data == v)
						result.Add(edge.V1.Data);
				}
			}
			return result;
		}

		public List<string> GetOutputVertexNames(string v)
		{
			Vertex vertex = GetVertexRef(v);
			if (vertex == null)
				throw new KeyNotFoundException();

			List<string> result = new List<string>();
			foreach (Edge edge in vertex.Edges)
			{
				result.Add(edge.V2.Data);
			}
			return result;
		}
	}
}
