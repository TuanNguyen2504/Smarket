﻿namespace API_.NET.Utils
{
    public class Utils_Queries
    {
        // --------------- Common ----------------//
        public static string DeleteRowOfTable(string table, string fieldName, int id)
        {
            return $"DELETE FROM {table} WHERE {fieldName} = {id}";
        }

        // List product for search
        public static string ListSearchProduct(string str)
        {
            string query = $"SELECT * FROM Product WHERE LOWER(ProductName) LIKE '%{str.ToLower()}%'";
            return query;
        }

        // Count product of a store
        public static string CountProductOfStore(int storeId)
        {
            string query = $"SELECT s.StoreId, u.Name, count(p.ProductId) as Amount FROM Store s, AppUser u, Product p WHERE p.StoreId = s.StoreId AND s.UserId = u.UserId AND s.StoreId = { storeId.ToString()} GROUP BY s.StoreId, u.Name";
            return query;
        }

        // List product type for search
        public static string GetSearchProductType(string name)
        {
            string query = $"SELECT * FROM ProductType WHERE LOWER(ProductTypeName) LIKE '%{name.ToLower()}%'";
            return query;
        }

        // List product of a store
        public static string GetAllProductOfStore(int storeId)
        {
            string query = $"SELECT * FROM Product WHERE StoreId = {storeId}";
            return query;
        }

        // List Store
        public static string GetListStore()
        {
            string query = "SELECT a.accountId, u.UserId, u.Name, u.Phone, u.Address, s.StoreId, s.StoreType, s.Area, s.Status, s.Categories, s.Certificate"
                             + " FROM AppUser u, Store s, Account a"
                               + " WHERE s.UserId = u.UserId AND a.AccountId = u.AccountId AND a.AccountType = 3";
            return query;
        }

        // Get store by id
        public static string GetStoreById(int storeId)
        {
            string query = "SELECT u.UserId, u.Name, u.Phone, u.Address, s.StoreId, s.StoreType, s.Area, s.Categories, s.Certificate"
                             + " FROM AppUser u, Store s"
                               + $" WHERE s.UserId = u.UserId AND s.Status != 0 AND s.StoreId = {storeId}";
            return query;
        }

        // Get store nearest
        public static string GetStoreNearest(int area)
        {
            string query = "SELECT u.UserId, u.Name, u.Phone, u.Address, s.StoreId, s.StoreType, s.Area, s.Categories, s.Certificate"
                             + " FROM AppUser u, Store s"
                               + $" WHERE s.UserId = u.UserId AND s.Status != 0 AND s.Area = {area}";
            return query;
        }

        // Get store by search
        public static string GetSearchStores(string storeName)
        {
            string query = "SELECT u.UserId, u.Name, u.Phone, u.Address, s.StoreId, s.StoreType, s.Area, s.Categories, s.Certificate"
                             + " FROM AppUser u, Store s"
                               + $" WHERE s.UserId = u.UserId AND s.Status != 0 AND LOWER(u.Name) LIKE '%{storeName.ToLower()}%'";
            return query;
        }

        // Get stores from product id
        public static string GetStoresByProductName(string productName)
        {
            string query = "SELECT u.UserId, u.Name, u.Phone, u.Address, s.StoreId, s.StoreType, s.Area, s.Categories, s.Certificate"
                             + " FROM AppUser u, Store s, Product p"
                               + $" WHERE s.UserId = u.UserId AND s.Status != 0 AND s.StoreId = p.StoreId AND LOWER(p.ProductName) LIKE  '%{productName}%'";
            return query;
        }

        // Get all feedback of a product
        public static string GetFeedbackOfProduct(int productId)
        {
            string query = "SELECT fb.OrderDetailFeedbackId, fb.DetailId, fb.Content, fb.Rating, fb.FeedbackTime"
                            + " FROM OrderDetail o, OrderDetailFeedback fb"
                            + $" WHERE o.OrderDetailId = fb.DetailId AND o.ProductId = {productId}";
            return query;
        }

        // Get amount product each type
        public static string GetProductEachType(int group)
        {
            return "select t.ProductTypeName, p.ProductId, p.ProductName, p.UnitPrice, p.Unit, p.QuantitativeUnit, a.Name"
                    + " from Product p, ProductType t, Store s, AppUser a"
                    + $" where t.GroupType = {group} and t.ProductTypeId = p.ProductTypeId and p.StoreId = s.StoreId and s.UserId = a.UserId"
                    + " Group by t.ProductTypeName,a.Name, p.ProductId, p.ProductName, p.UnitPrice, p.Unit, p.QuantitativeUnit";
        }

        // Get product card list by type
        public static string GetProductCardByGroupType(int groupType)
        {
            return $@"SELECT p.ProductId, p.ProductName, p.UnitPrice, p.QuantitativeUnit, pi.Source AS Thumbnail
                        FROM Product p, ProductImage pi, ProductType pt
                        WHERE p.ProductTypeId = pt.ProductTypeId AND pt.GroupType = {groupType} AND pi.ProductId = p.ProductId AND pi.IsThumbnail = 1";
        }

        // Get list feedback of a product by id
        public static string GetAllProductFeedback(int productId)
        {
            return "SELECT ofb.*"
                    + " FROM OrderDetailFeedback ofb, OrderDetail o"
                    + $" WHERE o.ProductId = {productId} and o.OrderDetailId = ofb.DetailId";
        }

        // Get store information by product id
        public static string GetStoreInfoByProductId(int productId)
        {
            return $@"select a.*
                    from Store s, Product p, AppUser a
                    WHERE p.StoreId = s.StoreId and p.ProductId = {productId} and a.UserId = s.UserId";
        }

        // Get products by type
        public static string GetProductsByType(int typeId)
        {
            return $@"SELECT p.ProductId, p.ProductName, p.UnitPrice, p.QuantitativeUnit, pi.Source AS Thumbnail
                        FROM Product p, ProductImage pi
                        WHERE p.ProductTypeId = {typeId} AND pi.ProductId = p.ProductId AND pi.IsThumbnail = 1";
        }

        // Get products by seach
        public static string GetProductsBySearch(string keyword)
        {
            return $@"SELECT p.ProductId, p.ProductName, p.UnitPrice, p.QuantitativeUnit, pi.Source AS Thumbnail
                        FROM Product p, ProductImage pi
                        WHERE LOWER(p.ProductName) LIKE '%{keyword.ToLower()}%' AND pi.ProductId = p.ProductId AND pi.IsThumbnail = 1";
        }

        // Get product card by storeId
        public static string GetProductCardByStoreId(int storeId)
        {
            return $@"SELECT p.ProductId, p.ProductName, p.UnitPrice, p.QuantitativeUnit, pi.Source AS Thumbnail
                        FROM Product p, ProductImage pi, Store s
                        WHERE s.StoreId = {storeId} AND p.StoreId = s.StoreId AND pi.ProductId = p.ProductId AND pi.IsThumbnail = 1";
        }

        // Get full address by ward id
        public static string GetAddressByWardId(int wardId)
        {
            return $@"SELECT w.Prefix + ' ' + w.WardName AS Ward,
                             d.Prefix + ' ' + d.DistrictName AS District,
                             p.ProvinceName AS Province
                    FROM Ward w, District d, Province p
                    WHERE w.District = d.DistrictId AND d.Province = p.ProvinceId AND WardId = {wardId}";
        }

        // Get product for cart
        public static string GetProductForCart(int productId)
        {
            return $@"select  p.ProductId, p.ProductName, p.UnitPrice, p.QuantitativeUnit, i.Source AS Thumbnail
                    from Product p, ProductImage i
                    where p.ProductId = i.ProductId and i.IsThumbnail = 1 and p.ProductId = {productId}";
        }
        public static string GetNearestShipperByWard(int wardId)
        {
            return $@"SELECT TOP(1) s.ShipperId Number
                    FROM Shipper s, AppUser au
                    WHERE s.UserId = au.UserId AND au.Ward = {wardId} AND s.Status = 1";
        }

        public static string GetDistrictByWardId(int wardId)
        {
            return $@"SELECT DISTINCT d.DistrictId Number
                    FROM Ward w, District d
                    WHERE w.District = d.DistrictId AND w.WardId = {wardId}";
        }

        public static string GetNearestShipperByDistrictId(int districtId)
        {
            return $@"SELECT TOP(1) ShipperId Number
                    FROM Shipper s, AppUser au, Ward w
                    WHERE s.UserId = au.UserId and au.Ward = w.WardId and w.District = {districtId} AND s.Status = 1";
        }
        public static string GetStoreAddressById(int storeId)
        {
            return $@"SELECT w.WardName AS Ward, d.DistrictName AS District, p.ProvinceName as Province
                    FROM Store s, AppUser u, Ward w, District d, Province p
                    WHERE s.StoreId = {storeId} AND s.UserId = u.UserId AND u.Ward = w.WardId AND w.District = d.DistrictId AND d.Province = p.ProvinceId";
        }

        public static string GetCustomerAddressById(int customerId)
        {
            return $@"SELECT w.WardName AS Ward, d.DistrictName AS District, p.ProvinceName as Province
                    FROM Customer c, AppUser u, Ward w, District d, Province p
                    WHERE c.CustomerId = {customerId} AND c.UserId = u.UserId AND u.Ward = w.WardId AND w.District = d.DistrictId AND d.Province = p.ProvinceId";
        }

        public static string GetWardIdOfStore(int storeId)
        {
            return $@"SELECT a.Ward AS Number
                    FROM Store s, AppUser a
                    WHERE s.UserId = a.UserId AND s.StoreId = {storeId}";
        }

        public static string GetWardIdOfCustomer(int customerId)
        {
            return $@"SELECT a.Ward AS Number
                    FROM Customer c, AppUser a
                    WHERE c.UserId = a.UserId AND c.CustomerId = {customerId}";
        }

        public static string GetCustomerOrderHistory(int customerId)
        {
            return $@"SELECT o.CustomerId, o.OrderId, o.OrderCode, o.ShipperId, 
                            o.StoreId, o.OrderStatus, o.OrderTotal, 
                            o.DeliveryAddress, o.DeliveryDate,
                            o.CreateDate, o.ReceiverName, o.ReceiverPhone,
                            a1.Name AS ShipperName,
                            a2.Name AS StoreName
            FROM CusOrder o, AppUser a1, AppUser a2, Shipper sh, Store s 
            WHERE o.CustomerId = {customerId} AND sh.ShipperId = o.ShipperId AND s.StoreId = o.StoreId AND sh.UserId = a1.UserId AND s.UserId = a2.UserId";
        }


        public static string GetBasicStoreInformation(int storeId)
        {
            return $@"SELECT a.AccountId, a.UserId, a.Name, a.Phone, a.Address, s.StoreId, s.StoreType, 
                     s.Area, s.Status, s.Categories, s.Certificate
                     FROM AppUser a, Store s
                     WHERE a.UserId = s.UserId and s.Status != 0 and s.StoreId = {storeId} ";
        }

        public static string GetBasicStoreInformationByUserId(int userId)
        {
            return $@"SELECT a.AccountId, a.UserId, a.Name, a.Phone, a.Address, s.StoreId, s.StoreType, 
                     s.Area, s.Status, s.Categories, s.Certificate
                     FROM AppUser a, Store s
                     WHERE a.UserId = s.UserId and s.UserId = {userId} ";
        }

        public static string GetUserInfoByUsername(string username)
        {
            return $@"SELECT ap.*
                    FROM Account a, AppUser ap
                    WHERE a.AccountId = ap.AccountId AND a.Username = '{username}'";
        }

        public static string GetStoreIdByWardId(int wardId)
        {
            return $@"SELECT u.userId,s.StoreId,s.StoreType,s.Status,s.Area,s.Categories,s.Certificate
                      FROM dbo.AppUser u,dbo.Store s 
                      WHERE u.UserId = s.UserId and  u.Ward = {wardId};";
        }

        public static string GetStoreIdByDistrictId(int districtId)
        {
            return $@"SELECT u.userId,s.StoreId,s.StoreType,s.Status,s.Area,s.Categories,s.Certificate 
                      FROM dbo.Store s, dbo.AppUser u,dbo.Ward w 
                      WHERE u.Ward = w.WardId and u.UserId = s.UserId and w.District = {districtId}";
        }

        public static string GetStoreIdByProvinceId(int provinceId)
        {
            return $@"SELECT u.userId,s.StoreId,s.StoreType,s.Status,s.Area,s.Categories,s.Certificate
                      FROM dbo.Store s, dbo.AppUser u,dbo.Ward w,District d 
                      WHERE u.UserId = s.UserId and u.Ward = w.WardId and w.District = d.DistrictId and d.Province = {provinceId}";
        }

        public static string GetProductsByStoreId(int storeId)
        {
            return $@"SELECT p.ProductId, p.ProductName, p.UnitPrice, p.QuantitativeUnit, pi.Source AS Thumbnail
                        FROM Product p, ProductImage pi
                        WHERE p.StoreId = {storeId} AND pi.ProductId = p.ProductId AND pi.IsThumbnail = 1";
        }

        public static string GetOrderDetailProduct(int orderId)
        {
            return $@"SELECT od.OrderDetailId,o.OrderId,p.ProductId,p.ProductName,od.UnitPrice,od.Quantity,pim.Source 
                      FROM Product p,ProductImage pim,OrderDetail od, CusOrder o
                      WHERE p.ProductId = pim.ProductId and p.ProductId = od.ProductId 
                      and o.OrderId = od.OrderId and pim.IsThumbnail = 1 and o.OrderId = {orderId};";
        }

        public static string GetOrderDetail(int customerId, int orderId)
        {
            return $@"SELECT o.CustomerId, o.OrderId, o.OrderCode, o.ShipperId, 
                            o.StoreId, o.OrderStatus, o.OrderTotal, 
                            o.DeliveryAddress, o.DeliveryDate,
                            o.CreateDate, o.ReceiverName, o.ReceiverPhone,
                            a1.Name AS ShipperName,
                            a2.Name AS StoreName
            FROM CusOrder o, AppUser a1, AppUser a2, Shipper sh, Store s 
            WHERE o.CustomerId = {customerId} AND sh.ShipperId = o.ShipperId AND s.StoreId = o.StoreId AND sh.UserId = a1.UserId AND s.UserId = a2.UserId AND o.OrderId={orderId}";
        }

        public static string GetStoreByUsername(string username)
        {
            return $@"SELECT StoreId,StoreType,Status,Area,Categories,Certificate,u.UserId
                      FROM dbo.Account a, dbo.AppUser u,dbo.Store s 
                      WHERE a.AccountId = u.AccountId and u.UserId = s.UserId and Username = {username}";
        }

        public static string GetOrderDetailStore(int storeId, int orderId)
        {
            return $@"SELECT o.CustomerId, o.OrderId, o.OrderCode, o.ShipperId, 
                            o.StoreId, o.OrderStatus, o.OrderTotal, 
                            o.DeliveryAddress, o.DeliveryDate,
                            o.CreateDate, o.ReceiverName, o.ReceiverPhone,
                            a1.Name AS ShipperName,
                            a2.Name AS StoreName
            FROM CusOrder o, AppUser a1, AppUser a2, Shipper sh, Store s 
            WHERE o.StoreId = {storeId} AND sh.ShipperId = o.ShipperId AND s.StoreId = o.StoreId AND sh.UserId = a1.UserId AND s.UserId = a2.UserId AND o.OrderId={orderId}";
        }

        public static string GetProductTypeList()
        {
            return $@"SELECT * FROM ProductType";
        }
    }
}
