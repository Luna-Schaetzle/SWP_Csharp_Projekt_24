namespace DnD_Archive.Models
{
    public class Spells
    {

        public int SpellsId { get; set; }
        public CharacterSheet CharacterSheet { get; set; }

        public int SpellLvl { get; set; }
        public String SpellName { get; set; }
        public String SpellDamage { get; set; }
        public String SpellAbility { get; set; }
        
        

    }
}
