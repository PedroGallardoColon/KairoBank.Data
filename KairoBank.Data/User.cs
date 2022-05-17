using System;
using System.Collections.Generic;

namespace KairoBank.Data
{
    public partial class User
    {
        public User()
        {
            Offers = new HashSet<Offer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}
