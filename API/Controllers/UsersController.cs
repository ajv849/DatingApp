using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<APPUser>>> GetUsers() 
        {
            return await _context.Users.ToListAsync();
        }

        //api/users/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<APPUser>> GetUser(int id) 
        {
            return await _context.Users.FindAsync(id);
        }

    }
}