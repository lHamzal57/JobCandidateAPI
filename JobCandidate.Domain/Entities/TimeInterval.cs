namespace JobCandidate.Domain.Entities
{
    public class TimeInterval
    {

        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public bool IsValid()
        {
            return Start < End;
        }
    }
}
