using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace DnD_Archive.Models.DB
{
    public class DbManager : Microsoft.EntityFrameworkCore.DbContext
    {

        public DbSet<User> Users { get; set; }

     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // für den Pomelo-MySQL-Treiber
            // hier wreden die MySQL-Serverdaten angegeben
            //      IP des MySQL-Servers
            //      Datenbankname ... selber angeben
            //      User/PWD ... die MySQL-Daten des Users mit dem sich der ORM bei MySQL anmelden soll
            string connectionString = "Server=localhost;database=DND_Archive;user=root;password=zwiebel55";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
