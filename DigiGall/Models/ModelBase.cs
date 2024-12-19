namespace DigiGall.Models
{
    public class ModelBase
    {
        public string Id { get; set; } = "";

        public ModelBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public ModelBase(string id)
        {
            Id = id;
        }
    }
}
