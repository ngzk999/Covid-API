namespace Covid.Entities
{
    public class Death
    {
        public string Date { get; set; }
        public string? StateName { get; set; }
        public string NewDeath { get; set; }
        public string BidDeath { get; set; }
        public string DodDeath { get; set; }
        public string BidDodDeath { get; set; }
        public string UnvaxDeath { get; set; }
        public string PartialVaxDeath { get; set; }
        public string FullyVaxDeath { get; set; }
        public string BoostedVaxDeath { get; set; }
        public string TatDeath { get; set; }
    }
}
