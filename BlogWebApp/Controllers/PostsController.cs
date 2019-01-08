using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogWebApp.Data;
using BlogWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BlogWebApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Post.ToListAsync());
        }



        // GET: Posts/Details/5
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post post = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            PostDetailsViewModel viewModel = await GetPostDetailsViewModelFromPost(post);

            return View(viewModel);
        }

        private async Task<PostDetailsViewModel> GetPostDetailsViewModelFromPost(Post post)
        {
            PostDetailsViewModel viewModel = new PostDetailsViewModel();

            viewModel.Post = post;

            List<Comment> comments = await _context.Comment
                .Where(m => m.ThePost == post).ToListAsync();

            viewModel.Comments = comments;
            return viewModel;
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Details([Bind("PostID, CommentContent, CommentAuthor, CommentDate")] PostDetailsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment();

                comment.CommentContent = viewModel.CommentContent;
                comment.CommentAuthor = viewModel.CommentAuthor;
                comment.CommentDate = viewModel.CommentDate;

                Post post = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == viewModel.PostID);
                if (post == null)
                {
                    return NotFound();
                }

                comment.ThePost = post;
                _context.Comment.Add(comment);
                await _context.SaveChangesAsync();

                viewModel = await GetPostDetailsViewModelFromPost(post);
            }

            return View(viewModel);
        }

        // GET: Posts/Create
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "user")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostTitle,PostContent,PostAuthor,PostDate")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PostTitle,PostContent,PostAuthor,PostDate")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize (Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Post.FindAsync(id);
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.Id == id);
        }
    }
}
