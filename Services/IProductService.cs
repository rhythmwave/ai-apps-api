using System.Collections.Generic;
using speechRestfulApi.Models;

namespace speechRestfulApi.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
