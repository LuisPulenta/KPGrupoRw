using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Web.Data;
using Web.Models;

namespace Vehicles2.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        
        public AccountController(DataContext context)
        {
            _context = context;
        
        }

       
        

     
    }
}