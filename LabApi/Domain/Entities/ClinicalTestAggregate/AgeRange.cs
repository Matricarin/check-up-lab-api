namespace LabApi.Domain.Entities.ClinicalTestAggregate;

public class AgeRange : ValueObject
{
    public int From { get; }
    public int To { get; }
    
    private AgeRange(){}

    public AgeRange(int from, int to)
    {
        if (to <= 0)
        {
            throw new ArgumentException();
        }

        if (to <= from)
        {
            throw new ArgumentException();
        }

        From = from;
        To = to;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return From;
        yield return To;
    }
}