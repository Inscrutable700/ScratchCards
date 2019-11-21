using ScratchCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards.Interfaces.Repository
{
    public interface ISignRepository
    {
        Sign[] GetSigns();
    }
}
