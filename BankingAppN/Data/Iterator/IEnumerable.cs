namespace BankingAppN.Data.Iterator;

public interface IEnumerable<T>
{
    IIterator<T> CreateIterator();
}