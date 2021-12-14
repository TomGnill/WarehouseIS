using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseIS_Base.Classes
{
    public class Customer : User.User
    {
        public Customer(int id, string name) : base(id, name)
        { }

        public Response SendRequest(List<Item.Item> items)
        {
            return ExtensionMethods.SendRequest(items);
        }
    }
}
