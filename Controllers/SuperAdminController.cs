using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using moneylandingApp.Models;
using moneylandingApp.Structure;
using moneylandingApp.Data;


namespace moneylandingApp.Controllers
{
    public class  SuperAdminController: Controller
    {
        private readonly ISuperAdmin _superAdminRepoInterface;
        private readonly ApplicationDbContext _databaseContext;

        public SuperAdminController(ISuperAdmin superAdminRepoInterface, ApplicationDbContext databaseContext)
        {
            _superAdminRepoInterface = superAdminRepoInterface;
            _databaseContext = databaseContext;
        }
        
        public async Task<IActionResult> AdminPanel()
        {
            var borrowersList = await _superAdminRepoInterface.GetAListOfAllBorrowers();
            var approvedBorrowerList =  borrowersList.Where(e => e.Approved == true);
            return View(approvedBorrowerList);
        }


        public IActionResult ChangeOurBankAmount()
        {
            var firstValue = _databaseContext.ourBankAmounts.Where(a => a.Amount >= 100).First();
            return View(firstValue);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeOurBankAmount(OurBankAmount newAmountFromSuperAdmin)
        {
            if(ModelState.IsValid)
            {
                var changingourFirstValue = _databaseContext.ourBankAmounts.Where(e => e.Amount >= 100).First();
                if(newAmountFromSuperAdmin.Amount >= 100 &&  newAmountFromSuperAdmin.Amount <= 100000)
                {
                    _superAdminRepoInterface.UpdatingBankBalance(changingourFirstValue);
                    return RedirectToAction("AdminPanel");
                }
                Console.WriteLine($"this is our first value amount id  {changingourFirstValue.Id}");
                return View(newAmountFromSuperAdmin);
            }
            return View(newAmountFromSuperAdmin);
        }


        public IActionResult AddOurBankAmount()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOurBankAmount(OurBankAmount bankAmountToAdd)
        {
            if(ModelState.IsValid)
            {
                if(bankAmountToAdd.Amount >= 100)
                {
                    var bank = _databaseContext.ourBankAmounts.Where(e => e.Amount >= 1).ToList();
                    if(bank.Count() <= 0)
                    {
                    _superAdminRepoInterface.AddingBankBalance(bankAmountToAdd);
                    return RedirectToAction("AdminPanel");
                    }
                    return View(bankAmountToAdd);
                }
                return View(bankAmountToAdd);
            }
            return View(bankAmountToAdd);
        }



        public IActionResult ViewCurrentBalance()
        {
            var data = _databaseContext.ourBankAmounts.FirstOrDefault(e => e.Amount >= 0);
            return View(data);
        }


        public IActionResult ViewBorrowerDetails(int id)
        {
            if(id == 0){ return NotFound(); }
            var findingBorrowerMatchedById = _databaseContext.borrowers.FirstOrDefault(a =>  a.Id == id);
            if( findingBorrowerMatchedById == null)
            {
                return NotFound();
            }
            return View(findingBorrowerMatchedById);
        }


        public IActionResult RepayMoney(int id)
        {
            if(id == 0){ return NotFound(); }
            _superAdminRepoInterface.RepayingCashFromBorrower(id);
            return RedirectToAction("AdminPanel");
        }

        public  IActionResult SendBorrowerEmail(int id)
        {
            if(id == 0){ return NotFound(); }
            Borrower findTheUserWithTheSameId = _databaseContext.borrowers.FirstOrDefault(e => e.Id == id);
            if(findTheUserWithTheSameId == null){ return NotFound(); }
            return View(findTheUserWithTheSameId);
        }


        public async Task<IActionResult> ListOfPendingRequests()
        {
            IEnumerable<Borrower> listOfPendingRequest = await _superAdminRepoInterface.GetAListOfAllBorrowers();
            var pendingRequest = from n in listOfPendingRequest
                                where n.Approved != false && n.Approved != true
                                select n;
            return View(pendingRequest);
        }


        public async Task<IActionResult> ListOfRejectedRequests()
        {
            IEnumerable<Borrower> listOfRejectedRequest = await _superAdminRepoInterface.GetAListOfAllBorrowers();
            var rejectedRequest = listOfRejectedRequest.Where(e => e.Approved != true);
            return View(rejectedRequest);
        }


        public IActionResult ApproveRequest(int id)
        {
            if(id == 0){ return NotFound(); }
            // Borrower findingTheBorrower = _databaseContext.borrowers.FirstOrDefault(e => e.Id == id);
            _superAdminRepoInterface.AcceptingRequest(id);
            return RedirectToAction("AdminPanel");

        }


        public IActionResult RejectRequest(int id)
        {
            if(id == 0){ return NotFound(); }
            // Borrower findingTheBorrower =  _databaseContext.borrowers.FirstOrDefault(e => e.Id == id);
            _superAdminRepoInterface.RejectingRequest(id);
            return RedirectToAction("AdminPanel");
        }


        public IActionResult oops()
        {
            return View();
        }

    }
}
