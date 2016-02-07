using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using RideOnCab.Models;

namespace RideOnCab.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/RideOnCabApi")]
    public class RideOnCabApiController : Controller
    {
        private ApplicationDbContext _context;

        public RideOnCabApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Cabs Api
        // GET: api/RideOnCabApi
        [HttpGet]
        public IEnumerable<Cab> GetCabs()
        {
            return _context.Cabs;
        }

        // GET: api/RideOnCabApi/5
        [HttpGet("{id}", Name = "GetCab")]
        public async Task<IActionResult> GetCab([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Cab cab = await _context.Cabs.SingleAsync(m => m.Id == id);

            if (cab == null)
            {
                return HttpNotFound();
            }

            return Ok(cab);
        }

        // PUT: api/RideOnCabApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCab([FromRoute] int id, [FromBody] Cab cab)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != cab.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(cab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/RideOnCabApi
        [HttpPost]
        public async Task<IActionResult> PostCab([FromBody] Cab cab)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Cabs.Add(cab);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CabExists(cab.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetCab", new { id = cab.Id }, cab);
        }

        // DELETE: api/RideOnCabApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCab([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Cab cab = await _context.Cabs.SingleAsync(m => m.Id == id);
            if (cab == null)
            {
                return HttpNotFound();
            }

            _context.Cabs.Remove(cab);
            await _context.SaveChangesAsync();

            return Ok(cab);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CabExists(int id)
        {
            return _context.Cabs.Count(e => e.Id == id) > 0;
        }
        #endregion

        #region Vehicles Api
        #endregion

        #region Vehicles Api
        #endregion
    }

}