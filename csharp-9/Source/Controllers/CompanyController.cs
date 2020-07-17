using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _service;
        private IMapper _mapper;

        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/company/{id}
        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            return Ok(_mapper.Map<CompanyDTO>(_service.FindById(id)));
        }

        // GET api/company
        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if (accelerationId != null && userId == null)
                return Ok(_mapper.Map<IEnumerable<CompanyDTO>>(_service.FindByAccelerationId(accelerationId.Value)));
            else if (accelerationId == null && userId != null)
                return Ok(_mapper.Map<IEnumerable<CompanyDTO>>(_service.FindByUserId(userId.Value)));

            return NoContent();
        }

        // POST api/company
        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            return Ok(_mapper.Map<CompanyDTO>(_service.Save(_mapper.Map<Company>(value))));
        }
    }
}
