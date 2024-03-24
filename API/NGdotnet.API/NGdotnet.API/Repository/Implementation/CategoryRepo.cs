using System;
using Microsoft.EntityFrameworkCore;
using NGdotnet.API.Data;
using NGdotnet.API.Models.Domain;
using NGdotnet.API.Repository.Interface;

namespace NGdotnet.API.Repository.Implementation
{
    public class CategoryRepo : ICategoryRepo
	{
        private readonly AppDbContext dbContext;

        public CategoryRepo(AppDbContext dbContext)
		{
            this.dbContext = dbContext;
        }

        //Create
        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        }


        //Get by Id
        public async Task<Category?> GetById(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        //Get all Categories
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await dbContext.Categories.ToListAsync();
        }

        //update
        public async Task<Category?> UpdataAsync(Category category)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if (existingCategory != null)
            {
                dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await dbContext.SaveChangesAsync();
                return category;
            }
            return null;

        }

        //Delete
        public async Task<Category?> DeleteAsync(Guid id)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCategory is null)
            {
                return null;
            }

            dbContext.Categories.Remove(existingCategory);
            await dbContext.SaveChangesAsync();

            return existingCategory;

        }


    }
}

