namespace Covid.Entities
{
    public class ReturnDto
    {
        public string? StateName { get; set; }
        public string Date { get; set; }
        public string NewCases { get; set; }
        public string RecoveredCases { get; set; }
        public string DeathCases { get; set; }
    }
}
