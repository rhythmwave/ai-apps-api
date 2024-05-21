using System.Collections.Generic;
using speechRestfulApi.Models;
using System.Threading.Tasks;

namespace speechRestfulApi.Services
{
    public interface IEiraSpeechService
    {
        Task<string> SynthesizeSpeechAsync(string text);

    }
}
