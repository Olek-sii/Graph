using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
	class Program
	{
		static void Main(string[] args)
		{
			IGraph graph = new GraphVertexList();

			graph.AddVertex("qwerty");
			graph.AddVertex("QWERTY");
			graph.AddVertex("123456");

			graph.AddEdge("qwerty", "1234536", 5);
			graph.AddEdge("qwerty", "QWERTY", 7);
			graph.AddEdge("QWERTY", "123456", 42);

			graph.Print();

			Console.ReadKey();
		}
	}
}
