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

    }
}
