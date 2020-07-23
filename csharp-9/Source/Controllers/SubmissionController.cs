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

    public class SubmissionController : ControllerBase

    {

        private readonly ISubmissionService _service;

        private readonly IMapper _mapper;


        public SubmissionController(ISubmissionService service, IMapper mapper)

        {

            _service = service;

            _mapper = mapper;

        }


        // GET api/submission/higherScore

        [HttpGet("/higherScore")]

        public ActionResult<SubmissionDTO> GetHigherScore(int? challengeId)

        {

            if(challengeId != null)

                return Ok(_mapper.Map<SubmissionDTO>(_service.FindHigherScoreByChallengeId(challengeId.Value)));


            return NoContent();

        }


        // GET api/submission

        [HttpGet]

        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? accelerationId = null, int? challengeId = null)

        {

            if (accelerationId != null && challengeId == null)

                return Ok(_mapper.Map<IEnumerable<SubmissionDTO>>(_service.FindByChallengeIdAndAccelerationId(challengeId.Value, accelerationId.Value)));

            

            return NoContent();

        }


        // POST api/submission

        [HttpPost]

        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)

        {

            return Ok(_mapper.Map<SubmissionDTO>(_service.Save(_mapper.Map<Submission>(value))));

        }

    }

}