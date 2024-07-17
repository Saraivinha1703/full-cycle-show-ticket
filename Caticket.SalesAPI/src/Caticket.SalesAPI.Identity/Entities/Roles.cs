using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Caticket.SalesAPI.Identity.Entities;

[Table("AspNetRoles")]
public class Role : IdentityRole<string> {
    public Role() {}
    public Role(string roleName) : base(roleName) {}
}