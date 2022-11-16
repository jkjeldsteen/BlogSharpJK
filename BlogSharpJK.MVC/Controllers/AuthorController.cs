using BlogSharpJK.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSharpJK.MVC.Controllers
{
    public class AuthorController : Controller
    {
        public static List<Author> _authors = new List<Author>()
        {
        new Author() { Id = 1, BlogTitle = "Awesome Blog", Password = "123AWE",
            Email = "AwesomeBlogger@mail.com"},
        new Author() { Id = 2, BlogTitle = "Extraordinary Blog", Password = "123EXT",
            Email = "ExtraordinaryBlogger@mail.com"},
        new Author() { Id = 3, BlogTitle = "IDEK", Password = "123456",
            Email = "CluelessBlogger@mail.com"},
        };

        // GET: AuthorController
        public ActionResult Index()
        {
            return View(_authors);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            return View(_authors.First(author => author.Id == id));
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            try
            {
                author.Id = _authors.Max(blogPost => blogPost.Id) + 1;
                _authors.Add(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_authors.First(author => author.Id == id));
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author editedAuthor)
        {
            try
            {
                var author = _authors.First(author => author.Id == editedAuthor.Id);
                author.Email = editedAuthor.Email;
                author.Password = editedAuthor.Password;
                author.BlogTitle = editedAuthor.BlogTitle;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_authors.First(author => author.Id == id));
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Author toDeleteAuthor)
        {
            try
            {
                BlogPostController._blogPosts.RemoveAll(blogPosts => blogPosts.AuthorId == toDeleteAuthor.Id);
                _authors.RemoveAll(authors => authors.Id == toDeleteAuthor.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
