using BlogSharpJK.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSharpJK.MVC.Controllers;

public class BlogPostController : Controller
{
    public static List<BlogPost> _blogPosts = new List<BlogPost>()
    {
        new BlogPost() { Id = 1, Title = "Awesome Blogpost", Content = "Even more awesome content",
            CreationDate = DateTime.Now.AddDays(-3), AuthorName = "IDEK", AuthorId = 3},
        new BlogPost() { Id = 2, Title = "Awesome Blogpost v2", Content = "The most awesome content",
            CreationDate = DateTime.Now.AddDays(-2), AuthorName = "IDEK", AuthorId = 3},
        new BlogPost() { Id = 3, Title = "IDEK", Content = "What doink, what burning, roof burning",
            CreationDate = DateTime.Now.AddDays(-1), AuthorName = "IDEK", AuthorId = 3},
    };
    
    // GET: BlogPostController
    public ActionResult Index()
    {
        return View(_blogPosts);
    }

    // GET: BlogPostController/Details/5
    public ActionResult Details(int id)
    {
        return View(_blogPosts.First(blogPost => blogPost.Id == id));
    }

    // GET: BlogPostController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: BlogPostController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(BlogPost blogPost)
    {
        try
        {
            blogPost.Id = _blogPosts.Max(blogPost => blogPost.Id) + 1;
            blogPost.CreationDate = DateTime.Now;
            blogPost.AuthorId = AuthorController._authors.First(author => author.BlogTitle == blogPost.AuthorName).Id;
            _blogPosts.Add(blogPost);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: BlogPostController/Edit/5
    public ActionResult Edit(int id)
    {
        return View(_blogPosts.First(blogPost => blogPost.Id == id));
    }

    // POST: BlogPostController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(BlogPost editedBlogPost)
    {
        try
        {
            var blogPost = _blogPosts.First(blogPost => blogPost.Id == editedBlogPost.Id);
            blogPost.Title = editedBlogPost.Title;
            blogPost.Content = editedBlogPost.Content;
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: BlogPostController/Delete/5
    public ActionResult Delete(int id)
    {
        return View(_blogPosts.First(blogPost => blogPost.Id == id));
    }

    // POST: BlogPostController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(BlogPost toDeleteBlogPost)
    {
        try
        {
            _blogPosts.RemoveAll(blogPost => blogPost.Id == toDeleteBlogPost.Id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
