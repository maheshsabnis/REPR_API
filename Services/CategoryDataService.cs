using Microsoft.EntityFrameworkCore;
using REPR_API.Models;

namespace REPR_API.Services
{
    public class CategoryDataService : IDataService<Category, int>
    {
        EshoppingDbContext ctx;
        ResponseObject<Category> response;
        public CategoryDataService(EshoppingDbContext ctx)
        {
            this.ctx = ctx;
            response = new ResponseObject<Category>();
        }
        async Task<ResponseObject<Category>> IDataService<Category, int>.CreateAsync(Category entity)
        {
            try
            {
                var result = await ctx.Categories.AddAsync(entity);
                await ctx.SaveChangesAsync();
                response.Record = result.Entity;
                response.StatusCode = 200;
                response.Message = "New Record is created suiccessfully";
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResponseObject<Category>> IDataService<Category, int>.DeleteAsync(int id)
        {
            try
            {
                var entity = await ctx.Categories.FindAsync(id);
                if (entity == null)
                    throw new Exception($"Record by Id= {id} is not found");

                ctx.Categories.Remove(entity);
                await ctx.SaveChangesAsync();
                response.Record = entity;
                response.StatusCode = 200;
                response.Message = "Record deleted successfuly";
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResponseObject<Category>> IDataService<Category, int>.GetAsync()
        {
            try
            {
                var result = await ctx.Categories.ToListAsync();
                response.Records = result;
                response.StatusCode = 200;
                response.Message = "Records read successfuly";
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResponseObject<Category>> IDataService<Category, int>.GetByIdAsync(int id)
        {
            try
            {
                var entity = await ctx.Categories.FindAsync(id);
                if (entity == null)
                    throw new Exception($"Record by Id= {id} is not found");
                response.Record = entity;
                response.StatusCode = 200;
                response.Message = "Record found successfuly";
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResponseObject<Category>> IDataService<Category, int>.UpdateAsync(int id, Category entity)
        {
            try
            {
                ctx.Entry<Category>(entity).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
                response.Record = entity;
                response.StatusCode = 200;
                response.Message = "Record updates successfuly";
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
