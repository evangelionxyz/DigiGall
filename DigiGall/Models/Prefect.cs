namespace DigiGall.Models
{
    public class Prefect : Transaction
    {
        public Prefect()
        {
            Type = "PREFECT";
        }

        public Prefect(string id, int amount)
        {
            Id = id;
            Amount = amount;
            Type = "PREFECT";
        }
    }
}
