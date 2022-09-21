namespace Lagersystem.RestfulApi
{
    public class Item
    {

        public static List<Item> Items { get; set; } = new List<Item>();

        public SpecialIdentifier Sid { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long TimeStamp { get; set; } = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
        public Storage Storage { get; set; }

        protected Item()
        {

        }

        public static Item Create()
        {
            Item result = new()
            {
                Sid = SpecialIdentifier.Create()
            };
            return result;
        }

        public Item SetName(string name)
        {
            Name = name;
            return this;
        }

        public Item SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public Item SetTimeStamp(DateTime date)
        {
            TimeStamp = ((DateTimeOffset)date).ToUnixTimeSeconds(); ;
            return this;
        }

    }
}
