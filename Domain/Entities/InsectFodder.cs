namespace Domain.Entities
{
    public class InsectFodder
    {
        public Guid InsectId { get; set; }
        public Guid FodderId { get; set; }
        public float FodderConsumptionVolume { get; set; }
    }
}