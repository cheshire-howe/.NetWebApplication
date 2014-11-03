using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AutofacGenericRepositoryMvc.Model.Concrete;
using AutofacGenericRepositoryMvc.Service.DataTransferObjects;
using AutofacGenericRepositoryMvc.Service.Interfaces;

namespace AutofacGenericRepositoryMvc.Web.Api
{
    public class PersonApiController : ApiController
    {
        private IPersonService _personService;

        public PersonApiController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/PersonApi
        public IEnumerable<Person> GetPersons()
        {
            return _personService.GetAll();
        }

        // GET: api/PersonApi/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult GetPerson(long id)
        {
            Person person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/PersonApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson(long id, PersonDto personDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personDto.Id)
            {
                return BadRequest();
            }

            _personService.UpdatePersonFromDto(personDto);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PersonApi
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostPerson(PersonDto personDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _personService.CreatePersonFromDto(personDto);

            return CreatedAtRoute("DefaultApi", new { id = personDto.Name }, personDto);
        }

        // DELETE: api/PersonApi/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(long id)
        {
            Person person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            _personService.Delete(person);

            return Ok(person);
        }
    }
}