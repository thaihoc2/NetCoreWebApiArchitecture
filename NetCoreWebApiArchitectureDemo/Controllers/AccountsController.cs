using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetCoreWebApiArchitectureDemo.Core.Entities;
using NetCoreWebApiArchitectureDemo.Core.Helpers;
using NetCoreWebApiArchitectureDemo.Core.Interfaces;
using NetCoreWebApiArchitectureDemo.Domain.Data;
using NetCoreWebApiArchitectureDemo.Domain.Entities;
using NetCoreWebApiArchitectureDemo.Models;
using Newtonsoft.Json;

namespace NetCoreWebApiArchitectureDemo.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly PartnerDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;

        public AccountsController(UserManager<AppUser> userManager, PartnerDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = new AppUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(userIdentity, model.Password);


            return new OkObjectResult("Account created");
        }
    }
}
