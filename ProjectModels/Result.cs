using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModels
{
    [Table("Result")]
    public class Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string? HomeScore { get; set; }
        [Required]
        public string? AwayScore { get; set; }
        [Required]
        public string? WinnerTeam { get; set; }

        public int MatchId { get; set; }
        [ForeignKey("MatchId")]
        public Match? Match { get; set; }
    }
}
