namespace ObjectOrientedDesignPrinciplesTask.Vehicles
{
    public class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public uint Quantity { get; set; }
        public double Price { get; set; }

        public Vehicle()
        { }
        
        public Vehicle(string type, string model, uint quantity, double price)
        {
            Type = type;
            Model = model;
            Quantity = quantity;
            Price = price;
        }
    }
}
