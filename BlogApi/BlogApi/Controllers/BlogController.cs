using AutoMapper;
using BlogApi.DomainLayer.Models;
using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperModel;
using BusinessLogicLayer.UnitOfWorkService;
using DomainLayer.DTO.BlogDto;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class BlogController : ControllerBase
    {

        IUnitOfWorkService _unitOfWorkService;
        IMapper _mapper;
        public BlogController(IBlogService blogService, IMapper mapper, IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
            _mapper = mapper;
        }

        [HttpGet("GetBlog")]
        public IActionResult GetBlog()
        {
            //return Ok(_blogService.GetAllBlog()); // action result. That's why it contains ok

            return Ok(_mapper.Map<IList<BlogDto>>(_unitOfWorkService.blogService.GetAllBlog()));
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            Blog? blog = _unitOfWorkService.blogService.GetBlog(id);

            if (blog == null)
            {
                return NotFound();
            }

            //BlogMapper blogMapper = new BlogMapper();
            //BlogDto blogDto = blogMapper.MapBlogToBlogDto(blog);

            //return Ok(blog);

            return Ok(_mapper.Map<BlogDto>(blog));
        }

        [HttpPost("CreateBlog")]
        public IActionResult CreateBlog([FromBody] CreateRequestBlogDto blog)
        {
            BlogMapper blogMapper = new BlogMapper();
            Blog mappedBlog = blogMapper.MapBlogRequestToBlog(blog);

            Blog? createdBlog = _unitOfWorkService.blogService.CreateBlog(mappedBlog, out string message);
            if (createdBlog == null)
            {
                return BadRequest(message);
            }

            BlogDto blogDto = blogMapper.MapBlogToBlogDto(createdBlog);
            return Ok(createdBlog);
        }

        [HttpPost("UpdateBlog")]
        public IActionResult UpdateBlog([FromBody] UpdateBlogDto blog)
        {
            BlogMapper blogMapper = new BlogMapper();
            Blog resultOfmapping = blogMapper.MapUpdateBlogDtoToBlog(blog);

            Blog? blogUpdated = _unitOfWorkService.blogService.UpdateBlog(resultOfmapping, out string message);



            if (blogUpdated == null)
            {
                return BadRequest(message);
            }

            BlogDto blogDto = blogMapper.MapBlogToBlogDto(blogUpdated);

            return Ok(blogDto);
        }
    }
}
