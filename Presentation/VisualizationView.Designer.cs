namespace DecisionSystemForRealEastateInvestment.Presentation

{
    partial class VisualizationView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ExitButton = new Button();
            chartPanel = new Panel();
            priceHistPanel = new Panel();
            AreaHistPanel = new Panel();
            SuspendLayout();
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(414, 335);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(94, 29);
            ExitButton.TabIndex = 0;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // chartPanel
            // 
            chartPanel.Location = new Point(12, 12);
            chartPanel.Name = "chartPanel";
            chartPanel.Size = new Size(289, 317);
            chartPanel.TabIndex = 1;
            // 
            // priceHistPanel
            // 
            priceHistPanel.Location = new Point(307, 12);
            priceHistPanel.Name = "priceHistPanel";
            priceHistPanel.Size = new Size(289, 317);
            priceHistPanel.TabIndex = 2;
            // 
            // AreaHistPanel
            // 
            AreaHistPanel.Location = new Point(602, 12);
            AreaHistPanel.Name = "AreaHistPanel";
            AreaHistPanel.Size = new Size(289, 317);
            AreaHistPanel.TabIndex = 3;
            // 
            // VisualizationView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 376);
            Controls.Add(AreaHistPanel);
            Controls.Add(priceHistPanel);
            Controls.Add(chartPanel);
            Controls.Add(ExitButton);
            Name = "VisualizationView";
            Text = "VisualizationView";
            Load += VisualizationView_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button ExitButton;
        private Panel chartPanel;
        private Panel priceHistPanel;
        private Panel AreaHistPanel;
    }
}