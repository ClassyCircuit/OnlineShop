using HashidsNet;

namespace OnlineShop.Business.Helpers
{
    public class HashingHelper
    {
        private readonly Hashids _hasher;

        public HashingHelper()
        {
            _hasher = new Hashids("todo: move salt to key vault", 5);
        }

        public string Encode(int id)
        {
            return _hasher.Encode(id);
        }
    }
}
