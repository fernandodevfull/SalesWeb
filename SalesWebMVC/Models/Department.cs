namespace SalesWebMVC.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department(){ }

        public Department(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }

        public void AddSaller( Seller s)
        {
            Sellers.Add(s);
        }

        public double TotalSaless(DateTime initial,DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial,final));
        }

    }


}
