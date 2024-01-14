using DecisionSystemForRealEastateInvestment.Application.DecisionSupport;


namespace DecisionSystemForRealEastateInvestment.Presentation
{
    public partial class PreferencePage : Form
    {

        private PreferenceManager? preferences;
        private Action<PreferenceManager?>? InsertPreferences;
        public PreferencePage()
        {
            InitializeComponent();
        }


        public void PassDefaultPreferences(Form homePage, PreferenceManager preferences, Action<PreferenceManager?> insertPreferences)
        {
            this.preferences = preferences;
            this.InsertPreferences = insertPreferences;
            SetUpValues();
        }

        private void SetUpValues()
        {
            this.AreaChekBox.Checked = preferences?.AreaConstraint?.IsValid ?? false;
            if (!this.AreaChekBox.Checked)
            {
                this.minArea.Enabled = false;
                this.maxArea.Enabled = false;
            }
            else
            {
                this.minArea.Text = preferences?.AreaConstraint?.MinValue.ToString() ?? "";
                this.maxArea.Text = preferences?.AreaConstraint?.MaxValue.ToString() ?? "";
            }
            this.areaWeight.Value = (int)(preferences?.AreaWeight ?? 0.0);

            this.PriceCheckBox.Checked = preferences?.PriceConstraint?.IsValid ?? false;
            if (!this.PriceCheckBox.Checked)
            {
                this.minPrice.Enabled = false;
                this.maxPrice.Enabled = false;
            }
            else
            {
                this.minPrice.Text = preferences?.PriceConstraint?.MinValue.ToString() ?? "";
                this.maxPrice.Text = preferences?.PriceConstraint?.MaxValue.ToString() ?? "";
            }

            this.priceWeight.Value = (int)(preferences?.PriceWeight ?? 0.0);

            this.NORCheckBox.Checked = preferences?.RoomsCountConstraint?.IsValid ?? false;
            if (!this.NORCheckBox.Checked)
            {
                this.minNOR.Enabled = false;
                this.maxNOR.Enabled = false;
            }
            else
            {
                this.minNOR.Text = preferences?.RoomsCountConstraint?.MinValue.ToString() ?? "";
                this.maxNOR.Text = preferences?.RoomsCountConstraint?.MaxValue.ToString() ?? "";
            }

            this.norWeight.Value = (int)(preferences?.RoomsCountWeight ?? 0.0);

            this.NOBCheckBox.Checked = preferences?.BathroomsCountConstraint?.IsValid ?? false;
            if (!this.NOBCheckBox.Checked)
            {
                this.minNOB.Enabled = false;
                this.maxNOB.Enabled = false;
            }
            else
            {
                this.minNOB.Text = preferences?.BathroomsCountConstraint?.MinValue.ToString() ?? "";
                this.maxNOB.Text = preferences?.BathroomsCountConstraint?.MaxValue.ToString() ?? "";
            }

            this.nobWeight.Value = (int)(preferences?.BathroomsCountWeight ?? 0.0);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void ApplyButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.InsertPreferences?.Invoke(this.preferences);
            Close();
        }

        private void DiscardButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.InsertPreferences?.Invoke(null);
            Close();
        }

        private void priceWeight_Scroll(object sender, EventArgs e)
        {
            if (this.preferences != null) this.preferences.PriceWeight = this.priceWeight.Value;
        }

        private void areaWeight_Scroll(object sender, EventArgs e)
        {
            if (this.preferences != null) this.preferences.AreaWeight = this.areaWeight.Value;
        }

        private void norWeight_Scroll(object sender, EventArgs e)
        {
            if (this.preferences != null) this.preferences.RoomsCountWeight = this.norWeight.Value;
        }

        private void nobWeight_Scroll(object sender, EventArgs e)
        {
            if (this.preferences != null) this.preferences.BathroomsCountWeight = this.nobWeight.Value;
        }

        private void AreaChekBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.AreaChekBox.Checked)
            {
                this.minArea.Enabled = true;
                this.maxArea.Enabled = true;
                this.preferences.AreaConstraint = new ConstraintWrapper(true, double.Parse(minArea.Text), double.Parse(maxArea.Text));
            }
            else
            {
                this.minArea.Enabled = false;
                this.maxArea.Enabled = false;
                this.preferences.AreaConstraint = new ConstraintWrapper(false);
            }
        }

        private void PriceChekBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.PriceCheckBox.Checked)
            {
                this.minPrice.Enabled = true;
                this.maxPrice.Enabled = true;
                this.preferences.PriceConstraint = new ConstraintWrapper(true, double.Parse(minPrice.Text), double.Parse(maxPrice.Text));
            }
            else
            {
                this.minPrice.Enabled = false;
                this.maxPrice.Enabled = false;
                this.preferences.PriceConstraint = new ConstraintWrapper(false);
            }
        }

        private void NORCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (this.NORCheckBox.Checked)
            {
                this.minNOR.Enabled = true;
                this.maxNOR.Enabled = true;
                this.preferences.RoomsCountConstraint = new ConstraintWrapper(true, double.Parse(minNOR.Text), double.Parse(maxNOR.Text));
            }
            else
            {
                this.minNOR.Enabled = false;
                this.maxNOR.Enabled = false;
                this.preferences.RoomsCountConstraint = new ConstraintWrapper(false);
            }
        }

        private void NOBCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (this.NOBCheckBox.Checked)
            {
                this.minNOB.Enabled = true;
                this.maxNOB.Enabled = true;
                this.preferences.BathroomsCountConstraint = new ConstraintWrapper(true, double.Parse(minNOB.Text), double.Parse(maxNOB.Text));
            }
            else
            {
                this.minNOB.Enabled = false;
                this.maxNOB.Enabled = false;
                this.preferences.BathroomsCountConstraint = new ConstraintWrapper(false);
            }
        }



        private void minPrice_ValueChanged(object sender, EventArgs e)
        {
            if (this.preferences != null) this.preferences.PriceConstraint.MinValue = double.Parse(this.minPrice.Text);


        }

        private void maxPrice_ValueChanged(object sender, EventArgs e)
        {

            if (this.preferences != null) this.preferences.PriceConstraint.MaxValue = double.Parse(this.maxPrice.Text);
        }

        private void minArea_ValueChanged(object sender, EventArgs e)
        {

            if (this.preferences != null) this.preferences.AreaConstraint.MinValue = double.Parse(this.minArea.Text);
        }

        private void maxArea_ValueChanged(object sender, EventArgs e)
        {

            if (this.preferences != null) this.preferences.AreaConstraint.MaxValue = double.Parse(this.maxArea.Text);
        }

        private void minNOR_ValueChanged(object sender, EventArgs e)
        {

            if (this.preferences != null) this.preferences.RoomsCountConstraint.MinValue = double.Parse(this.minNOR.Text);
        }

        private void maxNOR_ValueChanged(object sender, EventArgs e)
        {
            if (this.preferences != null) this.preferences.RoomsCountConstraint.MaxValue = double.Parse(this.maxNOR.Text);

        }

        private void minNOB_ValueChanged(object sender, EventArgs e)
        {

            if (this.preferences != null) this.preferences.BathroomsCountConstraint.MinValue = double.Parse(this.minNOB.Text);
        }

        private void maxNOB_ValueChanged(object sender, EventArgs e)
        {

            if (this.preferences != null) this.preferences.BathroomsCountConstraint.MaxValue = double.Parse(this.maxNOB.Text);
        }

        private void PreferencePage_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
