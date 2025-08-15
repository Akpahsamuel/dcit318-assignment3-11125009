using System;

namespace FinanceManagementSystem
{
    public record Transaction
    {
        public int Id { get; init; }
        public DateTime Date { get; init; }
        public decimal Amount { get; init; }
        public string Category { get; init; }
        
        public Transaction(int id, DateTime date, decimal amount, string category)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Category = category;
        }
    }
}
