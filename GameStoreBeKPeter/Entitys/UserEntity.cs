using System.ComponentModel.DataAnnotations;
using GameStoreBeKPeter.VideoGames;


namespace GameStoreBeKPeter.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public List<VideoGame> VideoGames { get; } = new();

        [EmailAddress, MaxLength(150, ErrorMessage = "MaxLength is 150")]
        public string? Email { get; set; }

        [MaxLength(255, ErrorMessage = "MaxLength is 255")]
        public string? PasswordHash { get; set; }
    }
}
