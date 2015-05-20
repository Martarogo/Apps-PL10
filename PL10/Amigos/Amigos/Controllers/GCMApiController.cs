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
using Amigos.DataAccessLayer;
using Amigos.Models;

namespace Amigos.Controllers
{
    public class GCMApiController : ApiController
    {
        private GCMDBContext db = new GCMDBContext();

        // GET: api/GCMApi
        public IQueryable<GCMModel> GetGCMs()
        {
            return db.GCMs;
        }

        // GET: api/GCMApi/5
        [ResponseType(typeof(GCMModel))]
        public IHttpActionResult GetGCMModel(int id)
        {
            GCMModel gCMModel = db.GCMs.Find(id);
            if (gCMModel == null)
            {
                return NotFound();
            }

            return Ok(gCMModel);
        }

        // PUT: api/GCMApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGCMModel(int id, GCMModel gCMModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gCMModel.ID)
            {
                return BadRequest();
            }

            db.Entry(gCMModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GCMModelExists(id))
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

        // POST: api/GCMApi
        [ResponseType(typeof(GCMModel))]
        public IHttpActionResult PostGCMModel(GCMModel gCMModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GCMs.Add(gCMModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gCMModel.ID }, gCMModel);
        }

        // DELETE: api/GCMApi/5
        [ResponseType(typeof(GCMModel))]
        public IHttpActionResult DeleteGCMModel(int id)
        {
            GCMModel gCMModel = db.GCMs.Find(id);
            if (gCMModel == null)
            {
                return NotFound();
            }

            db.GCMs.Remove(gCMModel);
            db.SaveChanges();

            return Ok(gCMModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GCMModelExists(int id)
        {
            return db.GCMs.Count(e => e.ID == id) > 0;
        }
    }
}