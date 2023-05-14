using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using SiemensWorks.Client.APIServices;
using SiemensWorks.Client.Models;

namespace SiemensWorks.Client.Controllers
{
    [Authorize]
    public class WorksController : Controller
    {
        private readonly IWorkApiServices _workApiServices;

        public WorksController(IWorkApiServices workApiServices)
        {
            _workApiServices = workApiServices;
        }

        public async Task LogTokenAndClaims()
        {
            var identityTocken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            Debug.WriteLine($"Identity token : {identityTocken}");

            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Claim Type : {claim.Type} - Claim Value: {claim.Value}"); 
            }
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

        // GET: Works
        public async Task<IActionResult> Index()
        {
              LogTokenAndClaims();
              return View(await _workApiServices.GetWorks());
        }

        // GET: Works/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View();
            //if (id == null || _context.Works == null)
            //{
            //    return NotFound();
            //}

            //var works = await _context.Works
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (works == null)
            //{
            //    return NotFound();
            //}

            //return View(works);
        }

        // GET: Works/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProcessName,ProcessDescription,CreatedDate,Owner")] Work works)
        {
            return View();
            //if (ModelState.IsValid)
            //{
            //    _context.Add(works);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(works);
        }

        // GET: Works/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return View();
            //if (id == null || _context.Works == null)
            //{
            //    return NotFound();
            //}

            //var works = await _context.Works.FindAsync(id);
            //if (works == null)
            //{
            //    return NotFound();
            //}
            //return View(works);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProcessName,ProcessDescription,CreatedDate,Owner")] Work works)
        {
            return View();
            //if (id != works.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(works);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!WorksExists(works.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(works);
        }

        // GET: Works/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View();
            //if (id == null || _context.Works == null)
            //{
            //    return NotFound();
            //}

            //var works = await _context.Works
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (works == null)
            //{
            //    return NotFound();
            //}

            //return View(works);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return View();
            //if (_context.Works == null)
            //{
            //    return Problem("Entity set 'SiemensWorksClientContext.Works'  is null.");
            //}
            //var works = await _context.Works.FindAsync(id);
            //if (works != null)
            //{
            //    _context.Works.Remove(works);
            //}
            
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool WorksExists(int id)
        {
            return true;
            //return (_context.Works?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
