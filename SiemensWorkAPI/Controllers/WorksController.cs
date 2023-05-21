﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiemensWorkAPI.Data;
using SiemensWorkAPI.Model;

namespace SiemensWorkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize("ClientIdPolicy")]
    public class WorksController : ControllerBase
    {
        private readonly SiemensWorkAPIContext _context;

        public WorksController(SiemensWorkAPIContext context)
        {
            _context = context;
        }

        // GET: api/Works
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Work>>> GetWork()
        {
          if (_context.Work == null)
          {
              return NotFound();
          }
            return await _context.Work.ToListAsync();
        }

        // GET: api/Works/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> GetWork(int id)
        {
          if (_context.Work == null)
          {
              return NotFound();
          }
            var work = await _context.Work.FindAsync(id);

            if (work == null)
            {
                return NotFound();
            }

            return work;
        }

        // PUT: api/Works/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWork(int id, Work work)
        {
            if (id != work.Id)
            {
                return BadRequest();
            }

            _context.Entry(work).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExists(id))
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

        // POST: api/Works
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Work>> PostWork(Work work)
        {
          if (_context.Work == null)
          {
              return Problem("Entity set 'SiemensWorkAPIContext.Work'  is null.");
          }
            _context.Work.Add(work);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWork", new { id = work.Id }, work);
        }

        // DELETE: api/Works/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWork(int id)
        {
            if (_context.Work == null)
            {
                return NotFound();
            }
            var work = await _context.Work.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }

            _context.Work.Remove(work);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkExists(int id)
        {
            return (_context.Work?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
