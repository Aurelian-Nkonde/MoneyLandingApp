using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using moneylandingApp.Data;
using moneylandingApp.Models;


namespace moneylandingApp.Structure
{
    public class SuperAdminRepository : ISuperAdmin
    {
        private readonly ApplicationDbContext _databaseContext;

        public SuperAdminRepository(ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public void ChangingOurBalance(OurBankAmount newBalance)
        {
            _databaseContext.ourBankAmounts.Update(newBalance);
            _databaseContext.SaveChanges();
        }


        public async Task<IEnumerable<Borrower>> GetAListOfAllBorrowers()
        {
            return  await _databaseContext.borrowers.ToListAsync();
    
        }

        public void RepayingCashFromBorrower(int borrowerId)
        {
            var changingTheBorrowerStatus = _databaseContext.borrowers.FirstOrDefault(e => e.Id == borrowerId);
            if(changingTheBorrowerStatus == null){
                throw new ArgumentNullException();
            }
            changingTheBorrowerStatus.Repayed = true;
            _databaseContext.SaveChanges();
        }

        public Borrower ViewingBorrowerDetails(int borrowerId)
        {
            Borrower singleBorrower = _databaseContext.borrowers.FirstOrDefault(e => e.Id == borrowerId);
            return singleBorrower;
        }


        public void UpdatingBankBalance(OurBankAmount balanceToAdd)
        {
            _databaseContext.ourBankAmounts.Update(balanceToAdd);
            _databaseContext.SaveChanges();
        }

        public void AddingBankBalance(OurBankAmount balanceToAdd)
        {
            _databaseContext.ourBankAmounts.Add(balanceToAdd);
            _databaseContext.SaveChanges();
        }

        public void RejectingRequest(int id)
        {
            var reject = _databaseContext.borrowers.FirstOrDefault(e => e.Id == id);
            if(reject == null)
            {
                throw new ArgumentNullException(nameof(reject));
            }
            reject.Approved = false;
            _databaseContext.borrowers.Update(reject);
            _databaseContext.SaveChanges();
        }


        public void AcceptingRequest(int id)
        {
            var accept = _databaseContext.borrowers.FirstOrDefault(e => e.Id == id);
            if(accept == null)
            {
                throw new ArgumentNullException(nameof(accept));
            }
            accept.Approved = true;
            _databaseContext.borrowers.Update(accept);
            _databaseContext.SaveChanges();
        }
    }
}