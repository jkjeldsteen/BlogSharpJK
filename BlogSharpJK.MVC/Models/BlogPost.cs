namespace BlogSharpJK.MVC.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Untitled";
        public string Content { get; set; } = "No content";
        public string AuthorName { get; set; }
        public DateTime CreationDate { get; set; }
        public int AuthorId { get; set; }
    }
}
