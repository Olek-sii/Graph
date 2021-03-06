﻿using System;

namespace Graph
{
	class Program
	{
		static void Main(string[] args)
		{
			IGraph graph = new GraphVertexList();

			graph.AddVertex("1");
			graph.AddVertex("2");
			graph.AddVertex("3");

			graph.AddEdge("1", "2", 5);
			graph.AddEdge("1", "3", 7);
			graph.AddEdge("2", "3", 42);
			graph.AddEdge("3", "1", 42);
			graph.AddEdge("3", "1", 43);

			graph.DelVertex("1");
			graph.AddVertex("4");

			graph.AddEdge("4", "2", 43);


			graph.Print();

			Console.ReadKey();
		}
	}
}
