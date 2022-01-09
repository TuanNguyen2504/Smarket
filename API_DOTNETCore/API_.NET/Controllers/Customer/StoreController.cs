﻿using API_.NET.DAO.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace API_.NET.Controllers.Customer
{
    [Route("api/customer/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        // Get all Store with status != 0
        [HttpGet("all")]
        public List<DTO.DTO_Stores> GetAllStore()
        {
            return DAO_Store.GetAllStore();
        }

        // Get store by id
        [HttpGet]
        public DTO.DTO_Stores GetDetailStore([FromQuery] int storeId)
        {
            return DAO_Store.GetStoreById(storeId);
        }

        // Get near stores 
        [HttpGet("near")]
        public List<DTO.DTO_Stores> GetNearestStore([FromQuery] int area)
        {
            return DAO_Store.GetNearestStore(area);
        }

        // Get store by search
        [HttpGet("search")]
        public List<DTO.DTO_Stores> GetSearchStores([FromQuery] string storeName)
        {
            return DAO_Store.GetSearchStores(storeName);
        }

        // Get stores have product
        [HttpGet("product")] 
        public List<DTO.DTO_Stores> GetStoresByProductName([FromQuery] string productName)
        {
            return DAO_Store.GetStoresByProductName(productName);
        }
    }
}
