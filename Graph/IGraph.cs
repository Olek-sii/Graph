using System;

namespace Graph
{
	public interface IGraph
	{
		void Clear();

		int VertexCount { get; }
		int EdgeCount { get; }

		void Print();
		void AddVertex(string str);
		void AddEdge(string from, string to, int w);
		void DelVertex(string str);
		int DelEdge(string v1, string v2);
		void SetEdge(string v1, string v2, int w);
		int GetEdge(string v1, string v2);
	}
}
