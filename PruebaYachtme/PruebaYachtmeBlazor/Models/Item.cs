namespace PruebaYachtmeBlazor.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Status { get; set; } // 1 for done, 0 for not done
        public DateTime DueDate { get; set; }
    }
}
