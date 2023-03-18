using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SmartChemMVC.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SmartChemMVCUser class
public class SmartChemMVCUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

