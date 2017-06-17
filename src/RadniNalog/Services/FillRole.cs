using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RadniNalog.Data;
using RadniNalog.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public  void fillNalog()
        {

            //fill zaposlenika


            string jsonZaposlenici = @"apexbaza/zaposlenici.json";
            var pathToFile = Path.Combine(_env.WebRootPath, jsonZaposlenici);


            var parseZaposlenici = System.IO.File.ReadAllText(pathToFile);
        

            var deserZaposlenici = JsonConvert.DeserializeObject<List<ApexZaposlenik>>(parseZaposlenici);

           

            if (_context.Zaposlenici.Count() == 0)
            {

                foreach (var zaposlenik in deserZaposlenici)
                {
                    Zaposlenik z = new Zaposlenik
                    {

                        Ime = zaposlenik.FIELD1

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

            string jsonVrstaRada = @"apexbaza/vrstarada.json";
            var pathToFile2 = Path.Combine(_env.WebRootPath, jsonVrstaRada);


            var parseVrstaRada = System.IO.File.ReadAllText(pathToFile2);


            var deserVrstaRada = JsonConvert.DeserializeObject<List<ApexVrsta>>(parseVrstaRada);



            if (_context.VrstaRada.Count() == 0)
            {

                foreach (var vrstaRada in deserVrstaRada)
                {
                    VrstaRada v = new VrstaRada
                    {

                        Naziv = vrstaRada.FIELD1
                        

                    };
                    // _context.Zaposlenici.Add(z);
                    _context.Entry(v).State = EntityState.Added;


                }

                _context.SaveChanges();

            }
            else
            {
                
            }


            //fill mjesta rada

            string jsonMjestoRada = @"apexbaza/mjestorada.json";
            var pathToMjestoRada = Path.Combine(_env.WebRootPath, jsonMjestoRada);


            var parseMjestoRada = System.IO.File.ReadAllText(pathToMjestoRada);


            var deserMjestoRada = JsonConvert.DeserializeObject<List<ApexMjesto>>(parseMjestoRada);



            if (_context.MjestoRada.Count() == 0)
            {

                foreach (var mjestoRada in deserMjestoRada)
                {
                    MjestoRada m = new MjestoRada
                    {

                        Ime = mjestoRada.FIELD1


                    };
                    // _context.Zaposlenici.Add(z);
                    _context.Entry(m).State = EntityState.Added;


                }

                _context.SaveChanges();

            }
            else
            {

            }


            //fill registracije

            string jsonRegistracija = @"apexbaza/registracija.json";
            var pathToRegistracija = Path.Combine(_env.WebRootPath, jsonRegistracija);


            var parseRegistracija = System.IO.File.ReadAllText(pathToRegistracija);


            var deserRegistracija = JsonConvert.DeserializeObject<List<ApexRegistracija>>(parseRegistracija);



            if (_context.Automobili.Count() == 0)
            {

                foreach (var registracija in deserRegistracija)
                {
                    Automobil a = new Automobil
                    {

                        Registracija = registracija.FIELD1


                    };
                    // _context.Zaposlenici.Add(z);
                    _context.Entry(a).State = EntityState.Added;


                }

                _context.SaveChanges();

            }
            else
            {

            }

            //fill nalozi


            var autoID = 0;
            var vrstaRadaID = 0;
            var mjestoRadaID = 0;
            string jsonRNalog = @"apexbaza/apexbaza.json";

            var pathToRNalog = Path.Combine(_env.WebRootPath, jsonRNalog);

            var parseRNalog = System.IO.File.ReadAllText(pathToRNalog);

            var deserRNalog = JsonConvert.DeserializeObject<List<ApexSer>>(parseRNalog);


            if (_context.RadniNalozi.Count() == 0)
            {
                Automobil defaultAuto = new Automobil
                {

                    Registracija = "Ostalo"


                };

                _context.Entry(defaultAuto).State = EntityState.Added;


                VrstaRada defaultVrsta = new VrstaRada
                {
                    Naziv = "Ostalo"



                };

                _context.Entry(defaultVrsta).State = EntityState.Added;



                MjestoRada defaultMjesto = new MjestoRada
                {

                    Ime = "Ostalo"

                };

                _context.Entry(defaultMjesto).State = EntityState.Added;


                foreach (var rNalog in deserRNalog)

              
                {



                   


                    var auto = _context.Automobili.Where(automobil => automobil.Registracija == rNalog.FIELD11).FirstOrDefault();

                    if (auto == null)
                    {
                        autoID = defaultAuto.ID;

                    }
                    else {

                        autoID = auto.ID;
                    }

                    var vRad = _context.VrstaRada.Where(vRada => vRada.Naziv == rNalog.FIELD3).FirstOrDefault();

                    if (vRad == null)
                    {
                        vrstaRadaID = defaultVrsta.ID;

                    }
                    else
                    {

                        vrstaRadaID = vRad.ID;
                    }

                    var mRad = _context.MjestoRada.Where(mRada => mRada.Ime == rNalog.FIELD2).FirstOrDefault();

                    if (mRad == null)
                    {
                        mjestoRadaID = defaultMjesto.ID;

                    }
                    else
                    {

                        mjestoRadaID = mRad.ID;
                    }




                    RNalog nalog = new RNalog
                    {

                       OpisRadova = rNalog.FIELD4,
                       Materijal = rNalog.FIELD5,
                       Rukovoditelj = rNalog.FIELD7,
                       Izvrsitelj2 = rNalog.FIELD8,
                       Izvrsitelj3 = rNalog.FIELD9,
                       PutniNalog = rNalog.FIELD10,
                       AutomobilID = autoID,
                       VrstaRadaID = vrstaRadaID,
                       MjestoRadaID = mjestoRadaID,
                       Datum = rNalog.FIELD6



                    };
                    // _context.Zaposlenici.Add(z);
                    _context.Entry(nalog).State = EntityState.Added;


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
