using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository
    {
        UserWalletContext context;
        public UserRepository(UserWalletContext context) {
           
            this.context = context;
        }
        public void AddUser(User user)
        {
            try
            {
                context.Add(user);

            }catch(Exception ex)
            {

            }
         }
        public void AddCard(int userId, Card card)
        {
            var user = context.Users.Single(p=>p.UserId == userId);
            if (user.Wallet != null)
            {
                user.Wallet.Cards.Add(card);
            }
            else
            {
                user.Wallet = new Wallet();
                user.Wallet.Cards.Add(card);
            }

        }
    }
}
