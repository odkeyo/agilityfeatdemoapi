using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Core.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction> GetByIdAsync(int id);
        Task<int> InsertAsync(Transaction transaction);
        Task<bool> UpdateAsync(Transaction transaction);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Transaction>> GetFilteredTransactionsAsync(TransactionFilter filter);
    }
}
