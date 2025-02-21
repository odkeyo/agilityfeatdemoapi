using Microsoft.EntityFrameworkCore;
using Backend.Core.Interfaces;
using Backend.Data;
using Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetByIdAsync(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task<int> InsertAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction.Id;
        }

        public async Task<bool> UpdateAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) return false;

            _context.Transactions.Remove(transaction);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Transaction>> GetFilteredTransactionsAsync(TransactionFilter filter)
        {
            var query = _context.Transactions.AsQueryable();
            if (!string.IsNullOrEmpty(filter.Type))
                query = query.Where(t => t.Type == filter.Type);
            if (filter.MinAmount.HasValue)
                query = query.Where(t => t.Amount >= filter.MinAmount.Value);
            if (filter.MaxAmount.HasValue)
                query = query.Where(t => t.Amount <= filter.MaxAmount.Value);
            if (filter.StartDate.HasValue)
                query = query.Where(t => t.Date >= filter.StartDate.Value);
            if (filter.EndDate.HasValue)
                query = query.Where(t => t.Date <= filter.EndDate.Value);

            return await query.ToListAsync();
        }

    }
}
