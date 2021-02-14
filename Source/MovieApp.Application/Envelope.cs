using MediatR;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MovieApp.Application
{
    public class Envelope<T> where T : class
    {
        public bool Success
        {
            get
            {
                if (Response == ResponseType.Success)
                    return true;
                else
                    return false;
            }
        }

        public string Message { get; set; } = "";

        public List<string> Errors { get; set; } = new List<string>();

        public T Data { get; set; } = default(T);

        [JsonIgnore]
        public ResponseType Response { get; set; }
    }

    public class EnvelopeRequest<T> : IRequest<Envelope<T>> where T : class { }
}
