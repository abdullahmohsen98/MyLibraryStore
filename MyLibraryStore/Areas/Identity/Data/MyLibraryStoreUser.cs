using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyLibraryStore.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MyLibraryStoreUser class
    public class MyLibraryStoreUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
