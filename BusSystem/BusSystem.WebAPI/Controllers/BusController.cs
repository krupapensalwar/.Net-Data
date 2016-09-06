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
using BusSystem.Core;
using BusSystem.Repository;

namespace BusSystem.WebAPI
{
    public class BusController : ApiController
    {
        private BusReservationSystemDBEntities db = new BusReservationSystemDBEntities();

        // GET api/Bus
        public IQueryable<BusInfo> GetBusInfoes()
        {
            BusRepository busRepository = new BusRepository();
            return busRepository.GetBusInfo();
            //return db.BusInfoes;
        }

        // GET api/Bus/5
        [ResponseType(typeof(BusInfo))]
        public IHttpActionResult GetBusInfo(int id)
        {
            BusInfo businfo = db.BusInfoes.Find(id);
            if (businfo == null)
            {
                return NotFound();
            }

            return Ok(businfo);
        }

        // PUT api/Bus/5
        public IHttpActionResult PutBusInfo(int id, BusInfo businfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businfo.BusId)
            {
                return BadRequest();
            }

            db.Entry(businfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusInfoExists(id))
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

        // POST api/Bus
        [ResponseType(typeof(BusInfo))]
        public IHttpActionResult PostBusInfo(BusInfo businfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BusInfoes.Add(businfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = businfo.BusId }, businfo);
        }

        // DELETE api/Bus/5
        [ResponseType(typeof(BusInfo))]
        public IHttpActionResult DeleteBusInfo(int id)
        {
            BusInfo businfo = db.BusInfoes.Find(id);
            if (businfo == null)
            {
                return NotFound();
            }

            db.BusInfoes.Remove(businfo);
            db.SaveChanges();

            return Ok(businfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusInfoExists(int id)
        {
            return db.BusInfoes.Count(e => e.BusId == id) > 0;
        }
    }
}