using System;
using System.Collections.Generic;
using moneylandingApp.Models;


namespace moneylandingApp.Structure
{
    public interface ILandingMoney
    {
        void RequestCashFromOrganisation(Borrower dataRequestingCash);
    }
}