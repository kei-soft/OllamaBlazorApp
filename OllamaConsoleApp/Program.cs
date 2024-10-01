using OllamaSharp;

namespace OllamaConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            test();
        }

        static async void test()
        {
            try
            {
                var uri = new Uri("http://localhost:11434");
                var ollamaApiClient = new OllamaApiClient(uri);

                ollamaApiClient.SelectedModel = "EEVE-Korean-10.8B:latest";

                await foreach (var stream in ollamaApiClient.Generate("서울의 맛집을 소개해줘"))
                {
                    Console.Write(stream.Response);
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
