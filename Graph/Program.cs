using System;

namespace Graph
{
	class Program
	{
		static void Main(string[] args)
		{
			IGraph graph = new GraphMatrix();

			graph.AddVertex("1");
			graph.AddVertex("2");
			graph.AddVertex("3");

			graph.AddEdge("1", "2", 5);
			graph.AddEdge("1", "3", 7);
			graph.AddEdge("2", "3", 42);
			graph.AddEdge("3", "1", 42);
			graph.AddEdge("3", "1", 43);

			//graph.DelVertex("1");

			graph.Print();

			Console.ReadKey();
		}
	}
}
