using OllamaSharp;

namespace OllamaWinFormsApp
{
    public partial class OllamaSharpForm : Form
    {
        OllamaApiClient? ollamaApiClient = null;

        public OllamaSharpForm()
        {
            InitializeComponent();

            var uri = new Uri("http://localhost:11434");
            ollamaApiClient = new OllamaApiClient(uri);
            ollamaApiClient.SelectedModel = "EEVE-Korean-10.8B:latest ";
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            this.aiTextBox.Text = "";
            this.statusLabel.Text = "답변 (AI 응답 중...)";
            this.sendButton.Enabled = false;

            try
            {
                // AI 응답 비동기 처리
                await foreach (var stream in ollamaApiClient!.Generate(humanTextBox.Text))
                {
                    // UI 스레드에서 안전하게 텍스트 박스 업데이트
                    await Task.Run(() =>
                    {
                        // 비동기 UI 업데이트 - 실시간으로 텍스트가 표시되도록 설정
                        this.Invoke(new MethodInvoker(() =>
                        {
                            aiTextBox.Text += stream!.Response;
                        }));
                    });
                }
            }
            catch (Exception ex)
            {
                // 예외 처리
                MessageBox.Show($"오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 작업 완료 후 상태 업데이트
                this.statusLabel.Text = "답변";
                this.sendButton.Enabled = true;
            }
        }

        private void humanTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Enter 키 입력 방지
                this.sendButton.PerformClick(); // sendButton 클릭 이벤트 호출
            }
        }
    }
}
