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
                //#pragma warning disable SKEXP0070 // 형식은 평가 목적으로 제공되며, 이후 업데이트에서 변경되거나 제거될 수 있습니다. 계속하려면 이 진단을 표시하지 않습니다.
                //                var chatService = new OllamaChatCompletionService("llama3.2:latest", new Uri(@"http://localhost:11434"));
                //#pragma warning restore SKEXP0070 // 형식은 평가 목적으로 제공되며, 이후 업데이트에서 변경되거나 제거될 수 있습니다. 계속하려면 이 진단을 표시하지 않습니다.

                //                var chatHistory = new ChatHistory("You are a helpful assistant that knows about AI.");

                //                chatHistory.AddUserMessage("Hi, I'm looking for book suggestions");

                //                var reply = await chatService.GetChatMessageContentAsync(chatHistory);
                //if (reply != null)
                //{

                //}

                // HttpClient 인스턴스 생성
                //using HttpClient client = new HttpClient();

                // URL을 설정하고 HttpClient로 요청을 보냄
                //var content = await client.GetStringAsync(@"http://v.daum.net/v/20241001161812756");

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
