using BusinessLogicLayer.Service;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.UnitOfWorkService
{
    public interface IUnitOfWorkService : IDisposable
    {
        AuthorService authorService { get; }
        BlogService blogService { get; }
        CategoryService categoryService { get; }
        CommentService commentService { get; }
        UserService userService { get; }
    }
}
