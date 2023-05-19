namespace CometFoodDelivery.Models
{
    public class statusReturn
    {
        public int? Status { get; set; }
    }
    public class errorReturn
    {
        public int Status { get; } = 400;
        public string Error { get; set; } = null!;
    }
}
