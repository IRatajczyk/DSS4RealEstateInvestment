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
            pictureBox1 = new PictureBox();
            SpecifyPreferencesButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(389, 426);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // SpecifyPreferencesButton
            // 
            SpecifyPreferencesButton.Location = new Point(355, 709);
            SpecifyPreferencesButton.Name = "SpecifyPreferencesButton";
            SpecifyPreferencesButton.Size = new Size(210, 29);
            SpecifyPreferencesButton.TabIndex = 1;
            SpecifyPreferencesButton.Text = "Specify preferences";
            SpecifyPreferencesButton.UseVisualStyleBackColor = true;
            SpecifyPreferencesButton.Click += OnSpecifyPreferencesClick;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 838);
            Controls.Add(SpecifyPreferencesButton);
            Controls.Add(pictureBox1);
            Name = "HomePage";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button SpecifyPreferencesButton;
    }
}