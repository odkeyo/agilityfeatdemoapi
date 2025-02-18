using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Core.Interfaces;
using Backend.Models;

namespace Backend.Services
{
    public class TransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Transaction> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<int> InsertAsync(Transaction transaction) => await _repository.InsertAsync(transaction);
        public async Task<bool> UpdateAsync(Transaction transaction) => await _repository.UpdateAsync(transaction);
        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
