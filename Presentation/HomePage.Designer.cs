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
            VisualizationButton = new Button();
            SuspendLayout();
            // 
            // SpecifyPreferencesButton
            // 
            SpecifyPreferencesButton.Location = new Point(353, 421);
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
            CintyNameTextBox.Location = new Point(353, 353);
            CintyNameTextBox.Name = "CintyNameTextBox";
            CintyNameTextBox.Size = new Size(210, 27);
            CintyNameTextBox.TabIndex = 3;
            CintyNameTextBox.Text = "Warszawa";
            CintyNameTextBox.TextChanged += CintyNameTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(353, 330);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 4;
            label1.Text = "City";
            // 
            // ScraperButton
            // 
            ScraperButton.Location = new Point(353, 386);
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
            ButtonVIKOR.Location = new Point(353, 456);
            ButtonVIKOR.Name = "ButtonVIKOR";
            ButtonVIKOR.Size = new Size(102, 29);
            ButtonVIKOR.TabIndex = 6;
            ButtonVIKOR.Text = "VIKOR";
            ButtonVIKOR.UseVisualStyleBackColor = true;
            ButtonVIKOR.Click += ButtonVIKOR_Click;
            // 
            // ButtonTOPSIS
            // 
            ButtonTOPSIS.Location = new Point(461, 456);
            ButtonTOPSIS.Name = "ButtonTOPSIS";
            ButtonTOPSIS.Size = new Size(102, 29);
            ButtonTOPSIS.TabIndex = 7;
            ButtonTOPSIS.Text = "TOPSIS";
            ButtonTOPSIS.UseVisualStyleBackColor = true;
            ButtonTOPSIS.Click += ButtonTOPSIS_Click;
            // 
            // SerializeResults
            // 
            SerializeResults.Location = new Point(353, 526);
            SerializeResults.Name = "SerializeResults";
            SerializeResults.Size = new Size(210, 29);
            SerializeResults.TabIndex = 8;
            SerializeResults.Text = "Serialize Results";
            SerializeResults.UseVisualStyleBackColor = true;
            SerializeResults.Click += SerializeResults_Click;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(353, 561);
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
            // VisualizationButton
            // 
            VisualizationButton.Location = new Point(353, 491);
            VisualizationButton.Name = "VisualizationButton";
            VisualizationButton.Size = new Size(210, 29);
            VisualizationButton.TabIndex = 10;
            VisualizationButton.Text = "Visualize";
            VisualizationButton.UseVisualStyleBackColor = true;
            VisualizationButton.Click += VisualizationButton_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 612);
            Controls.Add(VisualizationButton);
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
            Load += HomePage_Load;
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
        private Button VisualizationButton;
    }
}