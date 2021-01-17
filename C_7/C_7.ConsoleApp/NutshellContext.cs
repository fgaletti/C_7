using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Linq.Mapping;


namespace C_7.ConsoleApp
{
    public class NutshellContext : DataContext
    {
        public NutshellContext(string cxString) : base(cxString) { }

        public Table<Customer> Customers { get { return GetTable<Customer>(); } }
        public Table<Purchase> Purchases { get { return GetTable<Purchase>(); } }
    }
    [Table]
    public partial class Customer
    {
        [Column(IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string Name { get; set; }

        [Association(OtherKey = "CustomerID")]
        public EntitySet<Purchase> Purchases = new EntitySet<Purchase>();
    }
    [Table]
    public  class Purchase
    {
        [Column(IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public Nullable<int> CustomerID { get; set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public decimal Price { get; set; }

        EntityRef<Customer> custRef;

        [Association (Storage ="custRef", ThisKey ="CustomerID", IsForeignKey =true)]
        public Customer Customer
        {
            get { return custRef.Entity; }
            set { custRef.Entity = value; }
        }
    }


}
