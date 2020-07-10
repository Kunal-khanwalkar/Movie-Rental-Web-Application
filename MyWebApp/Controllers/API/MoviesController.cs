using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyWebApp.Models;
using MyWebApp.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace MyWebApp.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            var movieDtos = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDtos);
        }

        // GET /api/movies/id
        public IHttpActionResult GetMovie(int ID)
        {
            var movie = _context.Movies.SingleOrDefault(Movie => Movie.ID == ID);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.ID = movie.ID;

            return Created(new Uri(Request.RequestUri + "/" + movie.ID), movieDto);
        }

        // PUT /api/movies/id
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int ID, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(Movie => Movie.ID == ID);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/movies/id
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int ID)
        {
            var movieInDb = _context.Movies.SingleOrDefault(Movie => Movie.ID == ID);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
