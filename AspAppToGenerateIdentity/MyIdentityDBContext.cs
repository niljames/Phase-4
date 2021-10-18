using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspAppToGenerateIdentity
{
    public class MyIdentityDBContext:IdentityDbContext
    {
        public MyIdentityDBContext(DbContextOptions<MyIdentityDBContext> options) : base(options)
        {

        }
    }
}
