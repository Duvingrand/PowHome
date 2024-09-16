using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PowHome.Models
{
    public class Posting
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public DateOnly MomentOfPost { get; set; }
        public bool IsImportant { get; set; } //if true, will appear in main
        public required int AuthorId { get; set; }

        [JsonIgnore]
        [ForeignKey("AuthorId")]
        public User User { get; set; }

    }
}