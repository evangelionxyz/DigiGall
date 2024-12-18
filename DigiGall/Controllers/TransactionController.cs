using DigiGall.Data;
using Microsoft.AspNetCore.Mvc;
using DigiGall.Models;

namespace DigiGall.Controllers
{
    private readonly UserContextService _userContextService;

    public class TransactionController : BaseController
    {
        public TransactionController(UserContextService userContextService, ApplicationDbContext dbContext)
            : base(userContextService, dbContext)
        {
        }

        public ICollection<Transaction> GetAllUserTransaction() {
            string curUserId = _userContextService.id;
            var userTransactions = _dbContext.Transactions.Where(t => t.UserId == curUserId).ToList();

            return userTransactions;
        }
    }

}