using ScratchCards.Interfaces.Manager;
using ScratchCards.Interfaces.Repository;
using ScratchCards.Models;

namespace ScratchCards.Managers
{
    public class SignManager : ISignManager
    {
        private readonly ISignRepository signRepository;

        public SignManager(ISignRepository signRepository)
        {
            this.signRepository = signRepository;
        }

        public Sign[] GetSigns()
        {
            return this.signRepository.GetSigns();
        }
    }
}