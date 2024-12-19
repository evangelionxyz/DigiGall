namespace DigiGall.Models
{
    public enum AdminViewState
    {
        AddDigiGall,
        Notifications
    }

    public class AdminViewModel
    {
        public AdminViewState State { get; set; } = AdminViewState.AddDigiGall;
        public List<User> Users { get; set; } = default!;
        public List<Transaction> Transactions { get; set; } = default!;
    }
}
