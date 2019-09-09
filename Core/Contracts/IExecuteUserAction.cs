namespace Core.Contracts
{
    public interface IExecuteUserAction
    {
        void Move(char direction);
        void CheckCurrentRoom();
        void CheckSelf();
    }
}
