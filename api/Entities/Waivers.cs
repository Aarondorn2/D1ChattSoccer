using System;

namespace D1SoccerService.Entities {
    public partial class Waivers {
        public int Id { get; set; }
        public int? ContractId { get; set; }
        public string AcceptedName { get; set; }
        public string AcceptedEmail { get; set; }
        public string AcceptedIpaddress { get; set; }
        public bool HasAccepted { get; set; }
        public DateTime AcceptedDate { get; set; }
        public DateTime SystemLoadDate { get; set; }

        public Contracts Contract { get; set; }
        public UserSeasons UserSeason { get; set; }
    }
}
