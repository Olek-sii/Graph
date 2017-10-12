using System;
using System.Collections.Generic;

namespace Graph
{
	public class GraphMatrix : IGraph
	{
		private Dictionary<Vertex, Dictionary<Vertex, Edge>> _matrix = new Dictionary<Vertex, Dictionary<Vertex, Edge>>();

		public int VertexCount => _matrix.Count;
		public int EdgeCount
		{
			get
			{
				int count = 0;
				foreach (var item in _matrix)
				{
					foreach (var item2 in item.Value)
					{
						if (item2.Value != null)
							count++;
					}
				}
				return count;
			}
		}

		public void AddEdge(string v1, string v2, int w)
		{
			Vertex vertex1 = GetVertexRef(v1);
			Vertex vertex2 = GetVertexRef(v2);

			if (vertex1 == null)
			{
				AddVertex(v1);
				vertex1 = GetVertexRef(v1);
			}

			if (vertex2 == null)
			{
				AddVertex(v2);
				vertex2 = GetVertexRef(v2);
			}

			_matrix[vertex1][vertex2] = new Edge(vertex1, vertex2, w);
		}

		public void AddVertex(string str)
		{
			if (GetVertexRef(str) != null)
				return;

			Vertex vertex = new Vertex(str);
			Dictionary<Vertex, Edge> dictionary = new Dictionary<Vertex, Edge>();
			foreach (var pair in _matrix)
			{
				pair.Value.Add(vertex, null);
				dictionary.Add(pair.Key, null);
			}
			dictionary.Add(vertex, null);
			_matrix.Add(vertex, dictionary);
		}

		public void Clear()
		{
			_matrix.Clear();
		}

		public int DelEdge(string v1, string v2)
		{
			Vertex vertex1 = GetVertexRef(v1);
			Vertex vertex2 = GetVertexRef(v2);

			if (vertex1 == null || vertex2 == null)
				throw new KeyNotFoundException();

			int w = _matrix[vertex1][vertex2].W;
			_matrix[vertex1][vertex2] = null;
			return w;
		}

		public void DelVertex(string str)
		{
			Vertex vertex = GetVertexRef(str);

			if (vertex == null)
				throw new KeyNotFoundException();

			_matrix.Remove(vertex);
			foreach (var pair in _matrix)
			{
				pair.Value.Remove(vertex);
			}
		}

		public int GetEdge(string v1, string v2)
		{
			Edge edge = GetEdgeRef(v1, v2);
			if (edge == null)
				throw new KeyNotFoundException();
			return edge.W;
		}

		public void Print()
		{
			Console.Write("     ");
			foreach (var pair in _matrix)
			{
				Console.Write("{0, -4}|", pair.Key.Data);
			}
			Console.Write("\n     ");
			foreach (var pair in _matrix)
			{
				Console.Write("-----");
			}
			Console.WriteLine();
			foreach (var pair in _matrix)
			{
				Console.Write("{0, -4}|", pair.Key.Data);
				foreach (var pair2 in pair.Value)
				{
					if (pair2.Value == null)
						Console.Write("{0, -5}", " ");
					else
						Console.Write("{0, -5}", pair2.Value.W);
				}
				Console.WriteLine();
			}
		}

		public void SetEdge(string v1, string v2, int w)
		{
			Edge edge = GetEdgeRef(v1, v2);
			if (edge == null)
				throw new KeyNotFoundException();

			edge.W = w;
		}

		private Edge GetEdgeRef(string v1, string v2)
		{
			Vertex vertex1 = GetVertexRef(v1);
			Vertex vertex2 = GetVertexRef(v2);

			if (vertex1 == null || vertex2 == null)
				return null;

			return _matrix[vertex1][vertex2];
		}

		private Vertex GetVertexRef(string data)
		{
			Vertex vertex = null;
			foreach (var item in _matrix)
			{
				if (item.Key.Data == data)
					vertex = item.Key;
			}
			return vertex;
		}
	}
}
