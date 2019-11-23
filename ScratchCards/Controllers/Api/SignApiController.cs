using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScratchCards.Interfaces.Manager;
using ScratchCards.Interfaces.Repository;
using ScratchCards.Models;
using ScratchCards.Models.Api.Sign;

namespace ScratchCards.Controllers.Api
{
    [Route("api/sign")]
    [ApiController]
    public class SignApiController : ControllerBase
    {
        private readonly ISignManager signManager;

        public SignApiController(ISignManager signManager)
        {
            this.signManager = signManager;
        }

        public GetSignsResponse GetSigns()
        {
            Sign[] signs = this.signManager.GetSigns();

            GetSignsResponse response = new GetSignsResponse
            {
                Signs = signs.Select(s => new GetSignsResponse.Sign
                {
                    Id = s.Id,
                    ImageUrl = s.ImageUrl,
                    Name = s.Name
                }).ToArray()
            };

            return response;
        }
    }
}