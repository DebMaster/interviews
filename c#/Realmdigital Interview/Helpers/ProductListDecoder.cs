﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Realmdigital_Interview.Helpers
{
    public class ProductListDecoder: Base, IProductListResponse
    {
        public List<object> decodeResponse(List<ApiResponseProduct> reponseObject)
        {
            for (int i = 0; i < reponseObject.Count; i++)
            {
                var prices = new List<object>();
                for (int j = 0; j < reponseObject[i].PriceRecords.Count; j++)
                {
                    if (reponseObject[i].PriceRecords[j].CurrencyCode == "ZAR")
                    {
                        prices.Add(new
                        {
                            Price = reponseObject[i].PriceRecords[j].SellingPrice,
                            Currency = reponseObject[i].PriceRecords[j].CurrencyCode
                        });
                    }
                }
                result.Add(new
                {
                    Id = reponseObject[i].BarCode,
                    Name = reponseObject[i].ItemName,
                    Prices = prices
                });
            }
            return result;
        }
        public static object decodeResponse(object obj) {
            return null;
        }
    }
}