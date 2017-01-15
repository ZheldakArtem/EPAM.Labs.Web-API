using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Item
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The question should contain from 4 to 30 characters.", MinimumLength = 4)]
        [Exclude(new char[] { '-', '$' })]
        public string Author { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The question should contain from 4 to 30 characters.", MinimumLength = 4)]
        public string Tittle { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The question should contain from 4 to 1000 characters.", MinimumLength = 4)]
        public string Task { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }


    }
}
