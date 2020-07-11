using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLib.Models
{
    public class MovieModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public string PictureURL { get; set; }
        public string Description { get; set; }
    }
}
