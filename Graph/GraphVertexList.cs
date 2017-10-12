using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
	public class GraphVertexList : IGraph
	{
		private Dictionary<Vertex, Dictionary<Vertex, Edge>> _vertices = new Dictionary<Vertex, Dictionary<Vertex, Edge>>();

		public int VertexCount => _vertices.Count;
		public int EdgeCount => 0;

		public void Print()
		{
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

			_vertices[vertexFrom].Add(vertexTo, new Edge(vertexFrom, vertexTo, w));
		}

		public void AddVertex(string str)
		{
			if (_vertices.Keys.FirstOrDefault((x) => x.Data == str) == null)
				_vertices.Add(new Vertex(str), new Dictionary<Vertex, Edge>());
		}

		public int DelEdge(string v1, string v2)
		{
			throw new NotImplementedException();
		}

		public void DelVertex(string str)
		{
			throw new NotImplementedException();
		}

		public int GetEdge(string v1, string v2)
		{
			throw new NotImplementedException();
		}

		public void SetEdge(string v1, string v2, int w)
		{
			throw new NotImplementedException();
		}

		public bool Equals(IGraph other)
		{
			return VertexCount == other.VertexCount;
		}
	}
}
