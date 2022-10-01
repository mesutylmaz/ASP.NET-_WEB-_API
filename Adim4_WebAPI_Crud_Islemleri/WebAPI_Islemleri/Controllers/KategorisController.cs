using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Database_Islemleri_Dal;

namespace WebAPI_Islemleri.Controllers
{
    public class KategorisController : ApiController
    {
        private MvcOnlineTicariOtomasyonEntities1 db = new MvcOnlineTicariOtomasyonEntities1();

        // GET: api/Kategoris
        public IQueryable<Kategoris> GetKategoris()
        {
            return db.Kategoris;
        }

        // GET: api/Kategoris/5
        [ResponseType(typeof(Kategoris))]
        public IHttpActionResult GetKategoris(int id)
        {
            Kategoris kategoris = db.Kategoris.Find(id);
            if (kategoris == null)
            {
                return NotFound();
            }

            return Ok(kategoris);
        }

        // PUT: api/Kategoris/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKategoris(int id, Kategoris kategoris)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kategoris.KategoriID)
            {
                return BadRequest();
            }

            db.Entry(kategoris).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategorisExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Kategoris
        [ResponseType(typeof(Kategoris))]
        public IHttpActionResult PostKategoris(Kategoris kategoris)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kategoris.Add(kategoris);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kategoris.KategoriID }, kategoris);
        }

        // DELETE: api/Kategoris/5
        [ResponseType(typeof(Kategoris))]
        public IHttpActionResult DeleteKategoris(int id)
        {
            Kategoris kategoris = db.Kategoris.Find(id);
            if (kategoris == null)
            {
                return NotFound();
            }

            db.Kategoris.Remove(kategoris);
            db.SaveChanges();

            return Ok(kategoris);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KategorisExists(int id)
        {
            return db.Kategoris.Count(e => e.KategoriID == id) > 0;
        }
    }
}