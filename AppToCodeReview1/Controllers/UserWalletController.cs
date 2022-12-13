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
        [HttpPost(Name ="Add User")]
        public void SetUser([FromBody] User user)
        {
            var repo = new UserRepository(new UserWalletContext());
            repo.AddUser(user);

        }
        [HttpPost(Name = "Add Card")]
        public void AddCard([FromBody] Card card)
        {
            var repo = new UserRepository(new UserWalletContext());
            repo.AddCard(card);

        }
        [HttpPost]
        public string GetName([FromQuery] int UserId)
        {
            var db = new UserWalletContext();
            var user = db.Users.Single(p => p.UserId == UserId);

            return user.UserName;
        }
        [HttpGet]
        public ActionResult<User> User(int UserId)
        {
            var db = new UserWalletContext();
            return db.Users.Single(p=>p.UserId == UserId);
        }
        [HttpGet]
        public string GetMonney([FromBody] int UserId, decimal value)
        {
            var db = new UserWalletContext();
            var user = db.Users.Single(p=>p.UserId == UserId);
            string availableCards = "";
            foreach (var item in user.Wallet.Cards)
            {
                if (item.Credits >= (double)value)
                {
                    availableCards += item.CardNumber+", ";
                }
            }
            if (availableCards.Length> 0) {
                availableCards.Remove(availableCards.Length-2);
            }
            return availableCards;

        }
    }
}