namespace RealmCore.Logic.Interfaces
{
    public interface IPlayerCreationUI
    {
        string EnterName();

        string ChooseCharacter();

        void DisplayError();
    }
}