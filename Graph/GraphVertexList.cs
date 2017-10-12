using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
	public class GraphVertexList : IGraph
	{
		private Dictionary<Vertex, Dictionary<Vertex, Edge>> _vertices = new Dictionary<Vertex, Dictionary<Vertex, Edge>>();

		public int VertexCount => _vertices.Count;
		public int EdgeCount
		{
			get
			{
				int count = 0;
				foreach (var item in _vertices)
				{
					foreach (var item2 in item.Value)
					{
						if (GetEdgeRef(item.Key.Data, item2.Key.Data) != null)
							count++;
					}
				}
				return count;
			}
		}

		public void Print()
		{
			Console.WriteLine("Vertices: {0}, Edges: {1}", VertexCount, EdgeCount);
			foreach (var keyValuePair in _vertices)
			{
				Console.WriteLine(keyValuePair.Key.Data);
				foreach (var item in keyValuePair.Value)
				{
					Console.WriteLine("---> {0}: {1}", item.Key.Data, item.Value.W);
				}
			}
		}

		public void AddEdge(string from, string to, int w)
		{
			Vertex vertexFrom = _vertices.Keys.FirstOrDefault((x) => x.Data == from);
			Vertex vertexTo = _vertices.Keys.FirstOrDefault((x) => x.Data == to);

			if (vertexFrom == null)
			{
				AddVertex(from);
				vertexFrom = _vertices.Keys.First((x) => x.Data == from);
			}

			if (vertexTo == null)
			{
				AddVertex(to);
				vertexTo = _vertices.Keys.FirstOrDefault((x) => x.Data == to);
			}


			if (GetEdgeRef(from,to) == null)
			{
				Edge edge = new Edge(vertexFrom, vertexTo, w);
				_vertices[vertexFrom].Add(vertexTo, edge);
			}
		}

		public void AddVertex(string str)
		{
			if (GetVertexRef(str) == null)
				_vertices.Add(new Vertex(str), new Dictionary<Vertex, Edge>());
		}

		public int DelEdge(string v1, string v2)
		{
			Edge edge = GetEdgeRef(v1,v2);
			if (edge == null)
				throw new KeyNotFoundException();

			int w = edge.W;
			_vertices[edge.V1].Remove(edge.V2);
			return w;
		}

		public void DelVertex(string str)
		{
			Vertex vertex = GetVertexRef(str);
			if (vertex == null)
				throw new KeyNotFoundException();

			_vertices.Remove(vertex);
			foreach (var item in _vertices)
			{
				item.Value.Remove(vertex);
			}
		}

		private Edge GetEdgeRef(string v1, string v2)
		{
			Edge edge = null;
			foreach (var pair in _vertices)
			{
				if (pair.Key.Data == v1)
				{
					foreach (var pair2 in pair.Value)
					{
						if (pair2.Key.Data == v2)
							edge = pair2.Value;
					}
				}
			}
			return edge;
		}

		private Vertex GetVertexRef(string data)
		{
			Vertex vertex = null;
			foreach (var item in _vertices)
			{
				if (item.Key.Data == data)
					vertex = item.Key;
			}
			return vertex;
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
	}
}
