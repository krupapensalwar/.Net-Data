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
using BusSystem.WebAPI.Controllers;
using BusSystem.Repository;

namespace BusSystem.WebAPI
{
    public class BusSystemController : ApiController
    {
        private BusReservationSystemDBEntities db = new BusReservationSystemDBEntities();

        // GET api/BusSystem
        public IQueryable<CategoryInfo> GetCategoryInfoes()
        {
            
            return db.CategoryInfoes;
        }

        // GET api/BusSystem/5
        [ResponseType(typeof(CategoryInfo))]
        public IHttpActionResult GetCategoryInfo(int id)
        {
            CategoryInfo categoryinfo = db.CategoryInfoes.Find(id);
            if (categoryinfo == null)
            {
                return NotFound();
            }

            return Ok(categoryinfo);
        }

        // PUT api/BusSystem/5
        public IHttpActionResult PutCategoryInfo(int id, CategoryInfo categoryinfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryinfo.CategoryId)
            {
                return BadRequest();
            }

            db.Entry(categoryinfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryInfoExists(id))
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

        // POST api/BusSystem
        [ResponseType(typeof(CategoryInfo))]
        public IHttpActionResult PostCategoryInfo(CategoryInfo categoryinfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoryInfoes.Add(categoryinfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoryinfo.CategoryId }, categoryinfo);
        }

        // DELETE api/BusSystem/5
        [ResponseType(typeof(CategoryInfo))]
        public IHttpActionResult DeleteCategoryInfo(int id)
        {
            CategoryInfo categoryinfo = db.CategoryInfoes.Find(id);
            if (categoryinfo == null)
            {
                return NotFound();
            }

            db.CategoryInfoes.Remove(categoryinfo);
            db.SaveChanges();

            return Ok(categoryinfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryInfoExists(int id)
        {
            return db.CategoryInfoes.Count(e => e.CategoryId == id) > 0;
        }
    }
}