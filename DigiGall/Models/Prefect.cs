namespace DigiGall.Models
{
    public class Prefect : ModelBase
    {
        // per user prefect (individual user)
        public string Status { get; set; } = default!;
        public int Amount { get; set; } = 0;

        public Prefect()
            : base()
        {
        }
       
        public Prefect(string id)
            : base(id)
        {
        }
    }
}
