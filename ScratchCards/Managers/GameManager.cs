using ScratchCards.Interfaces.Manager;

namespace ScratchCards.Managers
{
    public class GameManager : IGameManager
    {
        public int[] Spin()
        {
            return new int[] { 1, 2, 3};
        }
    }
}