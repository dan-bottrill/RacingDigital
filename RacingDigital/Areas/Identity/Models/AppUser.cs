using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System.ComponentModel;

namespace RacingDigital.Areas.Identity.Models
{
    [CollectionName("Users")]
    public class AppUser : MongoIdentityUser<string>
    {
        public string FullName { get; set; }        
    }
}
