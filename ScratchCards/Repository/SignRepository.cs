using ScratchCards.Data;
using ScratchCards.Interfaces;
using ScratchCards.Interfaces.Repository;
using ScratchCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards.Repository
{
    public class SignRepository : ISignRepository
    {
        private ApplicationDbContext context;

        public SignRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Sign[] GetSigns()
        {
            return this.context.Signs.ToArray();

            //throw new NotImplementedException();
        }
    }
}
