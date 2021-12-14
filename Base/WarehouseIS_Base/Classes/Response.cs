using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseIS_Base.Classes;
namespace WarehouseIS_Base.Classes
{
    public class Response
    {
        public List<Item.Item> Items { get; set; }
        public double Total { get; set; }
        public bool Allowed;

        public Response(List<Item.Item> items)
        {
            Items = items;
            Allowed = CheckItems(items);
            if(Allowed)
            {
                Total = CalcPrice(items);
                DBsimulation.Responses.Add(this);
            }
            else
            {
                Total = 0;
            }
        }

        public bool CheckItems(List<Item.Item> items)
        {
            var dbCopy = DBsimulation.Items;
            foreach(var item in items)
            {
               var dbItem = dbCopy.FirstOrDefault(s => s.Id == item.Id);
               if(dbItem != null)
               {
                    if(dbItem.Count > item.Count)
                    {
                        dbItem.Count -= item.Count;
                        dbItem.Reserved += item.Count;
                    }
                    else
                    {
                        return false;
                    }
               }
               else
               {
                   return false;
               }
            }
            DBsimulation.Items = dbCopy;
            return true;
        }

        public double CalcPrice(List<Item.Item> items)
        {
            return items.Sum(item => item.Price * item.Count);
        }
    }
}
