using System;

namespace D1SoccerService.Entities {
    public partial class CachedUsers {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Uid { get; set; }
        public DateTime CacheTime { get; set; }
        public string Email { get; set; }
        public int? UserId { get; set; }
    }
}
