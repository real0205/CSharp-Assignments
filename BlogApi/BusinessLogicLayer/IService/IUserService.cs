using BlogApi.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IService
{
    public interface IUserService
    {
        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User?> GetUser(string id);

        /// <summary>
        /// Get all User
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUser();

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteUser(string id);

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        Task<User?>? UpdateUser(User User);

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        Task<User?> CreateUser(User User);
    }
}
