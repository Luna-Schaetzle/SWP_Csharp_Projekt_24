using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace DnD_Archive.Models.DB
{
    public class DbManager : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<CharacterSheet> CharacterSheets { get; set; }
        public DbSet<CharInfo> charInfos { get; set; }
        public DbSet<CharStat> charStats { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Spells> SpellList { get; set; }

        public DbSet<ForumPost> ForumPosts { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // für den Pomelo-MySQL-Treiber
            string connectionString = "Server=localhost;database=dnd_archive;user=root;password=flo2rian";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
