using BankingApp.Models;

namespace BankingAppN.Data.Iterator;

public class AccountOperationIterator : IIterator<AccountOperation>
{
    private readonly List<AccountOperation> _accountOperations;
    private int _position;

    public AccountOperationIterator(List<AccountOperation> accountOperations)
    {
        _accountOperations = accountOperations;
        _position = 0;
    }

    public bool HasNext()
    {
        return _position < _accountOperations.Count;
    }

    public AccountOperation Next()
    {
        return _accountOperations[_position++];
    }
}
