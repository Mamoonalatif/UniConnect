namespace UniConnect.Modals
{
    public class Event
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }
        public DateTime Date { get; set; }
        public required string Category { get; set; }
        public required string ImageFileName { get; set; }
        public required string ImageUrl { get; set; }
        public required string Faculty
        {
            get; set;
        }
    }
}

