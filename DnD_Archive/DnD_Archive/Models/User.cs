using System.ComponentModel.DataAnnotations;


namespace DnD_Archive.Models
{
    // vereinfachte Klassen (ohne Überprüfung in den set-Methoden, ohne ctor's, ohne ToString())
    public class User
    {
        [Key]
        public int UserID { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 3)] 
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }


        //Ctor's

        //ToString()



    }
}
