namespace BoozeHoundBooks;

internal class AccountComparer : IComparer<KAccount>
{
    public int Compare(
        KAccount x,
        KAccount y)
    {
        if (x.IsMasterAccount() &&
            y.IsMasterAccount())
        {
            byte xType = x.GetAccountType();
            byte yType = y.GetAccountType();

            return xType < yType ? -1 : 1;
        }
        else if (x.IsMasterAccount())
        {
            return -1;
        }
        else if (y.IsMasterAccount())
        {
            return 1;
        }

        return x
            .GetQualifiedAccountName()
            .CompareTo(
                y.GetQualifiedAccountName());
    }
}
