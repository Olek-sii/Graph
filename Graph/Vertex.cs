namespace Graph
{
	public class Vertex
	{
		private string _data;
		public string Data { get => _data; set => _data = value; }

		public Vertex(string data)
		{
			_data = data;
		}
	}
}
