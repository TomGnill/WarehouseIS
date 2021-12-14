using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseIS_Base.Classes.Item
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double BuyPrice { get; set; }
        public double Size { get; set; }
        public int Count { get; set; }

        public DateTime BuyDate { get; set; }

        public Category Category { get; set; }

        public int Reserved { get; set; }

        public Item(int id, string name, double price, double buyPrice, int count, double size = 0, Category category = Category.unsorted, int reserved = 0)
        {
            Id = id;
            Name = name;
            Price = price;
            BuyPrice = buyPrice;
            Count = count;
            Size = size;
            Category = category;
            BuyDate = DateTime.Now;
            Reserved = reserved;
        }

    }
}
