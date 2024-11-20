using TradeAPI.Models.DTO;

namespace TradeAPI.Models.Mappers
{
    public class ProductMapper
    {
        public static Product ConvertToModel(ProductDTO dto)
        {
            return new Product
            {
                Name = dto.Name,
                SupplierId = dto.SupplierId,
                ManufacturerId = dto.ManufacturerId,
                ProductArticleNumber = dto.ProductArticleNumber,
                Status = dto.Status,
                Cost = dto.Cost,
                Description = dto.Description,
                Measure = dto.Measure,
                QuantityInStock = dto.QuantityInStock,
                CurrentDiscount = dto.CurrentDiscount,
                ProductMaxDiscount = dto.ProductMaxDiscount,
                Photo = dto.Photo,
                ProductTypeId = dto.ProductTypeId,
            };
        }
        public static ProductDTO ConvertToDTO(Product dto)
        {
            return new ProductDTO
            {
                Name = dto.Name,
                SupplierId = dto.SupplierId,
                ManufacturerId = dto.ManufacturerId,
                ProductArticleNumber = dto.ProductArticleNumber,
                Status = dto.Status,
                Cost = dto.Cost,
                Description = dto.Description,
                Measure = dto.Measure,
                QuantityInStock = dto.QuantityInStock,
                CurrentDiscount = dto.CurrentDiscount,
                ProductMaxDiscount = dto.ProductMaxDiscount,
                Photo = dto.Photo,
                ProductTypeId = dto.ProductTypeId,
            };
        }
    }
}
