using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeAPI.Models;
using TradeAPI.Models.DTO;
using TradeAPI.Models.Mappers;

namespace TradeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("products")]
        public IActionResult GetAll()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            using (var db = new TradeContext())
            {
                foreach (var i in db.Products)
                {
                    products.Add(ProductMapper.ConvertToDTO(i));
                }
            }
            return Ok(products);
        }
        [HttpGet]
        [Route("types")]
        public IActionResult GetTypes()
        {
            List<string> types = new List<string>();
            using (var db = new TradeContext())
            {
                foreach (var i in db.Producttypes)
                {
                    types.Add(i.Name);
                }
            }
            return Ok(types);
        }
        [HttpGet]
        [Route("suppliers")]
        public IActionResult GetSuppliers()
        {
            List<string> suppliers = new List<string>();
            using (var db = new TradeContext())
            {
                foreach (var i in db.Suppliers)
                {
                    suppliers.Add(i.Name);
                }
            }
            return Ok(suppliers);
        }
        [HttpGet]
        [Route("manufacturers")]
        public IActionResult GetManufacturers()
        {
            List<string> manufacturers = new List<string>();
            using (var db = new TradeContext())
            {
                foreach (var i in db.Manufacturers)
                {
                    manufacturers.Add(i.Name);
                }
            }
            return Ok(manufacturers);
        }
        
        [HttpPut]
        [Route("edit")]
        public IActionResult Edit([FromBody] ProductDTO dto)
        {
            using (var db = new TradeContext())
            {
                db.Suppliers.ToList();
                db.Manufacturers.ToList();
                db.Producttypes.ToList();
                var product = db.Products.FirstOrDefault(p => p.ProductArticleNumber == dto.ProductArticleNumber);
                if (product == null)
                {
                    return BadRequest("Product not found");
                }
                product.ProductMaxDiscount = dto.ProductMaxDiscount;
                product.SupplierId = dto.SupplierId;
                product.Cost = dto.Cost;
                product.CurrentDiscount = dto.CurrentDiscount;
                product.Description = dto.Description;
                product.ManufacturerId = dto.ManufacturerId;
                product.Measure = dto.Measure;
                product.Name = dto.Name;
                product.Photo = dto.Photo;
                product.ProductTypeId = dto.ProductTypeId;
                product.QuantityInStock = dto.QuantityInStock;
                product.Status = dto.Status;
                db.SaveChanges();
                return Ok();
            }
        }
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(string article)
        {
            using (var db = new TradeContext())
            {
                if (db.Users.Any(u => u.Orders.Any(o=> o.Orderproducts.Any(p => p.ProductArticleNumber == article))))
                {
                    return BadRequest("You can't delete the product that contains in the any order");
                }
                var product = db.Products.First(p => p.ProductArticleNumber == article);
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
