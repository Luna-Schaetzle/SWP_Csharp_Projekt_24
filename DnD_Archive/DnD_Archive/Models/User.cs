using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Archive.Models
{
    // vereinfachte Klassen (ohne Überprüfung in den set-Methoden, ohne ctor's, ohne ToString())
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    

        //Ctor's

        //ToString()

    

    }
}
