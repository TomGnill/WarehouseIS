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
            List<Item.Item> DBCopy = DBsimulation.Items;
            foreach(Item.Item item in items)
            {
               Item.Item DBItem = DBCopy.FirstOrDefault(s => s.Id == item.Id);
               if(DBItem != null)
               {
                    if(DBItem.Count > item.Count)
                    {
                        DBItem.Count -= item.Count;
                        DBItem.Reserved += item.Count;
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
            DBsimulation.Items = DBCopy;
            return true;
        }

        public double CalcPrice(List<Item.Item> items)
        {
            double sum = 0;
            foreach(var item in items)
            {
                sum += item.Price * item.Count;
            }
            return sum;
        }
    }
}
