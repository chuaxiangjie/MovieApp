using MovieApp.Core.Domain;
using System;
using System.IO;

namespace MovieApp.Core
{
    public class MovieConfig : IValidatable
    {
        public string FilePath { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(FilePath))
                throw new Exception("MovieConfig.FilePath must not be null or empty");

            if (!File.Exists(FilePath))
                throw new Exception("MovieConfig.FilePath specified file does not exist");
        }
    }
}

