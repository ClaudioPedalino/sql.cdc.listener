using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net6_api.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace cdc_api_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MockDataController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public MockDataController(DataContext dataContext) { _dataContext = dataContext; }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] MOCK_DATA request)
        {
            try
            {
                return Ok(await Insert(request));
            }
            catch { return Error(); }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] MOCK_DATA request)
        {
            try
            {
                var entity = GetById(request.Id);
                return entity != null ?
                    Ok(await Update(request, entity))
                    : NotFound();
            }
            catch { return Error(); }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var entity = GetById(id);
                return entity != null ?
                    Ok(await Remove(entity))
                    : NotFound();
            }
            catch { return Error(); }
        }


        private MOCK_DATA GetById(int id)
            => _dataContext.MOCK_DATA.AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        private async Task<string> Insert(MOCK_DATA request)
        {
            await _dataContext.AddAsync(request);
            await _dataContext.SaveChangesAsync();
            string message = $"Created =>  {request.First_name} {request.Last_name}";
            Console.WriteLine(message);
            return message;
        }


        private async Task<string> Update(MOCK_DATA request, MOCK_DATA entity)
        {
            _dataContext.Update(request);
            await _dataContext.SaveChangesAsync();
            string message = $"Updated =>  {request.First_name} {request.Last_name}";
            Console.WriteLine(message);
            return message;
        }

        private async Task<string> Remove(MOCK_DATA entity)
        {
            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
            string message = $"Deleted =>  {entity?.First_name} {entity?.Last_name}";
            Console.WriteLine(message);
            return message;
        }

        private ActionResult NotFound()
        {
            Console.WriteLine(">>>>>>>>>>>>>> Not found");
            return NotFound(">>>>>>>>>>>>>> Not found");
        }
        private ActionResult Error()
        {
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>> Error");
            return BadRequest("error");
        }


    }
}
