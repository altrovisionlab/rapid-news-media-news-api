using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace rapid_news_media_news_api.Models
{
    public class NewsDBContext : DbContext
    {
        public NewsDBContext(DbContextOptions<NewsDBContext> options) : base(options) { }

        public DbSet<NewsReport> NewsReports { get; set; } = null!;

        //Data seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsReport>().HasData(
                new NewsReport {Id = 1, Title = "Developer behind £57m Bushmills Resort says it will be 'first for north'", Category = "IRISH_NEWS", Description = "THE 355 (Cert 12, 123 mins, Universal Pictures (UK) Ltd, Action/Thriller/Romance, available from March 28 on BT TV Store/iTunes/Prime Video/Sky Store/TalkTalk TV Store and other download and streaming services) Starring: Jessica Chastain, Diane Kruger, Lupita Nyong'o, Penelope Cruz, Fan Bingbing, Sebastian Stan, Edgar Ramirez, Jason Flemyng A DRUG bust south of Bogota fortuitously interrupts the sale of a portable hard drive capable of hacking every network on the planet including nuclear launch sites, power grids, financial markets and airplane operating systems.", ImageUrl = "https://www.irishnews.com/picturesarchive/irishnews/irishnews/2022/03/31/181107893-2c9a7197-45ba-44b8-8e14-91abc94d2865.jpg", CreatedBy = "sergiu@email.com", DateCreated = new DateTime()}
                );
        }

    }
}