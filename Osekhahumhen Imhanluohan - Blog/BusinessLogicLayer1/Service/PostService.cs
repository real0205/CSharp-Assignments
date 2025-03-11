﻿using BusinessLogicLayer.IService;
using DataAccessLayer.IRepositories;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }
        public Post? CreatePost(Post post, out string message)
        {
            
            if (string.IsNullOrWhiteSpace(post.Title))
            {
                message = "Post Title cannot be empty";
                return null;
            }

            if (string.IsNullOrWhiteSpace(post.Content))
            {
                message = "Post Content cannot be null";
                return null;
            }

            User user = _userRepository.GetUser(post.AuthorId);

            if(user == null)
            {
                message = "Author cannot be found";
                return null;
            }

            //category check

            Post result = _postRepository.CreatePost(post);
            message = "Successful";
            return result;
        }



        public bool DeletePost(int id, out string message)
        {
            if (id <= 0)
            {
                message = "Invalid";
                return false;
            }

            Post? post = _postRepository.GetPostById(id);

            if (post == null)
            {
                message = "Post not found";
                return false;
            }

            _postRepository.DeletePost(post);
            message = "Deleted Successfully";
            return true;

        }

        public List<Post> GetAllPost()
        {
            return _postRepository.GetAllPost();
        }

        public Post? GetPost(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _postRepository.GetPostById(id);
        }

        public List<Post> GetPostByAuthorId(int AuthorId, out string message)
        {
            if (AuthorId <= 0)
            {
                message = "Author Id cannot below 1";
                return null;
            }
            // fetch role first to check if role is valid 
            List<Post> result = _postRepository.GetPostByAuthorId(AuthorId);

            if (result == null)
            {
                message = "Post not found";
                return null;
            }

            message = "Successfully fetched users";
            return result;
        }

        public Post? UpdatePost(Post post, out string message)
        {
            if (post.Id <= 0)
            {
                message = "Invalid Id";
                return null;
            }

            if (string.IsNullOrWhiteSpace(post.Title))
            {
                message = "Post Title cannot be empty";
                return null;
            }

            if (string.IsNullOrWhiteSpace(post.Content))
            {
                message = "Post Content cannot be null";
                return null;
            }

            Post? updatedPost = _postRepository.UpdatePost(post);

            if (updatedPost is null)
            {
                message = "User not found";
                return null;
            }

            message = "Successfully Upated user";
            return updatedPost;
        }
    }
}
