using Microsoft.AspNetCore.Mvc;
using BlazerCRUDApp.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase {

        private readonly ApplicationDBContext context;
        public PeopleController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get() {
            return await context.People.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public async Task<ActionResult<Person>> Get(int id) {
            return await context.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Person person) {
            context.Add(person);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetPerson", new { id = person.Id }, person);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Person person) {
            context.Entry(person).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            var person = new Person {Id = id};
            context.Remove(person);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}