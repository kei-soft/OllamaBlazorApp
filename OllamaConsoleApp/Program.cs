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

                // set up the client
                var uri = new Uri("http://localhost:11434");
                var ollama = new OllamaApiClient(uri);

                // select a model which should be used for further operations
                ollama.SelectedModel = "llama3.2:latest";

                var models = await ollama.ListLocalModels();


                await foreach (var stream in ollama.Generate("How are you today?"))
                    Console.Write(stream.Response);


            }
            catch (Exception ex)
            {

            }
        }
    }
}
