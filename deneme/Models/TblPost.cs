using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace deneme.Models
{
    public partial class TblPost
    {
        [Key]

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string? PostResim { get; set; }
    }
}
