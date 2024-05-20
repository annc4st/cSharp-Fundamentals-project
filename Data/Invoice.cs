namespace TodoList2.Data
{
    public class Invoice
    {
        public int Id { get; set; }
        public string? Details { get; set;}
        public string? ToFrom { get; set; }

        public double? Amount { get; set;}
    }
}