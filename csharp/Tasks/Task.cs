namespace Tasks
{
	public class Task
	{
        private Task() { }

	    public Task(long id, string description, bool done)
	    {
	        Id = id;
	        Description = description;
	        Done = done;
	    }

		public long Id { get; set; }

		public string Description { get; set; }

		public bool Done { get; set; }
	}
}
