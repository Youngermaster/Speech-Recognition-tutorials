using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;


namespace AzureSpeechToTextTest
{
    class Program
    {
        async static Task FromFile(SpeechConfig speechConfig)
        {
            //using var audioConfig = AudioConfig.FromWavFileInput(@"C:\Users\juanm\Documents\GitHub\Youngermaster\Speech-Recognition-tutorials\Azure\AzureSpeechToTextTest\AzureSpeechToTextTest\rpiRecording.wav");
            using var audioConfig = AudioConfig.FromWavFileInput(@"C:\Users\juanm\Documents\GitHub\Youngermaster\Speech-Recognition-tutorials\Azure\AzureSpeechToTextTest\AzureSpeechToTextTest\ILikePizza.wav");
            using var recognizer = new SpeechRecognizer(speechConfig, audioConfig);

            var result = await recognizer.RecognizeOnceAsync();
            Console.WriteLine($"RECOGNIZED: Text={result.Text}");
        }

        async static Task FromMic(SpeechConfig speechConfig)
        {
            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using var recognizer = new SpeechRecognizer(speechConfig, audioConfig);

            Console.WriteLine("Speak into your microphone.");
            var result = await recognizer.RecognizeOnceAsync();
            Console.WriteLine($"RECOGNIZED: Text={result.Text}");
        }

        async static Task Main(string[] args)
        {
            var region = "";
            var apiKey = "";
            var speechConfig = SpeechConfig.FromSubscription(apiKey, region);
            await FromFile(speechConfig);
            await FromMic(speechConfig);
            
        }
    }
}
