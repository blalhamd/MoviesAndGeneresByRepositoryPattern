using DomainModel.Entities;
using DomainModel.EntitiesDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddleLayer.Interfaces;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenereController : ControllerBase
    {
        private readonly IGenericRepository<Genere> _GenereRepository;

        public GenereController(IGenericRepository<Genere> GenereRepository)
        {
            _GenereRepository = GenereRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllGeneres()
        {
            var result = await _GenereRepository.GetAll(); //.Select(x=>new {x.Id, x.Name});

            if (result is null)
                return NotFound("Not exist Generes");

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenereById(int id)
        {
            var search = await _GenereRepository.GetById(id);

            if (search is null)
                return NotFound("this Genere is not exist");

            return Ok(search);
        }


        [HttpPost]
        public async Task<IActionResult> addGenere([FromBody] GenereDTO genereDTO)
        {

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            if (genereDTO is null)
                return BadRequest("the item is null");

            Genere genere = new Genere()
            {
              Name= genereDTO.Name,

            };

            _GenereRepository.add(genere);
            _GenereRepository.Save();

            return Created("", genere);

        }


        [HttpPost("{AddRange}")]
        public async Task<IActionResult> addRangeGenere([FromBody] List<GenereDTO> genereDTOs)
        {

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            if (genereDTOs is null)
                return BadRequest("the item is null");

            List<Genere> genereList = new List<Genere>();

            foreach (var item in genereDTOs)
            {

                Genere genere = new Genere()
                {
                    Name = item.Name,

                };

                genereList.Add(genere);
            }

            _GenereRepository.addRange(genereList);
            _GenereRepository.Save();

            return Created("", genereList);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> updateGenere([FromBody] GenereDTO genereDTO, int id)
        {
            var query=await _GenereRepository.GetById(id);

            if (query is null)
                return NotFound("this genere is not exist");

            if (!ModelState.IsValid)
                return BadRequest("Model State is invalid");

            if (genereDTO is null)
                return BadRequest("this genere is null");


            query.Name=genereDTO.Name;

            _GenereRepository.update(query);

            return Ok(query);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteGenere(int id)
        {
            var query= await _GenereRepository.GetById(id);

            if (query == null)
                return BadRequest("this genere is not exist");

            _GenereRepository.delete(query);
            _GenereRepository.Save();

            return Ok(query);
        }


    }
}
