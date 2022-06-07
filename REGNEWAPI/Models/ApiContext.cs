using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace REGNEWAPI.Models
{
    public class Apicontext : DbContext
    {

        public Apicontext(DbContextOptions<Apicontext> options) : base(options)
        {

        }
        public DbSet<ApiModel> MVCDemo7 { get; set; }

    }

}