namespace OllamaWinFormsApp
{
    partial class OllamaSharpForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            humanTextBox = new TextBox();
            sendButton = new Button();
            statusLabel = new Label();
            aiTextBox = new RichTextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(humanTextBox);
            panel1.Controls.Add(sendButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1421, 79);
            panel1.TabIndex = 0;
            // 
            // humanTextBox
            // 
            humanTextBox.Dock = DockStyle.Fill;
            humanTextBox.Location = new Point(0, 0);
            humanTextBox.Multiline = true;
            humanTextBox.Name = "humanTextBox";
            humanTextBox.Size = new Size(1309, 79);
            humanTextBox.TabIndex = 0;
            humanTextBox.KeyDown += humanTextBox_KeyDown;
            // 
            // sendButton
            // 
            sendButton.Dock = DockStyle.Right;
            sendButton.Location = new Point(1309, 0);
            sendButton.Name = "sendButton";
            sendButton.Padding = new Padding(3);
            sendButton.Size = new Size(112, 79);
            sendButton.TabIndex = 1;
            sendButton.Text = "전송";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Dock = DockStyle.Top;
            statusLabel.Location = new Point(5, 84);
            statusLabel.Name = "statusLabel";
            statusLabel.Padding = new Padding(5);
            statusLabel.Size = new Size(58, 35);
            statusLabel.TabIndex = 1;
            statusLabel.Text = "답변";
            // 
            // aiTextBox
            // 
            aiTextBox.Dock = DockStyle.Fill;
            aiTextBox.Location = new Point(5, 119);
            aiTextBox.Name = "aiTextBox";
            aiTextBox.Size = new Size(1421, 746);
            aiTextBox.TabIndex = 3;
            aiTextBox.Text = "";
            // 
            // OllamaSharpForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1431, 870);
            Controls.Add(aiTextBox);
            Controls.Add(statusLabel);
            Controls.Add(panel1);
            Name = "OllamaSharpForm";
            Padding = new Padding(5);
            Text = "OllamaSharp";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button sendButton;
        private TextBox humanTextBox;
        private Label statusLabel;
        private RichTextBox aiTextBox;
    }
}
