namespace BoligKø.ApplicationService.Dto
{
    public class LokationKriterieDto : IKriterieDto
    {
        public int PostNummer { get; }
        public LokationKriterieDto(int postNummer)
        {
            this.PostNummer = postNummer;
        }
    }
}
