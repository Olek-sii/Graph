namespace Graph
{
	public class Edge
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
}
