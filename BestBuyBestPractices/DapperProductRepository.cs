using System;
using System.Collections.Generic;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        public DapperProductRepository()
        {
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
