using System;
using System.Collections.Generic;

namespace KairoBank.Data
{
    public partial class Offer
    {
        public int Id { get; set; }
        public string SpecialityCode { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
