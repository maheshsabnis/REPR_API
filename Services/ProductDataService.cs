using Microsoft.EntityFrameworkCore;
using REPR_API.Models;

namespace REPR_API.Services
{
    public class ProductDataService : IDataService<Product, int>
    {
        EshoppingDbContext ctx;
        ResponseObject<Product> response;
        public ProductDataService(EshoppingDbContext ctx)
        {
            this.ctx = ctx;
            response = new ResponseObject<Product>();
        }
        async Task<ResponseObject<Product>> IDataService<Product, int>.CreateAsync(Product entity)
        {
            try
            {
                var result = await ctx.Products.AddAsync(entity);
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

        async Task<ResponseObject<Product>> IDataService<Product, int>.DeleteAsync(int id)
        {
            try
            {
                var entity = await ctx.Products.FindAsync(id);
                if (entity == null)
                    throw new Exception($"Record by Id= {id} is not found");

                ctx.Products.Remove(entity);
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

        async Task<ResponseObject<Product>> IDataService<Product, int>.GetAsync()
        {
            try
            {
                var result = await ctx.Products.ToListAsync();
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

        async Task<ResponseObject<Product>> IDataService<Product, int>.GetByIdAsync(int id)
        {
            try
            {
                var entity = await ctx.Products.FindAsync(id);
                if (entity == null)
                    throw new Exception($"Record by Id= {id} is not found");
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

        async Task<ResponseObject<Product>> IDataService<Product, int>.UpdateAsync(int id, Product entity)
        {
            try
            {
                ctx.Entry<Product>(entity).State = EntityState.Modified;
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
