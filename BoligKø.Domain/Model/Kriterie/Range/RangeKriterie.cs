namespace BoligKø.Domain.Model
{
    public abstract class RangeKriterie : Kriterie, IValidateableKriterie
    {
        public double Fra { get; set; }
        public double Til { get; set; }
        public RangeKriterie(double fra, double til)
        {
            this.Fra = fra;
            this.Til = til;
        }

        public abstract void ValidateState();
    }
}
