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
        public async Task<ActionResult> GetAll()
        {
            var transactions = await _service.GetAllAsync();
            return Ok(new { success = true, data = transactions });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var transaction = await _service.GetByIdAsync(id);
            if (transaction == null)
                return NotFound(new { success = false, message = "Transaction not found" });

            return Ok(new { success = true, data = transaction });
        }


        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] Transaction transaction)
        {
            var id = await _service.InsertAsync(transaction);
            transaction.Id = id;

            return CreatedAtAction(nameof(GetById), new { id }, 
                new { success = true, message = "Transaction created successfully", data = transaction });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Transaction transaction)
        {
            transaction.Id = id;
            var updated = await _service.UpdateAsync(transaction);
            
            if (!updated)
                return NotFound(new { success = false, message = "Transaction not found" });

            return Ok(new { success = true, message = "Transaction updated successfully" });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            
            if (!deleted)
                return NotFound(new { success = false, message = "Transaction not found" });

            return Ok(new { success = true, message = "Transaction deleted successfully" });
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredTransactions([FromQuery] TransactionFilter filter)
        {
            var transactions = await _service.GetFilteredTransactionsAsync(filter);
            return Ok(new { success = true, data = transactions });
        }

    }
}
