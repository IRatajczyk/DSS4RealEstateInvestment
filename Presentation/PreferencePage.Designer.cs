namespace DecisionSystemForRealEastateInvestment.Presentation
{
    partial class PreferencePage
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
            components = new System.ComponentModel.Container();
            Price = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            PriceCheckBox = new CheckBox();
            AreaChekBox = new CheckBox();
            NORCheckBox = new CheckBox();
            NOBCheckBox = new CheckBox();
            priceWeight = new TrackBar();
            areaWeight = new TrackBar();
            norWeight = new TrackBar();
            nobWeight = new TrackBar();
            minPrice = new NumericUpDown();
            label5 = new Label();
            label6 = new Label();
            maxPrice = new NumericUpDown();
            label7 = new Label();
            maxArea = new NumericUpDown();
            label8 = new Label();
            minArea = new NumericUpDown();
            label9 = new Label();
            maxNOR = new NumericUpDown();
            label10 = new Label();
            minNOR = new NumericUpDown();
            label11 = new Label();
            maxNOB = new NumericUpDown();
            label12 = new Label();
            minNOB = new NumericUpDown();
            ApplyButton = new Button();
            DiscardButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)priceWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)areaWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)norWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nobWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxArea).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minArea).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxNOR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minNOR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxNOB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minNOB).BeginInit();
            SuspendLayout();
            // 
            // Price
            // 
            Price.AutoSize = true;
            Price.Location = new Point(100, 60);
            Price.Name = "Price";
            Price.Size = new Size(41, 20);
            Price.TabIndex = 0;
            Price.Text = "Price";
            Price.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 160);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 1;
            label2.Text = "Area";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(100, 260);
            label3.Name = "label3";
            label3.Size = new Size(125, 20);
            label3.TabIndex = 2;
            label3.Text = "Number of Room";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(100, 360);
            label4.Name = "label4";
            label4.Size = new Size(157, 20);
            label4.TabIndex = 3;
            label4.Text = "Number of Bathrooms";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(402, 60);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 4;
            label1.Text = "Relative Preference";
            label1.Click += label1_Click_1;
            // 
            // PriceCheckBox
            // 
            PriceCheckBox.AutoSize = true;
            PriceCheckBox.Checked = true;
            PriceCheckBox.CheckState = CheckState.Checked;
            PriceCheckBox.Location = new Point(100, 83);
            PriceCheckBox.Name = "PriceCheckBox";
            PriceCheckBox.Size = new Size(122, 24);
            PriceCheckBox.TabIndex = 5;
            PriceCheckBox.Text = "UseContraints";
            PriceCheckBox.UseVisualStyleBackColor = true;
            PriceCheckBox.CheckedChanged += PriceChekBox_CheckedChanged;
            // 
            // AreaChekBox
            // 
            AreaChekBox.AutoSize = true;
            AreaChekBox.Checked = true;
            AreaChekBox.CheckState = CheckState.Checked;
            AreaChekBox.Location = new Point(100, 183);
            AreaChekBox.Name = "AreaChekBox";
            AreaChekBox.Size = new Size(122, 24);
            AreaChekBox.TabIndex = 6;
            AreaChekBox.Text = "UseContraints";
            AreaChekBox.UseVisualStyleBackColor = true;
            AreaChekBox.CheckedChanged += AreaChekBox_CheckedChanged;
            // 
            // NORCheckBox
            // 
            NORCheckBox.AutoSize = true;
            NORCheckBox.Checked = true;
            NORCheckBox.CheckState = CheckState.Checked;
            NORCheckBox.Location = new Point(100, 283);
            NORCheckBox.Name = "NORCheckBox";
            NORCheckBox.Size = new Size(122, 24);
            NORCheckBox.TabIndex = 7;
            NORCheckBox.Text = "UseContraints";
            NORCheckBox.UseVisualStyleBackColor = true;
            NORCheckBox.CheckedChanged += NORCheckBox_CheckedChanged;
            // 
            // NOBCheckBox
            // 
            NOBCheckBox.AutoSize = true;
            NOBCheckBox.Checked = true;
            NOBCheckBox.CheckState = CheckState.Checked;
            NOBCheckBox.Location = new Point(100, 383);
            NOBCheckBox.Name = "NOBCheckBox";
            NOBCheckBox.Size = new Size(122, 24);
            NOBCheckBox.TabIndex = 8;
            NOBCheckBox.Text = "UseContraints";
            NOBCheckBox.UseVisualStyleBackColor = true;
            NOBCheckBox.CheckedChanged += NOBCheckBox_CheckedChanged;
            // 
            // priceWeight
            // 
            priceWeight.Location = new Point(402, 106);
            priceWeight.Name = "priceWeight";
            priceWeight.Size = new Size(211, 56);
            priceWeight.TabIndex = 9;
            priceWeight.Scroll += priceWeight_Scroll;
            // 
            // areaWeight
            // 
            areaWeight.Location = new Point(402, 206);
            areaWeight.Name = "areaWeight";
            areaWeight.Size = new Size(211, 56);
            areaWeight.TabIndex = 10;
            areaWeight.Scroll += areaWeight_Scroll;
            // 
            // norWeight
            // 
            norWeight.Location = new Point(402, 306);
            norWeight.Name = "norWeight";
            norWeight.Size = new Size(211, 56);
            norWeight.TabIndex = 11;
            norWeight.Scroll += norWeight_Scroll;
            // 
            // nobWeight
            // 
            nobWeight.Location = new Point(402, 406);
            nobWeight.Name = "nobWeight";
            nobWeight.Size = new Size(211, 56);
            nobWeight.TabIndex = 12;
            nobWeight.Scroll += nobWeight_Scroll;
            // 
            // minPrice
            // 
            minPrice.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            minPrice.Location = new Point(143, 110);
            minPrice.Maximum = new decimal(new int[] { 1500000, 0, 0, 0 });
            minPrice.Name = "minPrice";
            minPrice.Size = new Size(75, 27);
            minPrice.TabIndex = 13;
            minPrice.ValueChanged += minPrice_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(100, 112);
            label5.Name = "label5";
            label5.Size = new Size(37, 20);
            label5.TabIndex = 14;
            label5.Text = "min:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(224, 112);
            label6.Name = "label6";
            label6.Size = new Size(40, 20);
            label6.TabIndex = 16;
            label6.Text = "max:";
            // 
            // maxPrice
            // 
            maxPrice.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            maxPrice.Location = new Point(267, 110);
            maxPrice.Maximum = new decimal(new int[] { 15000000, 0, 0, 0 });
            maxPrice.Name = "maxPrice";
            maxPrice.Size = new Size(129, 27);
            maxPrice.TabIndex = 15;
            maxPrice.ValueChanged += maxPrice_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(224, 215);
            label7.Name = "label7";
            label7.Size = new Size(40, 20);
            label7.TabIndex = 20;
            label7.Text = "max:";
            // 
            // maxArea
            // 
            maxArea.Location = new Point(267, 213);
            maxArea.Name = "maxArea";
            maxArea.Size = new Size(75, 27);
            maxArea.TabIndex = 19;
            maxArea.ValueChanged += maxArea_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(100, 215);
            label8.Name = "label8";
            label8.Size = new Size(37, 20);
            label8.TabIndex = 18;
            label8.Text = "min:";
            // 
            // minArea
            // 
            minArea.Location = new Point(143, 213);
            minArea.Name = "minArea";
            minArea.Size = new Size(75, 27);
            minArea.TabIndex = 17;
            minArea.ValueChanged += minArea_ValueChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(224, 314);
            label9.Name = "label9";
            label9.Size = new Size(40, 20);
            label9.TabIndex = 24;
            label9.Text = "max:";
            // 
            // maxNOR
            // 
            maxNOR.Location = new Point(267, 312);
            maxNOR.Name = "maxNOR";
            maxNOR.Size = new Size(75, 27);
            maxNOR.TabIndex = 23;
            maxNOR.ValueChanged += maxNOR_ValueChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(100, 314);
            label10.Name = "label10";
            label10.Size = new Size(37, 20);
            label10.TabIndex = 22;
            label10.Text = "min:";
            // 
            // minNOR
            // 
            minNOR.Location = new Point(143, 312);
            minNOR.Name = "minNOR";
            minNOR.Size = new Size(75, 27);
            minNOR.TabIndex = 21;
            minNOR.ValueChanged += minNOR_ValueChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(224, 419);
            label11.Name = "label11";
            label11.Size = new Size(40, 20);
            label11.TabIndex = 28;
            label11.Text = "max:";
            // 
            // maxNOB
            // 
            maxNOB.Location = new Point(267, 417);
            maxNOB.Name = "maxNOB";
            maxNOB.Size = new Size(75, 27);
            maxNOB.TabIndex = 27;
            maxNOB.ValueChanged += maxNOB_ValueChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(100, 419);
            label12.Name = "label12";
            label12.Size = new Size(37, 20);
            label12.TabIndex = 26;
            label12.Text = "min:";
            // 
            // minNOB
            // 
            minNOB.Location = new Point(143, 417);
            minNOB.Name = "minNOB";
            minNOB.Size = new Size(75, 27);
            minNOB.TabIndex = 25;
            minNOB.ValueChanged += minNOB_ValueChanged;
            // 
            // ApplyButton
            // 
            ApplyButton.Location = new Point(281, 484);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(94, 29);
            ApplyButton.TabIndex = 29;
            ApplyButton.Text = "Apply";
            ApplyButton.UseVisualStyleBackColor = true;
            ApplyButton.MouseClick += ApplyButton_MouseClick;
            // 
            // DiscardButton
            // 
            DiscardButton.Location = new Point(281, 535);
            DiscardButton.Name = "DiscardButton";
            DiscardButton.Size = new Size(94, 29);
            DiscardButton.TabIndex = 30;
            DiscardButton.Text = "Discard";
            DiscardButton.UseVisualStyleBackColor = true;
            DiscardButton.MouseClick += DiscardButton_MouseClick;
            // 
            // timer1
            // 
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // PreferencePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 595);
            Controls.Add(DiscardButton);
            Controls.Add(ApplyButton);
            Controls.Add(label11);
            Controls.Add(maxNOB);
            Controls.Add(label12);
            Controls.Add(minNOB);
            Controls.Add(label9);
            Controls.Add(maxNOR);
            Controls.Add(label10);
            Controls.Add(minNOR);
            Controls.Add(label7);
            Controls.Add(maxArea);
            Controls.Add(label8);
            Controls.Add(minArea);
            Controls.Add(label6);
            Controls.Add(maxPrice);
            Controls.Add(label5);
            Controls.Add(minPrice);
            Controls.Add(nobWeight);
            Controls.Add(norWeight);
            Controls.Add(areaWeight);
            Controls.Add(priceWeight);
            Controls.Add(NOBCheckBox);
            Controls.Add(NORCheckBox);
            Controls.Add(AreaChekBox);
            Controls.Add(PriceCheckBox);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Price);
            Name = "PreferencePage";
            Text = "PreferencePage";
            Load += PreferencePage_Load;
            ((System.ComponentModel.ISupportInitialize)priceWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)areaWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)norWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)nobWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)minPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxArea).EndInit();
            ((System.ComponentModel.ISupportInitialize)minArea).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxNOR).EndInit();
            ((System.ComponentModel.ISupportInitialize)minNOR).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxNOB).EndInit();
            ((System.ComponentModel.ISupportInitialize)minNOB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Price;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label1;
        private CheckBox PriceCheckBox;
        private CheckBox AreaChekBox;
        private CheckBox NORCheckBox;
        private CheckBox NOBCheckBox;
        private TrackBar priceWeight;
        private TrackBar areaWeight;
        private TrackBar norWeight;
        private TrackBar nobWeight;
        private NumericUpDown minPrice;
        private Label label5;
        private Label label6;
        private NumericUpDown maxPrice;
        private Label label7;
        private NumericUpDown maxArea;
        private Label label8;
        private NumericUpDown minArea;
        private Label label9;
        private NumericUpDown maxNOR;
        private Label label10;
        private NumericUpDown minNOR;
        private Label label11;
        private NumericUpDown maxNOB;
        private Label label12;
        private NumericUpDown minNOB;
        private Button ApplyButton;
        private Button DiscardButton;
        private System.Windows.Forms.Timer timer1;
    }
}