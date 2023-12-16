using System.ComponentModel;

namespace myAPI.Models
{
    public class Order
    {
        public long OrderID { get; set; }
        public string Contract { get; set; }
        public string PPLot { get; set; }
        public bool CurrentStatus { get; set; }
        public int Sequence { get; set; }
    }
}
