using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Archive.Models
{
    // vereinfachte Klassen (ohne Überprüfung in den set-Methoden, ohne ctor's, ohne ToString())
    public class CharStat
    {
        [Key]
        public int StatId { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set;}
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }

        public int SpellSlotsLVL1 { get; set; }
        public int SpellSlotsLVL2 { get; set; }
        public int SpellSlotsLVL3 { get; set; }
        public int SpellSlotsLVL4 { get; set; }
        public int SpellSlotsLVL5 { get; set; }
        public int SpellSlotsLVL6 { get; set; }
        public int SpellSlotsLVL7 { get; set; }
        public int SpellSlotsLVL8 { get; set; }
        public int SpellSlotsLVL9 { get; set; }




        public int ProficiencyBonus { get; set; }
        //Ctor's

        //ToString()



    }
}
