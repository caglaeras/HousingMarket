using Microsoft.AspNetCore.Http;

namespace Proje.Helpers
{
    public static class SessionExtensions
    {
        public static void SetString(this ISession session, string key, string value)
        {
            session.Set(key, System.Text.Encoding.UTF8.GetBytes(value));
        }

        public static string GetString(this ISession session, string key)
        {
            session.TryGetValue(key, out var data);
            return data == null ? null : System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
