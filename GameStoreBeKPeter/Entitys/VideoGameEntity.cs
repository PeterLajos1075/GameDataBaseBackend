using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using GameStoreBeKPeter.Users;
using System.Text.Json.Serialization;

namespace GameStoreBeKPeter.VideoGames
{
    public enum Type { Akció, Kaland, Coop, Oktató, Túlélő }
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public List<User> Users { get; } = new();

        [MaxLength(100,ErrorMessage ="MaxLength is 100")]
        public string Title { get; set; }

        [MaxLength(255, ErrorMessage = "MaxLength is 255")]
        public string Description { get; set; }

        public Type Type { get; set; }

        public int Price { get; set; }

        [RegularExpression(@"^[0-5]*$")]
        public int Rating { get; set; }
    }
}
