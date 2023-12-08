namespace _12_08.Dtos
{
    public class StockDto
    {
        public string Barcode { get; set; } = null!; //Inventory

        public decimal? Qty { get; set; }

        public string? Name { get; set; } //Item
    }
}
