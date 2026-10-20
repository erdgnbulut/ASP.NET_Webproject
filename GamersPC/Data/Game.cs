using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace efcoreApp.Data
{
    public class Game
    {
        public int GameId {get; set;}
        public string? GameName {get; set;}
        public string? GamePublisher {get; set;}
        public string? GameDeveloper {get; set;}
        public string? GameDiscription {get; set;}
        public string? GameTrailerPath {get; set;}
        public int? MetaCriticScore {get; set;}
        public int? GameTopListNo {get; set;}
        public int? GamePopularityNo {get; set;}
        public float? GamePrice {get; set;}
        public byte[]? GameImage {get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName ="date")]
        public DateTime? GameReleaseDate {get; set;}

        public ICollection<UserGame>? UserGames { get; set; }
    }
}