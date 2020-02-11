using System;
using WTW_Email.Models;

namespace WTW_Email
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().NumberOfUniqueEmailAddresses(new string[] { "test@test.com" }));
        }
    }
}
