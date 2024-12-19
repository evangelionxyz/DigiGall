using DigiGall.Data;
using DigiGall.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigiGall.Controllers
{
    public class PrefectController : BaseController
    {
        public PrefectController(UserContextService userContextService, ApplicationDbContext dbContext) : base(userContextService, dbContext)
        {
        }

        public async Task<IActionResult> Notification()
        {
            // Ambil transaksi dengan status "UnderReview"
            //var userId = HttpContext.Session.GetString("UserId");
            //var inProgressTransactions = await _dbContext.GetAllTransactionWith("UnderReview", userId, "Quest");
            var inProgressTransactions = await _dbContext.GetAllTransactionWith("UnderReview");

            // Kirim data ke View
            return View(inProgressTransactions);
        }

        // Aksi untuk mengubah status transaksi menjadi "Approved"
        [HttpPost]
        public async Task<IActionResult> ApproveTransaction(string transactionId)
        {
            var transaction = await _dbContext.Transaction.FindAsync(transactionId);
            if (transaction != null)
            {
                transaction.Status = "Approved";
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Notification");
        }

        // Aksi untuk mengubah status transaksi menjadi "Rejected"
        [HttpPost]
        public async Task<IActionResult> RejectTransaction(string transactionId)
        {
            var transaction = await _dbContext.Transaction.FindAsync(transactionId);
            if (transaction != null)
            {
                transaction.Status = "Rejected";
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Notification");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(string transactionId, string status)
        {
            var transaction = await _dbContext.Transaction.FindAsync(transactionId);
            if (transaction != null)
            {
                transaction.Status = status;
                await _dbContext.SaveChangesAsync();
            }
            return Json(new { success = true });
        }
    }
}
