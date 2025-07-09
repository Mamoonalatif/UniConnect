namespace UniConnect.Modals
{
    public class Testimonial
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Role { get; set; }
        public string Text { get; set; }
        public string Logo { get; set; } = "/images/person.png";
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }

   
}
