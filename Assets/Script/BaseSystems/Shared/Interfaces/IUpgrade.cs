public interface IUpgrade 
{
    bool CanUpgrade();
    bool TryUpgrade();
}