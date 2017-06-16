using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RadniNalog.Data;
using RadniNalog.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IHostingEnvironment _env;


        public FillRole(ApplicationDbContext context,RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHostingEnvironment env)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _signinManager = signInManager;
            _env = env;


        }

        public async void fillNalog()
        {

            //fill zaposlenika


            string jsonname = @"apexbaza/zaposlenici.json";
            var pathToFile = Path.Combine(_env.WebRootPath, jsonname);


            var test2 = System.IO.File.ReadAllText(pathToFile);
        

            var test = JsonConvert.DeserializeObject<List<ApexZaposlenik>>(test2);

           

            if (_context.Zaposlenici.Count() == 0)
            {

                foreach (var apex in test)
                {
                    Zaposlenik z = new Zaposlenik
                    {

                        Ime = apex.FIELD1

                    };
                    // _context.Zaposlenici.Add(z);
                    _context.Entry(z).State = EntityState.Added;


                }

                _context.SaveChanges();

            }
            else
            {
                
            }

            //fill vrsta rada

            string jsonnameVrsta = @"apexbaza/vrstarada.json";
            var pathToFile2 = Path.Combine(_env.WebRootPath, jsonnameVrsta);


            var testVrsta = System.IO.File.ReadAllText(pathToFile2);


            var vrste = JsonConvert.DeserializeObject<List<ApexVrsta>>(testVrsta);



            if (_context.VrstaRada.Count() == 0)
            {

                foreach (var apex2 in vrste)
                {
                    VrstaRada v = new VrstaRada
                    {

                        Naziv = apex2.FIELD1
                        

                    };
                    // _context.Zaposlenici.Add(z);
                    _context.Entry(v).State = EntityState.Added;


                }

                _context.SaveChanges();

            }
            else
            {
                
            }


            //fill vrsta rada

            string jsonnameVrsta = @"apexbaza/mjestorada.json";
            var pathToFile3353535 = Path.Combine(_env.WebRootPath, jsonnameVrsta);


            var testVrsta = System.IO.File.ReadAllText(pathToFile2);


            var vrste = JsonConvert.DeserializeObject<List<ApexVrsta>>(testVrsta);



            if (_context.VrstaRada.Count() == 0)
            {

                foreach (var apex2 in vrste)
                {
                    VrstaRada v = new VrstaRada
                    {

                        Naziv = apex2.FIELD1


                    };
                    // _context.Zaposlenici.Add(z);
                    _context.Entry(v).State = EntityState.Added;


                }

                _context.SaveChanges();

            }
            else
            {

            }



            /*if (_context.RadniNalozi.Count() == 0)
            {
                //test json-a
                string jsonname = @"apexbaza/apexbaza.json";
                var pathToFile = Path.Combine(_env.WebRootPath, jsonname);


                var test2 = System.IO.File.ReadAllText(pathToFile);

                var test = JsonConvert.DeserializeObject<List<ApexSer>>(test2);

             


             }

            else {

                return;
            }*/

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
