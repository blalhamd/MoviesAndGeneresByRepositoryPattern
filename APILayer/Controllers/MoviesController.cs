using DomainModel.Entities;
using DomainModel.EntitiesDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddleLayer.Interfaces;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IGenericRepository<Movie> _MovieRepository;

        public MoviesController(IGenericRepository<Movie> movieRepository)
        {
            _MovieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var result = await _MovieRepository.GetAll(); //.Select(x => new { x.Id, x.Title, x.Rate, x.StoreLine, x.year, x.poster, x.genereId });

            if (result is null)
                return NotFound("Not exist Movies");

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var search = await _MovieRepository.GetById(id);

            if (search is null)
                return NotFound("this Movie is not exist");

            return Ok(search);
        }


        [HttpPost]
        public async Task<IActionResult> addMovie([FromForm] MovieDTO movieDTO)
        {

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            if (movieDTO is null)
                return BadRequest("the item is null");

            using var dataStream=new MemoryStream();

            movieDTO.poster.CopyTo(dataStream);

            Movie movie = new Movie()
            {
                Title = movieDTO.Title,
                genereId = movieDTO.genereId,
                StoreLine = movieDTO.StoreLine,
                Rate = movieDTO.Rate,
                year = movieDTO.year,
                poster = dataStream.ToArray()
            };

            _MovieRepository.add(movie);
            _MovieRepository.Save();

            return Created("", movie);

        }


        [HttpPost("AddRange")]
        public async Task<IActionResult> addRangeMovie([FromForm] List<MovieDTO> movieDTOs)
        {

            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid");

            if (movieDTOs is null)
                return BadRequest("the item is null");

            List<Movie> movieList = new List<Movie>();

            using var dataStream = new MemoryStream();

            foreach (var item in movieDTOs)
            {
                item.poster.CopyTo(dataStream);

                Movie movie = new Movie()
                {
                    Title = item.Title,
                    genereId = item.genereId,
                    StoreLine = item.StoreLine,
                    Rate = item.Rate,
                    year = item.year,
                    poster = dataStream.ToArray()
                };

                movieList.Add(movie);
            }

            _MovieRepository.addRange(movieList);
            _MovieRepository.Save();

            return Created("",movieList);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> updateMovie([FromForm] MovieDTO movieDTO,int id) 
        {
            var query = await _MovieRepository.GetById(id);

            if (query is null)
                return NotFound("this Movie is not exist");

            if (!ModelState.IsValid)
                return BadRequest("Model State is invalid");

            if(movieDTO is null)
                return BadRequest("this movie is null");

            using var dataStream = new MemoryStream();

            movieDTO.poster.CopyTo(dataStream);

     
                query.Title = movieDTO.Title,
                query.genereId = movieDTO.genereId,
                query.StoreLine = movieDTO.StoreLine,
                query.Rate = movieDTO.Rate,
                query.year = movieDTO.year,
                query.poster = dataStream.ToArray()
      

            _MovieRepository.update(query);

            return Ok(query);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteMovie(int id)
        {
            var query= await _MovieRepository.GetById(id);

            if (query == null)
                return BadRequest("this movie is not exist");

            _MovieRepository.delete(query);

            return Ok(query);
        }


       



    }
}
