using MovieApp.Core;
using MovieApp.Core.Domain;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    public class FileRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MovieConfig _movieConfig;

        public FileRepository(MovieConfig movieConfig)
        {
            _movieConfig = movieConfig;
        }

        public async Task<TEntity> GetEntities()
        {
            using var reader = new StreamReader(_movieConfig.FilePath);
            string json = await reader.ReadToEndAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var output = JsonSerializer.Deserialize<TEntity>(json, options);

            return output;
        }
    }
}
