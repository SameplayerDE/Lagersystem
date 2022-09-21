using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lagersystem.RestfulApi
{
    public class SpecialIdentifier
    {
        [JsonPropertyName("identifier")]
        public int Identifier { get; set; }

        [JsonIgnore]
        private static Random _random = new Random();
        [JsonIgnore]
        private static List<SpecialIdentifier> _specialIdentifiers = new();

        static SpecialIdentifier()
        {
            string fileName = "sid.json";
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

        public static SpecialIdentifier Create()
        {
            var suid = new SpecialIdentifier();
            do
            {
                suid.Identifier = _random.Next();
            } while (ContainsId(suid.Identifier));
            _specialIdentifiers.Add(suid);
            string fileName = "sid.json";
            using FileStream createStream = File.Open(fileName, FileMode.OpenOrCreate);
            JsonSerializer.Serialize(createStream, _specialIdentifiers);
            createStream.Dispose();
            return suid;
        }

        public static bool ContainsId(int id)
        {
            foreach (var sid in _specialIdentifiers)
            {
                if (sid.Identifier == id)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
