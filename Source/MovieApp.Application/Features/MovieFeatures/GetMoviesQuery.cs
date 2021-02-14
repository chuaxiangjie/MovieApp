using MediatR;
using MovieApp.Core.Domain;
using MovieApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MovieApp.Application.Features.MovieFeatures
{
    public class GetMoviesQuery : EnvelopeRequest<List<Movie>>
    {
        #region Model

        public string Title { get; set; }

        public int ItemIndex { get; set; }

        #endregion

        #region Handler

        public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, Envelope<List<Movie>>>
        {
            private readonly IRepository<MovieLibrary> _movieRepository;

            private const int PAGE_SIZE = 30;

            public GetMoviesQueryHandler(IRepository<MovieLibrary> movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<Envelope<List<Movie>>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
            {
                var movieLibrary = await _movieRepository.GetEntities();

                var movies = movieLibrary.Movies.AsQueryable();

                if (!string.IsNullOrEmpty(request.Title))
                {
                    movies = movies.Where(x =>
                        x.Title.IndexOf(request.Title, StringComparison.OrdinalIgnoreCase) >= 0);
                }

                //default filter
                movies = movies.Where(x => x.ReleaseYear >= 2010);

                //default sort
                movies = movies.OrderBy(x => x.Title);

                // Extract a portion of data

                var model = movies.Skip(request.ItemIndex).Take(PAGE_SIZE).ToList();

                int indexCounter = request.ItemIndex <= 0 ? 0 : request.ItemIndex;

                model.ForEach(x =>
                {
                    x.ItemIndex = ++indexCounter;
                });
                
                return GetSuccessResponse(model);
            }

            private Envelope<List<Movie>> GetSuccessResponse(List<Movie> movies)
            {
                return new Envelope<List<Movie>>()
                {
                    Data = movies,
                    Response = ResponseType.Success
                };
            }
        }

        #endregion
    }
}
