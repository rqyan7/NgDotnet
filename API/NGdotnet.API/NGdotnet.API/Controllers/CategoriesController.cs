using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGdotnet.API.Data;
using NGdotnet.API.Models.Domain;
using NGdotnet.API.Models.DTO;
using NGdotnet.API.Repository.Implementation;
using NGdotnet.API.Repository.Interface;

namespace NGdotnet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepo categoryRepo;

        public CategoriesController(ICategoryRepo categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryReqstDto request)
        {
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await categoryRepo.CreateAsync(category);

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);

        }

        // GET: https://localhost:7042/api/Categories

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await categoryRepo.GetCategories();

            //map domain model to DTO

            var response = new List<CategoryDto>();
            foreach (var category in categories)
            {
                response.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                });
            }

            return Ok(response);
        }

        // GET: https://localhost:7042/api/Categories/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var existingCategory = await categoryRepo.GetById(id);

            if (existingCategory is null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                Id = existingCategory.Id,
                Name = existingCategory.Name,
                UrlHandle = existingCategory.UrlHandle
                
            };
            return Ok(response);

        }

        // PUT: https://localhost:7042/api/Categories/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id, UpdateCateoryDTO request)
        {
            //convert DTO to domain model
            var category = new Category
            {
                Id = id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            category = await categoryRepo.UpdataAsync(category);

            if (category ==null)
            {
                return NotFound();
            }


            //convert domain model to DTO
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle

            };
            return Ok(response);


        }

        // DELETE: https://localhost:7042/api/Categories/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var category = await categoryRepo.DeleteAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            //
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle

            };
            return Ok(response);

        }





    }
}
