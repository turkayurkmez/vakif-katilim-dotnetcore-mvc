using Newtonsoft.Json;

namespace BookStore.MVC.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            var serializedString = JsonConvert.SerializeObject(value);
            session.SetString(key, serializedString);
        }

        public static T? GetJson<T>(this ISession session, string key) where T : class
        {
            var serialized = session.GetString(key);
            if (string.IsNullOrEmpty(serialized))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
