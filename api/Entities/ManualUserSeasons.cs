using System;

namespace D1SoccerService.Entities {
    public partial class ManualUserSeasons {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int SeasonId { get; set; }
        public int? PaymentId { get; set; }
        public int? TeamId { get; set; }
        public bool HasPaid { get; set; }
        public bool HasWaiver { get; set; }
        public bool HasTeam { get; set; }
        public DateTime SystemLoadDate { get; set; }
        public DateTime SystemUpdateDate { get; set; }
    }
}
