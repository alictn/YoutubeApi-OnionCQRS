﻿using YoutubeApi.Application.DTOs;

namespace YoutubeApi.Application.Features.Query.GetAllProducts
{
    public class GetAllProductQueryResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public BrandDto Brand { get; set; }
    }
}
