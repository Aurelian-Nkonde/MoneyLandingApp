using System;
using System.Collections.Generic;
using System.Linq;
using moneylandingApp.Data;
using moneylandingApp.Models;


namespace moneylandingApp.Structure
{
    public class LandingMoneyRepository : ILandingMoney
    {
        private readonly ApplicationDbContext _databaseContext;

        public LandingMoneyRepository(ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void RequestCashFromOrganisation(Borrower dataRequestingCash)
        {
            _databaseContext.borrowers.Add(dataRequestingCash);
            _databaseContext.SaveChanges();
        }
    }
}