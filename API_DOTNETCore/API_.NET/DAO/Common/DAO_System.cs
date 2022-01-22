using System;
using System.Linq;
using API_.NET.DTO;
using API_.NET.Models;
using API_.NET.Utils;
using Microsoft.EntityFrameworkCore;

namespace API_.NET.DAO.Common
{
    public class DAO_System
    {
        public static int GetNearestShipperByWard(int wardId)
        {
            using (var context = new SmarketContext())
            {
                int sqlResult = context.Number.FromSql(Utils_Queries.GetNearestShipperByWard(wardId)).First().Number;
                return sqlResult;
            }
        }
        public static DTO_Address GetStoreAddressById(int storeId)
        {
            try
            {
                using (var context = new SmarketContext())
                {
                    return context.Address.FromSql(Utils_Queries.GetStoreAddressById(storeId)).First();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"GetNearestShipperByWard {ex.ToString()}");
                System.Console.WriteLine($"GetStoreAddressById ERROR: {ex.ToString()}");
                throw ex;
            }
        }
        public static DTO_Address GetCustomerAddressById(int customerId)
        {
            try
            {
                using (var context = new SmarketContext())
                {
                    return context.Address.FromSql(Utils_Queries.GetCustomerAddressById(customerId)).First();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"GetCustomerAddressById ERROR: {ex.ToString()}");
                throw ex;
            }
        }

        public static int GetNearestShipperByDistrict(int wardId)
        {
            using (var context = new SmarketContext())
            {
                int districtId = context.Number.FromSql(Utils_Queries.GetDistrictByWardId(wardId)).First().Number;
                System.Console.WriteLine("districtId " + districtId);
                int sqlResult = context.Number.FromSql(Utils_Queries.GetNearestShipperByDistrictId(districtId)).First().Number;
                System.Console.WriteLine("sqlResult " + sqlResult);
                return sqlResult;
            }

        }
        public static void UpdateOrderShipper(int orderId, int shipperId)
        {
            try
            {
                using (var context = new SmarketContext())
                {

                    CusOrder order = context.CusOrder.Where(o => o.OrderId == orderId).First();
                    order.ShipperId = shipperId;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void UpdateShipperStatus(int shipperId, int status)
        {
            try
            {
                using (var context = new SmarketContext())
                {
                    Shipper shipper = context.Shipper.Where(s => s.ShipperId == shipperId).First();
                    shipper.Status = status;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"GetNearestShipperByDistrict {ex.ToString()}");
                throw ex;
            }
        }
    }
}