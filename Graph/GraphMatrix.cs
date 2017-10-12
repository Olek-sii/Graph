//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Graph
//{
//	class GraphMatrix : IGraph
//	{
//		private Dictionary<KeyValuePair<string, string>, int> _graph = new Dictionary<KeyValuePair<string, string>, int>();
//		private int _size = 0;

//		public void AddEdge(string v1, string v2, int w)
//		{
//			throw new NotImplementedException();
//		}

//		public void AddVertex(string str)
//		{
//			//int[,] newMatrix = new int[_size + 1, _size + 1];
//			//for (int i = 0; i < _size; i++)
//			//{
//			//	for (int j = 0; j < _size; j++)
//			//	{
//			//		newMatrix[i, j] = _graph[i, j];
//			//	}
//			//	newMatrix[i, _size] = -1;
//			//}

//			//for (int i = 0; i <= _size; i++)
//			//{
//			//	newMatrix[_size, i] = -1;
//			//}
//			//_size++;
//			//_graph = newMatrix;
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
//			//for (int i = 0; i < _size; i++)
//			//{
//			//	for (int j = 0; j < _size; j++)
//			//	{
//			//		if (_graph[i, j] > -1)
//			//			Console.Write(_graph[i,j]);
//			//		else
//			//			Console.Write('-');
//			//	}
//			//	Console.WriteLine();
//			//}
//		}

//		public void SetEdge(string v1, string v2, int w)
//		{
//			throw new NotImplementedException();
//		}
//	}
//}
