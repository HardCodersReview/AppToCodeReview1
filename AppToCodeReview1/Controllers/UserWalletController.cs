using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace AppToCodeReview1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserWalletController : ControllerBase
    {

        [HttpGet(Name = "GetTotalCredits")]
        public decimal GetTotalCredits(int UserId)
        {
            var db = new UserWalletContext();
            var user = db.Users.Single(p => p.UserId == UserId);
            decimal totalCredit = 0;
            foreach(var item in user.Wallet.Cards)
            {
                totalCredit += Convert.ToDecimal(item.Credits);
            }
            return totalCredit;
        }
        public string GetName(int UserId)
        {
            var db = new UserWalletContext();
            var user = db.Users.Single(p => p.UserId == UserId);

            return user.UserName;
        }
        public ActionResult<User> User(int UserId)
        {
            var db = new UserWalletContext();
            return db.Users.Single(p=>p.UserId == UserId);
        }
        public string GetMonney(int UserId, decimal value)
        {
            var db = new UserWalletContext();
            var user = db.Users.Single(p=>p.UserId == UserId);
            string avaibleCards = "";
            foreach (var item in user.Wallet.Cards)
            {
                if (item.Credits >= (double)value)
                {
                    avaibleCards += item.CardNumber;
                }
            }
            return avaibleCards;

        }
    }
}