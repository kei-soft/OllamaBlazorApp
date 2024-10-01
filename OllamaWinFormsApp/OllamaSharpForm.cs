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
            this.statusLabel.Text = "�亯 (AI ���� ��...)";
            this.sendButton.Enabled = false;

            try
            {
                // AI ���� �񵿱� ó��
                await foreach (var stream in ollamaApiClient!.Generate(humanTextBox.Text))
                {
                    // UI �����忡�� �����ϰ� �ؽ�Ʈ �ڽ� ������Ʈ
                    await Task.Run(() =>
                    {
                        // �񵿱� UI ������Ʈ - �ǽð����� �ؽ�Ʈ�� ǥ�õǵ��� ����
                        this.Invoke(new MethodInvoker(() =>
                        {
                            aiTextBox.Text += stream!.Response;
                        }));
                    });
                }
            }
            catch (Exception ex)
            {
                // ���� ó��
                MessageBox.Show($"���� �߻�: {ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // �۾� �Ϸ� �� ���� ������Ʈ
                this.statusLabel.Text = "�亯";
                this.sendButton.Enabled = true;
            }
        }

        private void humanTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Enter Ű �Է� ����
                this.sendButton.PerformClick(); // sendButton Ŭ�� �̺�Ʈ ȣ��
            }
        }
    }
}
