using System.Text;
using Microsoft.AspNetCore.Http;

namespace Messenger
{
    public static class SessionExtensions
    {
        public static void SetString(this ISession session, string key, string value)
        {
            session.Set(key, Encoding.UTF8.GetBytes(value));
        }
    }
}
