namespace Domain.Entities
{
    public class InsectLivingPlase
    {
        public Guid InsectId { get; set; }
        public Guid LivingPlaseId { get; set; }
        public int InsectCount { get; set; }
        public DateTime SettlementDate { get; set; }
    }
}