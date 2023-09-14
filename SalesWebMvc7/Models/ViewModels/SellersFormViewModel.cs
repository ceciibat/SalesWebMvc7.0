namespace SalesWebMvc7.Models.ViewModels
{
    public class SellersFormViewModel
    {
        public Sellers Sellers { get; set; }
        public ICollection<Department> Departments { get; set; }

    }
}
