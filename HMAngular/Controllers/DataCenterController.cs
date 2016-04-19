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
using HMAngular.Models;

namespace HMAngular.Controllers
{
    public class DataCenterController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DataCenter
        public IQueryable<DataCenter> GetDataCenters()
        {
            return db.DataCenters;
        }

        // GET: api/DataCenter/5
        [ResponseType(typeof(DataCenter))]
        public IHttpActionResult GetDataCenter(int id)
        {
            DataCenter dataCenter = db.DataCenters.Find(id);
            if (dataCenter == null)
            {
                return NotFound();
            }

            return Ok(dataCenter);
        }

        // PUT: api/DataCenter/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDataCenter(int id, DataCenter dataCenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dataCenter.DataCenterID)
            {
                return BadRequest();
            }

            db.Entry(dataCenter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataCenterExists(id))
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

        // POST: api/DataCenter
        [ResponseType(typeof(DataCenter))]
        public IHttpActionResult PostDataCenter(DataCenter dataCenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DataCenters.Add(dataCenter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dataCenter.DataCenterID }, dataCenter);
        }

        // DELETE: api/DataCenter/5
        [ResponseType(typeof(DataCenter))]
        public IHttpActionResult DeleteDataCenter(int id)
        {
            DataCenter dataCenter = db.DataCenters.Find(id);
            if (dataCenter == null)
            {
                return NotFound();
            }

            db.DataCenters.Remove(dataCenter);
            db.SaveChanges();

            return Ok(dataCenter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DataCenterExists(int id)
        {
            return db.DataCenters.Count(e => e.DataCenterID == id) > 0;
        }
    }
}