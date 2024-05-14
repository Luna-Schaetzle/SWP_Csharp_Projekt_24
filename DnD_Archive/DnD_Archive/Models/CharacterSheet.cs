using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Archive.Models
{
    // vereinfachte Klassen (ohne Überprüfung in den set-Methoden, ohne ctor's, ohne ToString())
    public class CharacterSheet
    {
        [Key]
        public int SheetId { get; set; }
        public int UserdId { get; set; }
        public string CharName { get; set; }
        public string Content { get; set; }

        /*
        public CharInfo CharInfo { get; set; }
        public CharStat CharStat { get; set; }
        public Inventory Inventory {  get; set; }      
        */


        //Ctor's

        //ToString()



    }
}
