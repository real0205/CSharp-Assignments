using BlogApi.DataAccessLayer.Data;
using BlogApi.DomainLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDBContext _applicationDbContext;
        private readonly UserManager<User> _userManager;

        public UnitOfWork(ApplicationDBContext applicationDbContext, UserManager<User> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        private AuthorRepository _authorRepository;
        private BlogRepository _blogRepository;
        private CategoryRepository _categoryRepository;
        private CommentRepository _commentRepository;
        private RoleRepository _roleRepository;
        private UserRepository _userRepository;

        public AuthorRepository authorRepository => _authorRepository ??= new AuthorRepository(_applicationDbContext);

        public BlogRepository blogRepository => _blogRepository ??= new BlogRepository(_applicationDbContext);

        public CategoryRepository categoryRepository => _categoryRepository ??= new CategoryRepository(_applicationDbContext);

        public CommentRepository commentRepository => _commentRepository ??= new CommentRepository(_applicationDbContext);

        public UserRepository userRepository => _userRepository ??= new UserRepository(_userManager);

        public async Task<int> CompleteAsync()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
