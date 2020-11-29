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
using AutoMapper;
using BoligKø.Infrastructure.Queries;
using System.IO;

namespace BoligKø.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //TODO: Martin: Brug APplikation service når implementeret
    public class AnsøgerController : Controller
    {
        private readonly IAnsøgerApplicationService _ansøgerService;
        private readonly IAnsøgerQuery _ansøgerQuery;
        private readonly IMapper _mapper;
        private readonly IAnsøgningQuery _ansøgningQuery;
        
        public AnsøgerController(
            IAnsøgerApplicationService service,
            IAnsøgerQuery query,
            IMapper mapper,
            IAnsøgningQuery ansøgningQuery)
        {
            _ansøgerService = service;
            _ansøgerQuery = query;
            _mapper = mapper;
            _ansøgningQuery = ansøgningQuery;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<JsonResult> Get(string id)
        {
            AnsøgerDto dto = _mapper.Map<AnsøgerDto>(((AnsøgerQuery)_ansøgerQuery).GetByIdIncluding(id, a => a.Ansøgninger));

            if (dto == null) return Json("Ansøger Not found");

            return Json(dto);
        }

        
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(string id)
        {
            AnsøgerDto dto = Mapping.MapAnsøger(_ansøgerQuery.GetById(id));

            if (dto == null) return Json("Ansøger not found");

            await _ansøgerService.SletAsync(id);

            return Json(dto);
        }

        [HttpPost]
        public async Task<JsonResult> Create()
        {
            var request = HttpContext.Request;
            try
            {
                using (var reader = new StreamReader(request.Body))
                {
                    string content = await reader.ReadToEndAsync();

                    AnsøgerDto dto = System.Text.Json.JsonSerializer.Deserialize<AnsøgerDto>(content);

                    await _ansøgerService.OpretAsync(dto);

                    HttpContext.Response.StatusCode = 202;
                    return Json(dto);
                }
            }
            catch (Exception ex)
            {
                //TODO: remove this when proper erro stuff
                return Json(ex.Message);
            }

        }

        public async Task<JsonResult> Index()
        {
            List<AnsøgerDto> dtos = new List<AnsøgerDto>();

            foreach(Ansøger a in ((AnsøgerQuery)_ansøgerQuery).GetAll())
            {
                AnsøgerDto dto = _mapper.Map<AnsøgerDto>(a);

                if (dto.Ansøgninger == null) dto.Ansøgninger = new List<AnsøgningDto>();

                List<Ansøgning> ansøgnings = ((AnsøgningQuery)_ansøgningQuery).GetByAnsøgerId(a.Id);
                foreach(Ansøgning aa in ansøgnings)
                {
                    AnsøgningDto aDto = _mapper.Map<AnsøgningDto>(aa);
                    dto.Ansøgninger.Add(aDto);
                }

                dtos.Add(dto);
                
            }

            return Json(dtos);
        }
    }
}
