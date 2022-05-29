using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using moneylandingApp.Models;
using moneylandingApp.Structure;
using moneylandingApp.Data;


namespace moneylandingApp.Controllers
{
    public class LandingMoneyController: Controller
    {
        private readonly ILandingMoney _landingMoneyRepoContext;
        private readonly ApplicationDbContext _databaseContext;

        public LandingMoneyController(ILandingMoney landingMoneyRepoContext, ApplicationDbContext databaseContext)
        {
            _landingMoneyRepoContext = landingMoneyRepoContext;
            _databaseContext = databaseContext;
        }


        public IActionResult GetMoney()
        {
            return View();
        }

        
        public IActionResult FillingForm()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FillingForm(Borrower borrowerDataFromForm)
        {
            var currentAmountInDatabase = _databaseContext.ourBankAmounts.Where(e => e.Amount >= 0);
            if(ModelState.IsValid)
            {
                if(borrowerDataFromForm.CashAmount != 0)
                {
                    // id validation will come here
                    _landingMoneyRepoContext.RequestCashFromOrganisation(borrowerDataFromForm);
                    return RedirectToAction("doneRequesting");
                }
                return View(borrowerDataFromForm);
            }
            return View(borrowerDataFromForm);
        }


        public IActionResult doneRequesting()
        {
            return View();
        }

    }
}
