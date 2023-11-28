using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Practic.DAL.Entities;

namespace EF_Practic.DAL.Repositories
{
    internal class PracticContext: DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<BookEntity> Books { get; set; }
        
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ROMAN\SQLEXPRESS;Database=EF;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}

//Data Source=ROMAN\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False" localhost
//Data Source=ROMAN\SQLEXPRESS01;Database=EF;Trusted_Connection=True;TrustServerCertificate=true