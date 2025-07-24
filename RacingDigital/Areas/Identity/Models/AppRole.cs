using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace RacingDigital.Areas.Identity.Models
{
    [CollectionName("Roles")]
    public class AppRole : MongoIdentityRole<string>
    {
        public string RoleName { get; set; }
    }
}
