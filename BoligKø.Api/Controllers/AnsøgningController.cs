using AutoMapper;
using BoligKø.ApplicationService;
using BoligKø.ApplicationService.Dto;
using BoligKø.Domain.Model;
using BoligKø.Infrastructure.Queries.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BoligKø.Api.Controllers
{
    //TODO: Proper Json Errors
    [ApiController]
    [Route("api/[controller]")]
    public class AnsøgningController : Controller
    {
        private readonly IAnsøgningQuery _ansøgningQuery;
        private readonly IAnsøgningCommand _ansøgningCommand;
        private readonly IAnsøgningApplicationService _ansøgningService;
        private readonly IMapper _mapper;
        public AnsøgningController(
            IAnsøgningQuery ansøgningQuery,
            IAnsøgningCommand ansøgningCommand,
            IMapper mapper,
            IAnsøgningApplicationService ansøgningService)
        {
            _ansøgningCommand = ansøgningCommand;
            _ansøgningQuery = ansøgningQuery;
            _mapper = mapper;
            _ansøgningService = ansøgningService;
        }
        public JsonResult Index()
        {
            List<AnsøgningDto> dtos = new List<AnsøgningDto>();
            foreach(Ansøgning a in _ansøgningQuery.GetAll())
            {
                AnsøgningDto dto = _mapper.Map<AnsøgningDto>(a);
                dtos.Add(dto);
            }
            return Json(dtos);
        }

        [HttpGet]
        [Route("{id}")]
        public JsonResult Get(string id)
        {
            Ansøgning ansøg = _ansøgningQuery.GetById(id);

            if (ansøg == null) return Json("No ansøgning by that id");

            AnsøgningDto dto = _mapper.Map<AnsøgningDto>(_ansøgningQuery.GetById(id));

            return Json(dto);
        }

        //TODO: Dette virker ikke pga. nævnet problem med navigation property på JsonIgnore
        [HttpDelete]
        [Route("{id}")]
        public async Task<JsonResult> Delete(string id)
        {
            AnsøgningDto dto = _mapper.Map<AnsøgningDto>(_ansøgningQuery.GetById(id));

            if (dto == null) return Json("No ansøgning by that id");

            await _ansøgningService.SletAsync(id);

            return Json(dto);
        }

        //TODO: Proper error handling
        [HttpPost]
        public async Task<JsonResult> Create()
        {
            var request = HttpContext.Request;

            try
            {
                using (var reader = new StreamReader(request.Body))
                {
                    string body = await reader.ReadToEndAsync();

                    AnsøgningDto dto = System.Text.Json.JsonSerializer.Deserialize<AnsøgningDto>(body);

                    await _ansøgningService.OpretAsync(dto);

                    return Json(dto);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
