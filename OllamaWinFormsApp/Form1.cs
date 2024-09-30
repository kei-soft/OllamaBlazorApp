using System.Diagnostics;

using OllamaSharp;

namespace OllamaWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Test();
        }


        private async void Test()
        {
            // set up the client
            var uri = new Uri("http://localhost:11434");
            var ollama = new OllamaApiClient(uri);

            var models = await ollama.ListLocalModels();

            // select a model which should be used for further operations
            ollama.SelectedModel = "llama3.2:latest";

            await foreach (var stream in ollama.Generate("서울의 수도는?"))
            {
                Debug.Write(stream.Response);
            }
        }
    }
}
