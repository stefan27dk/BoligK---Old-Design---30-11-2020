﻿namespace BoligKø.ApplicationService.Dto
{
    public abstract class RangeKriterieDto : IKriterieDto
    {
        public double Fra { get; set; }
        public double Til { get; set; }
        public RangeKriterieDto(double fra, double til)
        {
            this.Fra = fra;
            this.Til = til;
            
        }
    }
}
