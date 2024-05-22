using BankingApp.Models;

namespace BankingAppN.Data.Iterator;

public class AccountOperationsCollection : IEnumerable<AccountOperation>
{
    private readonly List<AccountOperation> _accountOperations;

    public AccountOperationsCollection(List<AccountOperation> accountOperations)
    {
        _accountOperations = accountOperations;
    }

    public IIterator<AccountOperation> CreateIterator()
    {
        return new AccountOperationIterator(_accountOperations);
    }
}
