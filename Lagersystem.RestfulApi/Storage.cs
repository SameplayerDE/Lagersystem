using System.Text.Json;

namespace Lagersystem.RestfulApi
{
    public class Storage
    {
        public string Name { get; set; } = string.Empty;
        public List<Item> Items { get; set; } = new List<Item>();

        static Storage()
        {
            string fileName = "storage.json";
            if (!File.Exists(fileName))
            {
                using FileStream createStream = File.Open(fileName, FileMode.OpenOrCreate);
                JsonSerializer.Serialize(createStream, _specialIdentifiers);
                createStream.Dispose();
            }
            else
            {
                _specialIdentifiers = JsonSerializer.Deserialize<List<SpecialIdentifier>>(File.ReadAllText(fileName));
            }
        }

        public void AddItem(Item item)
        {
            item.Storage = this;
            Items.Add(item);
        }
    }
}
