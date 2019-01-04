namespace BoozeHoundBooks
{
  public struct OpeningAndClosingBalances
  {
    public decimal OpeningBalance { get; }
    public decimal ClosingBalance { get; }

    public OpeningAndClosingBalances(decimal openingBalance, decimal closingBalance)
    {
      OpeningBalance = openingBalance;
      ClosingBalance = closingBalance;
    }
  }
}
