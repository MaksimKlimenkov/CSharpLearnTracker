namespace CSharpLearnTracker.Delegates;

public class Account
{
    public int Sum { get; private set; }
    public Account(int sum) => Sum = sum;

    public void Put(int sum)
    {
        Sum += sum;
        Notify?.Invoke($"На счёт поступило: {sum}. Текущий баланс: {Sum}");
    }

    public void Take(int sum)
    {
        if (Sum >= sum)
        {
            Sum -= sum;
            Notify?.Invoke($"Со счёта списано {sum}. Текущий баланс: {Sum}");
        }
        else
        {
            Notify?.Invoke($"На вашем балансе недостаточно средств. Текущий баланс: {Sum}");
        }
    }

    public delegate void AccountHandler(string message);

    public event AccountHandler? Notify;

}
