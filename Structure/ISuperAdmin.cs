using System;
using System.Collections.Generic;
using moneylandingApp.Models;


namespace moneylandingApp.Structure
{
    public  interface ISuperAdmin
    {
        Task<IEnumerable<Borrower>> GetAListOfAllBorrowers();
        void ChangingOurBalance(OurBankAmount newBalance);
        Borrower ViewingBorrowerDetails(int borrowerId);
        void RepayingCashFromBorrower(int borrowerCash);

        void AddingBankBalance(OurBankAmount bankBalance);

        void UpdatingBankBalance(OurBankAmount banco);
        void RejectingRequest(int id);
        void AcceptingRequest(int id);

    }
}