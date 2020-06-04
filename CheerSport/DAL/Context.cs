using CheerSport.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheerSport.DAL
{
    public class Context:DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Club> Club { get; set; }
        public DbSet<Competition> Competition { get; set; }
        public DbSet<Judge> Judge { get; set; }
        public DbSet<JudgeCategory> JudgeCategory { get; set; }
        public DbSet<JudgeCompetition> JudgeCompetition { get; set; }
        public DbSet<JudgePosition> JudgePosition { get; set; }
        public DbSet<SportCategory> SportCategory { get; set; }
        public DbSet<SportRang> SportRang { get; set; }
        public DbSet<Sportsmen> Sportsmen { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<UnionRK> UnionRK { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CheerSportDB;Integrated Security = True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Для связи "многие ко многим"
            //судья и ДТП
            modelBuilder.Entity<JudgeCompetition>()
                .HasOne(sc => sc.judge)
                .WithMany(s => s.JudgeCompetition)
                .HasForeignKey(sc => sc.Judgeid);

            modelBuilder.Entity<JudgeCompetition>()
                .HasOne(sc => sc.competition)
                .WithMany(c => c.JudgeCompetition)
                .HasForeignKey(sc => sc.Competitionid);


        }


    }
}
