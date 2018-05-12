using System;

namespace D1SoccerService.Entities {
    public partial class Teams {
        public int Id { get; set; }
        public string CaptainFirstName { get; set; }
        public string CaptainLastName { get; set; }
        public string TeamName { get; set; }
        public string TeamColor { get; set; }
        public DateTime SystemLoadDate { get; set; }
        public DateTime SystemUpdateDate { get; set; }
        public int CaptainId { get; set; }
    }
}
