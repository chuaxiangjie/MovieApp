using MovieApp.Core.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    public class FileRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public FileRepository()
        {


        }

        public async Task<TEntity> GetEntities()
        {
            using var reader = new StreamReader("sample.json");
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
