using System;
using Microsoft.EntityFrameworkCore;
using moneylandingApp.Models;


namespace moneylandingApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt): base(opt)
        {
            
        }
        public DbSet<OurBankAmount> ourBankAmounts { get;set; }
        public DbSet<Borrower> borrowers { get;set; }
    }
}