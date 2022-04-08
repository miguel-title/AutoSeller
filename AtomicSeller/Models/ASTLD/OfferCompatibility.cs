using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicSeller.Models.ASTLD
{
    public partial class OfferCompatibility
    {
        public int OfferCompatibilityId { get; set; }
        public int? OfferOwnedId { get; set; }
        public int? OfferProposedId { get; set; }
        public string Compatibility { get; set; }
    }
}
