﻿namespace TradeAPI.Models.DTO
{
    public class ProductDTO
    {
        public string ProductArticleNumber { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Measure { get; set; } = null!;

        public decimal Cost { get; set; }

        public string? Description { get; set; }

        public int ProductTypeId { get; set; }

        public string? Photo { get; set; }

        public int SupplierId { get; set; }

        public int? ProductMaxDiscount { get; set; }

        public int ManufacturerId { get; set; }

        public int? CurrentDiscount { get; set; }

        public string Status { get; set; } = null!;

        public int QuantityInStock { get; set; }
    }
}
