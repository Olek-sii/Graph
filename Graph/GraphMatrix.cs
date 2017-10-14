using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
	public class GraphMatrix : IGraph
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

			public Vertex(string data)
			{
				Data = data;
			}
		}

		private static readonly int _Size = 25;
		private List<Vertex> _vertices = new List<Vertex>();
		private Edge[,] _matrix = new Edge[_Size, _Size];

		public int VertexCount => _vertices.Count;
		public int EdgeCount
		{
			get
			{
				int count = 0;
				for (int i = 0; i < _Size; i++)
				{
					for (int j = 0; j < _Size; j++)
					{
						if (_matrix[i, j] != null)
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

			_matrix[_vertices.IndexOf(vertex1), _vertices.IndexOf(vertex2)] = new Edge(vertex1, vertex2, w);
		}

		public void AddVertex(string str)
		{
			if (GetVertexRef(str) != null)
				return;

			_vertices.Add(new Vertex(str));
		}

		public void Clear()
		{
			_vertices.Clear();
			_matrix = new Edge[_Size, _Size];
		}

		public int DelEdge(string v1, string v2)
		{
			Vertex vertex1 = GetVertexRef(v1);
			Vertex vertex2 = GetVertexRef(v2);

			if (vertex1 == null || vertex2 == null)
				throw new KeyNotFoundException();

			int w = _matrix[_vertices.IndexOf(vertex1), _vertices.IndexOf(vertex2)].W;
			_matrix[_vertices.IndexOf(vertex1), _vertices.IndexOf(vertex2)] = null;
			return w;
		}

		public void DelVertex(string str)
		{
			Vertex vertex = GetVertexRef(str);

			if (vertex == null)
				throw new KeyNotFoundException();

			for (int i = 0; i < _Size; i++)
			{
				_matrix[_vertices.IndexOf(vertex), i] = null;
				_matrix[i, _vertices.IndexOf(vertex)] = null;
			}
			_vertices.Remove(vertex);
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
			Console.Write("   ");
			for (int i = 0; i < _Size; i++)
			{
				Console.Write("{0, -2}|", i);
			}
			Console.WriteLine();
			for (int i = 0; i < _Size; i++)
			{
				Console.Write("{0, -2}|", i);
				for (int j = 0; j < _Size; j++)
				{
					if (_matrix[i, j] == null)
						Console.Write("  |");
					else
						Console.Write("{0, -2}|", _matrix[i, j].W);
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

			return _matrix[_vertices.IndexOf(vertex1), _vertices.IndexOf(vertex2)];
		}

		private Vertex GetVertexRef(string data)
		{
			return _vertices.FirstOrDefault((x) => x.Data == data);
		}

		public int GetInputEdgeCount(string v)
		{
			Vertex vertex = GetVertexRef(v);
			if (vertex == null)
				throw new KeyNotFoundException();

			int count = 0;
			for (int i = 0; i < _Size; i++)
			{
				if (_matrix[i, _vertices.IndexOf(vertex)] != null)
					count++;
			}
			return count;
		}

		public int GetOutputEdgeCount(string v)
		{
			Vertex vertex = GetVertexRef(v);
			if (vertex == null)
				throw new KeyNotFoundException();

			int count = 0;
			for (int i = 0; i < _Size; i++)
			{
				if (_matrix[_vertices.IndexOf(vertex), i] != null)
					count++;
			}
			return count;
		}

		public List<string> GetInputVertexNames(string v)
		{
			Vertex vertex = GetVertexRef(v);
			if (vertex == null)
				throw new KeyNotFoundException();

			List<string> result = new List<string>();
			for (int i = 0; i < _Size; i++)
			{
				if (_matrix[i, _vertices.IndexOf(vertex)] != null)
					result.Add(_matrix[i, _vertices.IndexOf(vertex)].V1.Data);
			}
			return result;
		}

		public List<string> GetOutputVertexNames(string v)
		{
			Vertex vertex = GetVertexRef(v);
			if (vertex == null)
				throw new KeyNotFoundException();

			List<string> result = new List<string>();
			for (int i = 0; i < _Size; i++)
			{
				if (_matrix[_vertices.IndexOf(vertex), i] != null)
					result.Add(_matrix[_vertices.IndexOf(vertex), i].V2.Data);
			}
			return result;
		}

		public List<string> GetPath(string from, string to)
		{
			throw new NotImplementedException();
		}
	}
}
