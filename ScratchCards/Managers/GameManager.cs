using ScratchCards.Interfaces.Manager;

namespace ScratchCards.Managers
{
    public class GameManager : IGameManager
    {
        public int[] Spin(int gameId, int bet)
        {
            return new int[] { 1, 2, 3};
        }
    }
}