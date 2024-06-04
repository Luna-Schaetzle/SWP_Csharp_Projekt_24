using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Archive.Models
{
    // vereinfachte Klassen (ohne Überprüfung in den set-Methoden, ohne ctor's, ohne ToString())
    public class ForumPost
    {
        [Key]
        public int PostId { get; set; }
        public int UserdId { get; set; }
        public string PostContent { get; set; }

        /*
        public CharInfo CharInfo { get; set; }
        public CharStat CharStat { get; set; }
        public Inventory Inventory {  get; set; }      
        */


        //Ctor's
        public ForumPost() { }

        public ForumPost(int UserId, string content, int PostId)
        {

            this.UserdId = UserId;
            this.PostContent = content;
            this.PostId = PostId;
        }


        //ToString()





    }


}

