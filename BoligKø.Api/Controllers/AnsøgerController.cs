using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoligKø.Infrastructure;
using BoligKø.Infrastructure.Queries.interfaces;
using BoligKø.ApplicationService;
using BoligKø.ApplicationService.Dto;
using BoligKø.Domain.Model;
using BoligKø.Infrastructure.patterns;
using Microsoft.EntityFrameworkCore;
using BoligKø.Infrastructure.context;

namespace BoligKø.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //TODO: Martin: Brug APplikation service når implementeret
    public class AnsøgerController : Controller
    {
        private readonly IAnsøgerApplicationService _ansøgerService;
        private readonly IAnsøgerQuery _ansøgerQuery;
        
        public AnsøgerController(
            IAnsøgerApplicationService service,
            IAnsøgerQuery query)
        {
            _ansøgerService = service;
            _ansøgerQuery = query;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<JsonResult> Get(string id)
        {
            AnsøgerDto dto = Mapping.MapAnsøger(_ansøgerQuery.GetById(id));

            if (dto == null) return Json("Ansøger Not found");

            return Json(dto);
        }

        
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(string id)
        {
            AnsøgerDto dto = Mapping.MapAnsøger(_ansøgerQuery.GetById(id));

            if (dto == null) return Json("Ansøger not found");

            await _ansøgerService.SletAsync(dto.Id);

            return Json(dto);
        }

        public async Task<JsonResult> Index()
        {
            List<AnsøgerDto> dtos = new List<AnsøgerDto>();

            foreach(Ansøger a in _ansøgerQuery.GetAll())
            {
                dtos.Add(Mapping.MapAnsøger(a));
            }

            return Json(dtos);
        }
    }
}
