using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class ProductManager : IBasicFunctions<Product>
    {
        public List<Product> Products { get; private set; }
        private ProductMediator productMediator;

        public ProductManager()
        {
            this.Products = new List<Product>();
            this.productMediator = new ProductMediator();
        }

        public bool Add(Product product)
        {
            if (product != null)
            {
                this.Products.Add(product);
                this.productMediator.Add(product);
                return true;
            }
            else { return false; }

        }

        public bool Remove(Product product)
        {
            if (this.Get(product.ID) != null)
            {
                this.Products.Remove(product);
                this.productMediator.Remove(product);
                return true;
            }
            else { return false; }

        }

        public Product Get(int id)
        {
            foreach (Product product in this.GetAll())
            {
                if (product.ID == id)
                {
                    return product;
                }
            }
            return null;
        }

        public Product Get(string name)
        {
            foreach (Product product in this.GetAll())
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }

        public bool Update(Product product)
        {
            if (this.Products.Contains(product))
            {
                this.productMediator.Update(product);
                return true;
            }
            else { return false; }
        }

        public List<Product> GetAll()
        {
            this.Load();

            if (this.Products != null)
            {
                return this.Products;
            }
            else { return null; }
        }
        public List<Product>GetProductsOfSpecificDepartment(Department department)
        {
            List<Product> products = new List<Product>();
            foreach (Product p in this.GetAll())
            {
                if (p.DepartmentID==department.ID)
                {
                    products.Add(p);
                }
            }
            return products;
        }
        public bool Load()
        {
            this.Products = this.productMediator.GetAll();

            if (this.Products != null)
            {
                return true;
            }
            else { return false; }
        }

    }
}
