using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace DnD_Archive.Models
{
    // vereinfachte Klassen (ohne Überprüfung in den set-Methoden, ohne ctor's, ohne ToString())
    public class CharInfo
    {
        [Key]
        public int InfoID { get; set; }

        public string personalitTraits { get; set; }

        public string Bonds {  get; set; }
        public string Ideals { get; set; }

        public string Flaws { get; set; }

        public string AdditionalInfo {  get; set; }


        //Ctor's

        //ToString()



    }
}
