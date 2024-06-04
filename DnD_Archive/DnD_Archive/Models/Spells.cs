using System.ComponentModel.DataAnnotations;

namespace DnD_Archive.Models
{
    public class Spells
    {
        [Key]
        public int ID { get; set; }
        
        //User ID is the foreign key
        public int UserID { get; set; }

        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        
        [MaxLength(100)]
        public string CastingTime { get; set; }


        public int Range { get; set; }
        
        [MaxLength(100)]
        public string Duration { get; set; }
        public string Description { get; set; }

        //Ctor's

        //ToString()

    }
}
