namespace PayRollApi.Models
{
    public class Bonus
    {
        public int Id { get; set; }
        public float MinLimit { get; set; }
        public BonusType BonusType { get; set; }
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }

    }
}