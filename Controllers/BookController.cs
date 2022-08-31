using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using VestaAbner.Dbcontext;
using VestaAbner.Dto;
using VestaAbner.Model;

namespace VestaAbner.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly DbContextt _db;
        public LinkController(DbContextt db)
        {
            _db = db;
        }

        [HttpPost("{input}")]
        public async Task<IActionResult> Create([FromBody] string url)
        {
            if(string.IsNullOrEmpty(url))
                return StatusCode(500, "this link is exist ");
            
            LinkEntity linkIstance = new LinkEntity(url)
            ;
            var res = await _db.Links.AnyAsync(c => c.Url == url);
            if (res)
            {
                return NotFound();
            }
            else
            {
                await _db.Links.AddAsync(linkIstance);
                await _db.SaveChangesAsync();
                return Ok();
            }
        }

    [HttpPost("{shortLink}")]

    public async Task<IActionResult> Click([FromRoute] string shortLink)
    {
        var link = _db.Links.Where(z => z.ShortLink.Equals(shortLink)).FirstOrDefault();
        if (string.IsNullOrEmpty(link.Url))
            return StatusCode(404, "not found");
        else
            return Redirect(link.Url);
    }


    }
}

