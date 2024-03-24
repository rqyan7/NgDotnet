using System;
using Microsoft.AspNetCore.Mvc;
using NGdotnet.API.Models.Domain;
using NGdotnet.API.Models.DTO;

namespace NGdotnet.API.Repository.Interface
{
	public interface ICategoryRepo
	{
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetCategories();

        Task<Category?> GetById(Guid id);

        Task<Category?> UpdataAsync(Category category);

        Task<Category?> DeleteAsync(Guid id);


    }



}

