using System.Collections.Generic;
using speechRestfulApi.Models;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace speechRestfulApi.Services
{
    public class  EiraSpeechService : IEiraSpeechService 
    {

        private readonly string? _speechKey;
        private readonly string? _speechRegion;
        // private readonly string? _speechEndpoint;

        public EiraSpeechService()
        {
            _speechKey = Environment.GetEnvironmentVariable("SPEECH_KEY") ?? throw new Exception("SPEECH_KEY environment variable is not set");
            _speechRegion = Environment.GetEnvironmentVariable("SPEECH_REGION") ?? throw new Exception("SPEECH_REGION environment variable is not set");
            // _speechEndpoint = Environment.GetEnvironmentVariable("SPEECH_ENDPOINT") ?? throw new Exception("SPEECH_ENDPOINT environment variable is not set");
        }

        public async Task<string> SynthesizeSpeechAsync(string text)
        {
            var config = SpeechConfig.FromSubscription(_speechKey, _speechRegion);
            // config.EndpointId = _speechEndpoint;
            config.SpeechSynthesisVoiceName = "id-ID-GadisNeural";

            using var synthesizer = new SpeechSynthesizer(config);

            var result = await synthesizer.SpeakTextAsync(text);
            if (result.Reason == ResultReason.SynthesizingAudioCompleted)
            {
                return "Speech synthesized successfully.";
            }
            else if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                return $"Error synthesizing speech: {cancellation.ErrorDetails}";
            }

            return "Unknown error synthesizing speech.";

        }
    }
}
