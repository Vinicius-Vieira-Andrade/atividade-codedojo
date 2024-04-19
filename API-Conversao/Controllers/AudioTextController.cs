using API_Conversao.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech;

namespace API_Conversao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioTextController : ControllerBase
    {
        public IFormFile? file { get; set; }

        [HttpPost("TextoPraVoz")]
        public async Task<IActionResult> ConvertTextToAudio(string text)
        {
            //configuracoes do servico cognitivo da azure
            var speechConfig = SpeechConfig.FromSubscription("63fe14ea7e474db5990b1a98825b4658", "eastus");

            using (var speech = new SpeechSynthesizer(speechConfig))
            {
                var result = await speech.SpeakTextAsync(text);
                if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                {
                    return Ok("Texto convertido com sucesso" + result);
                }

                return BadRequest("deu erro" + result);
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> ConvertAudioText([FromForm] IFormFile? file)
        //{
        //    return Ok();
        //}


        [HttpPost]
        public async Task<IActionResult> ConvertAudioText([FromForm] IFormFile? file)
        {
            var containerName = "audio-api";

            var stringConexao = "DefaultEndpointsProtocol=https;AccountName=vitahubg10;AccountKey=0f4F0m+JXwms9KPYeHtqmQ1m5ggzPOieFXDt7VfWqcUV1qDiviHjtesLPYi0jBJ7xDOiORGa4rHp+ASto9sJxw==;EndpointSuffix=core.windows.net";

            var audio = await FileAudio.UploadAudioBlobAsync(file!, stringConexao, containerName);

            return Ok(audio);
             
                //try
                //{
                //    var speechConfig = SpeechConfig.FromSubscription("63fe14ea7e474db5990b1a98825b4658", "eastus");
                //    speechConfig.SpeechRecognitionLanguage = "pt-BR";
                //    using var audioConfig = AudioConfig.FromWavFileInput(audio);
                //    using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);

                //    var result = await speechRecognizer.RecognizeOnceAsync();

                //    return Ok(result);
                //}
                //catch (Exception erro)
                //{
                //    return BadRequest(erro.Message);
                //}
            

            //return BadRequest("deu erro");


        }
    }
}
