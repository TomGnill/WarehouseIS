using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseIS_Base.Classes;

namespace WarehouseIS_Base.Classes
{
    public static class ExtensionMethods
    {
        public static Response SendRequest(List<Item.Item> items)
        {
            return new Response(items);
        }

        public static List<Item.Item> GenItems_Test()
        {
            var list = new List<Item.Item>
            {
                new(1, "Каша", 100, 85, 100) { BuyDate = new DateTime(2021, 5, 10) },
                new(2, "Скотч", 150, 20, 150),
                new(3, "Гвозди", 3, 1, 1000),
                new(4, "Пиво", 75, 40, 47),
                new(5, "Чипсы", 70, 30, 126),
                new(6, "Мясо", 400, 150, 5),
                new(7, "Молоко", 90, 40, 100) { BuyDate = new DateTime(2021, 7, 10) },
                new(8, "Хлеб", 26, 15, 15)
            };

            return list;
        }

    }
}
