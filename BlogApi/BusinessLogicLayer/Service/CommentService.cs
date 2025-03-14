using BlogApi.DomainLayer.Models;
using BusinessLogicLayer.IService;
using DataAccessLayer.Data.IRepositories;
using DataAccessLayer.UnitOfWork;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class CommentService : ICommentService
    {
        //CommentRepository _commentRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Comment? CreateComment(Comment comment, out string message)
        {
            if (string.IsNullOrWhiteSpace(comment.Comments))
            {
                message = "Comment cannot be empty";
                return null;
            }

            message = "Created Successfuly";
            ; return _unitOfWork.commentRepository.Create(comment);
        }

        public bool DeleteComment(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            Comment? comment = _unitOfWork.commentRepository.Get(id);

            if (comment == null)
            {
                return false;
            }

            _unitOfWork.commentRepository.Delete(comment);
            return true;
        }

        public List<Comment> GetAllComment()
        {
            return _unitOfWork.commentRepository.Get();
        }

        public Comment? GetComment(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _unitOfWork.commentRepository.Get(id);
        }

        public Comment? UpdateComment(Comment comment, out string message)
        {

            if (string.IsNullOrWhiteSpace(comment.Comments))
            {
                message = "Comment is required";
                return null;
            }

            Comment? updatedComment = _unitOfWork.commentRepository.Get(comment.Id);

            if (updatedComment is null)
            {
                message = "Comment not found";
                return null;
            }
            message = "Comment Updated Successfully";
            return updatedComment;
        }
    }
}
