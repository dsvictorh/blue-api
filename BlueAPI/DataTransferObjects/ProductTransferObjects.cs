namespace BlueAPI.DataTransferObjects
{
    public class InsertUpdateProductDTO
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }

    public class GetProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = null!;
        public decimal? Discount { get; set; }
        public decimal FinalPrice { get; set;}
    }
}
