using Microsoft.AspNetCore.Mvc;
using Backend.Services;
using Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _service;

        public TransactionController(TransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetById(int id)
        {
            var transaction = await _service.GetByIdAsync(id);
            return transaction == null ? NotFound() : Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] Transaction transaction)
        {
            var id = await _service.InsertAsync(transaction);
            return CreatedAtAction(nameof(GetById), new { id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Transaction transaction)
        {
            transaction.Id = id;
            return await _service.UpdateAsync(transaction) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) =>
            await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
