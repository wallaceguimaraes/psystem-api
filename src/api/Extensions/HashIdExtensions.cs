using HashidsNet;

namespace api.Extensions
{
    public static class HashIdExtensions
    {
        private const string Salt = "df790e48df4af91852176d996e5fbbb2";

        public static string ToHashId(this long id)
        {
            return new Hashids(Salt).EncodeLong(id);
        }

        public static string? ToHashId(this long? id)
        {
            if (id == null) return null;

            return new Hashids(Salt).EncodeLong(id.Value);
        }

        public static string ToHashId(this int id)
        {
            return new Hashids(Salt).Encode(id);
        }

        public static string? ToHashId(this string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return new Hashids(Salt).EncodeHex(id);
        }

        public static long ToLongId(this string hash)
        {
            if (string.IsNullOrWhiteSpace(hash))
                return 0;

            var numbers = new Hashids(Salt).DecodeLong(hash);

            return numbers.Any() ? numbers.First() : 0;
        }

        public static long? ToNullableLongId(this string hash)
        {
            if (string.IsNullOrWhiteSpace(hash))
                return null;

            var numbers = new Hashids(Salt).DecodeLong(hash);

            return numbers.FirstOrDefault();
        }

        public static int? ToNullableIntId(this string hash)
        {
            if (string.IsNullOrWhiteSpace(hash))
                return null;

            var numbers = new Hashids(Salt).Decode(hash);

            return numbers.FirstOrDefault();
        }

        public static int ToIntId(this string hash)
        {
            if (string.IsNullOrWhiteSpace(hash))
                return 0;

            var numbers = new Hashids(Salt).Decode(hash);

            return numbers.Any() ? numbers.First() : 0;
        }

        public static int ToStringId(this string hash)
        {
            if (string.IsNullOrWhiteSpace(hash))
                return 0;

            var numbers = new Hashids(Salt).DecodeHex(hash);

            return numbers.Any() ? numbers.First() : 0;
        }
    }
}