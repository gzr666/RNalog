using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RadniNalog.Data;
using RadniNalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Services
{
    public  class FillRole : IFillRole
    {
        private  ApplicationDbContext _context;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<ApplicationUser> _signinManager;
        private  UserManager<ApplicationUser> _userManager;


        public FillRole(ApplicationDbContext context,RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _signinManager = signInManager;

        }

        public  async Task createRolesandUsers()
        {

            if (!await _roleManager.RoleExistsAsync("SuperAdmin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));

            }


            var result = await _userManager.FindByEmailAsync("imales@hep.hr");
            if (result == null)
            {
                var user = new ApplicationUser { UserName = "imales@hep.hr", Email = "imales@hep.hr" };

                var result2 = await _userManager.CreateAsync(user, "Sjetise1234@");
                if (result2.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, "SuperAdmin");



                  
                }


            }
            


            

            


            //  var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            //  var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));




            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {


                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                

                //Here we create a Admin super user who will maintain the website  

                

                //var user = new ApplicationUser();
                //user.UserName = "Administrator";
                //user.Email = "imales@hep.hr";
                //user.EmailConfirmed = true;
             

                //string userPWD = "Sjetise1234@";

                

                //var chkUser = await _userManager.CreateAsync(user, userPWD);

                //Add default User to Role Admin   
                //if (chkUser.Succeeded)
                //{
                //    var result1 = await _userManager.AddToRoleAsync(user, "Admin");

                //}
            }

            // creating Creating Manager role    
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Korisnik"));

            }

            // creating Creating Employee role    
            if (!await _roleManager.RoleExistsAsync("Viewer"))
            {

                await _roleManager.CreateAsync(new IdentityRole("Viewer"));
            }
        }



    }
}
