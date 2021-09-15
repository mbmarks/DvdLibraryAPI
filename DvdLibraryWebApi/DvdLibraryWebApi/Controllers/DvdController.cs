using DvdLibraryWebApi.Interfaces;
using DvdLibraryWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibraryWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        private IDvdRepository repo = DvdRepositoryFactory.Create();

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            List<Dvd> found = repo.GetByTitle(title);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }

        [Route("dvds/year/{year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByReleaseYear(string year)
        {
            List<Dvd> found = repo.GetByReleaseYear(year);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string directorName)
        {
            List<Dvd> found = repo.GetByDirector(directorName);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            List<Dvd> found = repo.GetByRating(rating);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }

        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(int id)
        {
            Dvd found = repo.GetById(id);
            
            if(found == null)
            {
                return NotFound();
            }
                
            return Ok(found);
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(Dvd dvd)
        {
            repo.Create(dvd);

            return Created($"dvd/{dvd.Id}", dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(int id, Dvd dvd)
        {
            dvd.Id = id;
            repo.Update(dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}
