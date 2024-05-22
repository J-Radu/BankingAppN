namespace BankingAppN.Data.Iterator;

public interface IIterator<T>
{
    bool HasNext();
    T Next();
}