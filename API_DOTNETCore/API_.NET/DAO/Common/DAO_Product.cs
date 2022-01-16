﻿using API_.NET.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using API_.NET.Utils;
using API_.NET.DTO;
using System;
namespace API_.NET.DAO.Common
{
    public class DAO_Product
    {
        // Get all product
        public static List<Product> GetAllProduct()
        {
            using (var context = new SmarketContext())
            {
                return context.Product.ToList();
            }
        }

        //get products from text search
        public static List<Product> GetSearchProduct(string textsearch)
        {
            using (var context = new SmarketContext())
            {
                return context.Product.FromSql(Utils_Queries.ListSearchProduct(textsearch)).ToList();
            }
        }

        // Get products of a store
        public static List<Product> GetAllProductOfStore(int storeId)
        {
            try
            {
                using(var context  = new SmarketContext())
                {
                    return context.Product.FromSql(Utils_Queries.GetAllProductOfStore(storeId)).ToList();
                }
            } catch
            {
                return null;
            }
        }

        // Get all feedback of a product
        public static List<OrderDetailFeedback> GetAllFeedbackOfProduct(int productId)
        {
            try 
            {
                using(var context = new SmarketContext())
                {
                    return context.OrderDetailFeedback.FromSql(Utils_Queries.GetAllProductFeedback(productId)).ToList();
                }
            }
            catch 
            {
                return null;
            }
        }

        public static List<DTO_ProductCard> GetProductsBySeach(string keyword, int page, int pageSize)
        {
            if (page < 1)
            {
                page = 1;
            }

            int skipRows = (page - 1) * pageSize;
            try
            {
                using (var context = new SmarketContext())
                {
                    var sqlResult = context.ProductCard.FromSql(Utils_Queries.GetProductsBySearch(keyword));
                    return sqlResult.Skip(skipRows).Take(pageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return new List<DTO_ProductCard>();
            }
        }
    }
}