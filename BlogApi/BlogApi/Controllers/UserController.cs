using AutoMapper;
using BlogApi.DomainLayer.Models;
using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperModel;
using BusinessLogicLayer.UnitOfWorkService;
using DomainLayer.DTO.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUnitOfWorkService _unitOfWorkService;
        IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper, IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
            _mapper = mapper;
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            //return Ok(_userService.GetAllUser());

            return Ok(_mapper.Map<IList<UserDto>>(_unitOfWorkService.userService.GetAllUser()));
        }

        [HttpGet]
        public IActionResult GetById(string id)
        {
            Task<User?>? user = _unitOfWorkService.userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            //UserMapper userMapper = new UserMapper();
            //UserDto userDto = userMapper.MapUserToUserDto(user);

            //return Ok(user);

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] CreateRequestUserDto user)
        {
            UserMapper userMapper = new UserMapper();
            User mappedUser = userMapper.MapUserRequestToUser(user);

            Task<User?> createdUser = _unitOfWorkService.userService.CreateUser(mappedUser);
            if (createdUser == null)
            {
                return BadRequest();
            }

            UserDto userDto = userMapper.MapUserToUserDto(createdUser);
            return Ok(createdUser);
        }

        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UpdateUserDto user)
        {
            UserMapper userMapper = new UserMapper();
            User resultOfmapping = userMapper.MapUpdateUserDtoToUser(user);

            Task<User?> userUpdated = _unitOfWorkService.userService.UpdateUser(resultOfmapping);



            if (userUpdated == null)
            {
                return BadRequest();
            }

            UserDto userDto = userMapper.MapUserToUserDto(userUpdated);

            return Ok(userDto);
        }
    }
}
