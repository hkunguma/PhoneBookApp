using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.DAL.EF.Provider
{
    public static class DbInitializer
    {
        public static void Initialize(PhoneBookContext context)
        {
            context.Database.EnsureCreated();

            //look for any phonebooks
            if (context.PhoneBooks.Any())
            {
                return; //DB has been seeded
            }
        }
    }
}
