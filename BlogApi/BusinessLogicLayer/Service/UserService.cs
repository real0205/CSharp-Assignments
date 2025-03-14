using BlogApi.DomainLayer.Models;
using BusinessLogicLayer.IService;
using DataAccessLayer.Data.IRepositories;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class UserService : IUserService
    {
        //UserRepository _userRepository;

        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<User?> CreateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.firstname))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(user.lastname))
            {
                return null;
            }

            if (user.dob == null)
            {
                return null;
            }

            return _unitOfWork.userRepository.CreateUser(user);
        }

        public async Task<bool> DeleteUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            User? user = await  _unitOfWork.userRepository.Get(id);

            if (user == null)
            {
                return false;
            }

            _unitOfWork.userRepository.DeleteUser(user);
            return true;
        }

        public List<User> GetAllUser()
        {
            return _unitOfWork.userRepository.Get();
        }

        public async Task<User?> GetUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            return await _unitOfWork.userRepository.Get(id);
        }

        public async Task<User?> UpdateUser(User user)
        {

            if (string.IsNullOrWhiteSpace(user.firstname))
            {
                return null;
            }

            User? updatedUser = await _unitOfWork.userRepository.Get(user.Id);

            if (updatedUser is null)
            {
                return null;
            }
            return updatedUser;
        }
    }
}
