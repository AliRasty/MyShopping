namespace Shop.Application.Contract.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double UnitPrice { get; set; }
        public string Category { get; set; }
        public string Picture { get; set; }
        public long Categoryid { get; set; }

        public string CreationDate { get; set; }
    }
}