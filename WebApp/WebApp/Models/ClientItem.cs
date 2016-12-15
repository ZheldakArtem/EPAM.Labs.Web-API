using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ClientItem
    {
        [Required(ErrorMessage ="Id lalaalw[ew[ wef")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Author lalaalw[ew[ wef")]
        [StringLength(30, ErrorMessage = "The question should contain from 4 to 30 characters.", MinimumLength = 4)]
        public string Author { get; set; }

        [Required(ErrorMessage = "Tittle lalaalw[ew[ wef")]
        [StringLength(30, ErrorMessage = "The question should contain from 4 to 30 characters.", MinimumLength = 4)]
        public string Tittle { get; set; }

        [Required(ErrorMessage = "Task lalaalw[ew[ wef")]
        [StringLength(1000, ErrorMessage = "The question should contain from 10 to 1000 characters.", MinimumLength = 10)]
        public string Task { get; set; }

        [Required(ErrorMessage = "CreateDate lalaalw[ew[ wef")]
        public DateTime CreateDate { get; set; }
    }
}