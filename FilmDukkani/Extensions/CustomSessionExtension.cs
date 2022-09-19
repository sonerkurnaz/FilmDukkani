using Newtonsoft.Json;

namespace FilmDukkani.Extensions
{
    public static class CustomSessionExtension
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            var stringData = JsonConvert.SerializeObject(value);
            session.SetString(key, stringData);
        }
        public static T GetObject<T>(this ISession session, string key) where T: class,new()
        {
            var jsonData = session.GetString(key);
            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            return null;
        }


    }
}


