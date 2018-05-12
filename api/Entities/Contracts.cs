using System;
using System.Collections.Generic;

namespace D1SoccerService.Entities {
    public partial class Contracts {
        public Contracts() {
            Waivers = new HashSet<Waivers>();
        }

        public int Id { get; set; }
        public string ContractName { get; set; }
        public string ContractDisplayName { get; set; }
        public string ContractText { get; set; }
        public DateTime ContractValidStartDate { get; set; }
        public DateTime ContractValidEndDate { get; set; }
        public DateTime SystemLoadDate { get; set; }

        public ICollection<Waivers> Waivers { get; set; }
    }
}
