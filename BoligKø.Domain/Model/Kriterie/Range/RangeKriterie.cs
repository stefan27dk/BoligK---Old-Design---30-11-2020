namespace BoligKø.Domain.Model
{
    public abstract class RangeKriterie : IValidateableKriterie
    {
        
        public double Fra { get; set; }
        public double Til { get; set; }
        public RangeKriterie(double fra, double til)
        {
            this.Fra = fra;
            this.Til = til;
        }

    }
}
