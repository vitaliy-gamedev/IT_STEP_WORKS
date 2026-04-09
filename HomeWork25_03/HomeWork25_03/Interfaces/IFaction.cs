public interface IFaction
{
    string Name { get; }
    int Reputation { get; }
    void ShowLore();
    void ChangeReputation(int value);
}