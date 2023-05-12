using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labb3API2.Data;
using Labb3API2.Models;
using AutoMapper;
using Labb3API2.Models.DTO;

namespace Labb3API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LinksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Links
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Link>>> GetLinks()
        {
          if (_context.Links == null)
          {
              return NotFound();
          }
            return await _context.Links.ToListAsync();
        }

        [HttpGet("Link by PersonId")]
        public async Task<ActionResult<IEnumerable<Link>>> GetLinks(int personId)
        {
            var links = await _context.Links
                .Include(l => l.Interest)
                .Include(l => l.Interest.Person)
                .Where(l => l.Interest.Person.PersonId == personId)
                .ToListAsync();

            if (links == null)
            {
                return NotFound();
            }

            return links;
        }

        // GET: api/Links/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Link>> GetLink(int id)
        {
          if (_context.Links == null)
          {
              return NotFound();
          }
            var link = await _context.Links.FindAsync(id);

            if (link == null)
            {
                return NotFound();
            }

            return link;
        }

        // PUT: api/Links/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLink(int id, Link link)
        {
            if (id != link.LinkId)
            {
                return BadRequest();
            }

            _context.Entry(link).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Links
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add Link by InterestId")]
        public async Task<ActionResult<LinkCreateDto>> PostInterest(LinkCreateDto linkCreate)
        {
          if (_context.Links == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Links'  is null.");
          }
            var link = new Link
            {
                Url = linkCreate.Url,
                FK_InterestId = linkCreate.InterestId
            };

            _context.Links.Add(link);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLink", new { id = linkCreate.InterestId }, linkCreate);
        }

        // DELETE: api/Links/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLink(int id)
        {
            if (_context.Links == null)
            {
                return NotFound();
            }
            var link = await _context.Links.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }

            _context.Links.Remove(link);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LinkExists(int id)
        {
            return (_context.Links?.Any(e => e.LinkId == id)).GetValueOrDefault();
        }
    }
}
