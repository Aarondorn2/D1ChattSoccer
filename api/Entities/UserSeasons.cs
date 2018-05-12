using System;

namespace D1SoccerService.Entities {
    public partial class UserSeasons {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int SeasonId { get; set; }
        public int? PaymentId { get; set; }
        public int? TeamId { get; set; }
        public bool HasPaid { get; set; }
        public bool HasWaiver { get; set; }
        public bool HasTeam { get; set; }
        public DateTime SystemLoadDate { get; set; }
        public DateTime SystemUpdateDate { get; set; }
        public int? WaiverId { get; set; }

        public Users User { get; set; }
        public Waivers Waiver { get; set; }
    }
}
