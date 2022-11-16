namespace BlogSharpJK.MVC.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Untitled";
        public string Content { get; set; } = "No content";
        public DateTime CreationDate { get; set; }
    }
}
