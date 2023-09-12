namespace SalesWebMvc7.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Sellers> Sellers { get; set; } = new List<Sellers>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Sellers seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
            // LINQ com Lambda
            // pega a lista de vendedores e retorna a soma de cada resultado de TotalSales de cada vendedor,
            // isso já passando o pegando o periodo de data
        }
    }
}
