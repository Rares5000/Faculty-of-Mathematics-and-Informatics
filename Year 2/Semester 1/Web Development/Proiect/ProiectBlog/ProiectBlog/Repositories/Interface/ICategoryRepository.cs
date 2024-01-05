﻿using ProiectBlog.Models.Domain;

namespace ProiectBlog.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category?> GetCategoryById(Guid id);   
    }
}
