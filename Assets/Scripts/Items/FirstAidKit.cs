public class FirstAidKit : Item, IItemable
{
    public int HealthRecoveryCount { get; private set; } = 30;

    public void Accept(IVisitor visitor)
    {
        DisableObject();
        visitor.Visit(this);
    }
}