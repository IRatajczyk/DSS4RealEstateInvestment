namespace DecisionSystemForRealEastateInvestment
{
    partial class HomePage
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
            components = new System.ComponentModel.Container();
            SpecifyPreferencesButton = new Button();
            resultsPanel = new Panel();
            CintyNameTextBox = new TextBox();
            label1 = new Label();
            ScraperButton = new Button();
            DescriptionLabel = new Label();
            ButtonVIKOR = new Button();
            ButtonTOPSIS = new Button();
            SerializeResults = new Button();
            ExitButton = new Button();
            ProcessingTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // SpecifyPreferencesButton
            // 
            SpecifyPreferencesButton.Location = new Point(353, 435);
            SpecifyPreferencesButton.Name = "SpecifyPreferencesButton";
            SpecifyPreferencesButton.Size = new Size(210, 29);
            SpecifyPreferencesButton.TabIndex = 1;
            SpecifyPreferencesButton.Text = "Specify preferences";
            SpecifyPreferencesButton.UseVisualStyleBackColor = true;
            SpecifyPreferencesButton.Click += OnSpecifyPreferencesClick;
            // 
            // resultsPanel
            // 
            resultsPanel.AutoScroll = true;
            resultsPanel.Location = new Point(12, 12);
            resultsPanel.Name = "resultsPanel";
            resultsPanel.Size = new Size(335, 584);
            resultsPanel.TabIndex = 2;
            // 
            // CintyNameTextBox
            // 
            CintyNameTextBox.Location = new Point(353, 367);
            CintyNameTextBox.Name = "CintyNameTextBox";
            CintyNameTextBox.Size = new Size(210, 27);
            CintyNameTextBox.TabIndex = 3;
            CintyNameTextBox.Text = "Warszawa";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(353, 344);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 4;
            label1.Text = "City";
            // 
            // ScraperButton
            // 
            ScraperButton.Location = new Point(353, 400);
            ScraperButton.Name = "ScraperButton";
            ScraperButton.Size = new Size(210, 29);
            ScraperButton.TabIndex = 0;
            ScraperButton.Text = "Run Scrapers";
            ScraperButton.UseVisualStyleBackColor = true;
            ScraperButton.Click += ScraperButton_Click;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(353, 199);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(192, 20);
            DescriptionLabel.TabIndex = 5;
            DescriptionLabel.Text = "Lorem ipsum dolor sit amet";
            DescriptionLabel.Visible = false;
            // 
            // ButtonVIKOR
            // 
            ButtonVIKOR.Location = new Point(353, 470);
            ButtonVIKOR.Name = "ButtonVIKOR";
            ButtonVIKOR.Size = new Size(102, 29);
            ButtonVIKOR.TabIndex = 6;
            ButtonVIKOR.Text = "VIKOR";
            ButtonVIKOR.UseVisualStyleBackColor = true;
            ButtonVIKOR.Click += ButtonVIKOR_Click;
            // 
            // ButtonTOPSIS
            // 
            ButtonTOPSIS.Location = new Point(461, 470);
            ButtonTOPSIS.Name = "ButtonTOPSIS";
            ButtonTOPSIS.Size = new Size(102, 29);
            ButtonTOPSIS.TabIndex = 7;
            ButtonTOPSIS.Text = "TOPSIS";
            ButtonTOPSIS.UseVisualStyleBackColor = true;
            ButtonTOPSIS.Click += ButtonTOPSIS_Click;
            // 
            // SerializeResults
            // 
            SerializeResults.Location = new Point(353, 528);
            SerializeResults.Name = "SerializeResults";
            SerializeResults.Size = new Size(210, 29);
            SerializeResults.TabIndex = 8;
            SerializeResults.Text = "Serialize Results";
            SerializeResults.UseVisualStyleBackColor = true;
            SerializeResults.Click += SerializeResults_Click;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(353, 563);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(210, 29);
            ExitButton.TabIndex = 9;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // ProcessingTimer
            // 
            ProcessingTimer.Enabled = true;
            ProcessingTimer.Interval = 500;
            ProcessingTimer.Tick += ProcessingTimer_Tick;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 612);
            Controls.Add(ExitButton);
            Controls.Add(SerializeResults);
            Controls.Add(ButtonTOPSIS);
            Controls.Add(ButtonVIKOR);
            Controls.Add(DescriptionLabel);
            Controls.Add(ScraperButton);
            Controls.Add(label1);
            Controls.Add(CintyNameTextBox);
            Controls.Add(resultsPanel);
            Controls.Add(SpecifyPreferencesButton);
            Name = "HomePage";
            Text = "DSS4HI";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button SpecifyPreferencesButton;
        private Panel resultsPanel;
        private TextBox CintyNameTextBox;
        private Label label1;
        private Button ScraperButton;
        private Label DescriptionLabel;
        private Button ButtonVIKOR;
        private Button ButtonTOPSIS;
        private Button SerializeResults;
        private Button ExitButton;
        private System.Windows.Forms.Timer ProcessingTimer;
    }
}