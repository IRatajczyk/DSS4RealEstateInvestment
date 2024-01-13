using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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


        public void PassDefaultPreferences(HomePage homePage, PreferenceManager preferences, Action<PreferenceManager?> insertPreferences)
        {
            this.preferences = preferences;
            this.InsertPreferences = insertPreferences;
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
                this.maxArea.Text = preferences?.AreaConstraint?.MinValue.ToString() ?? "";
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
                this.maxPrice.Text = preferences?.PriceConstraint?.MinValue.ToString() ?? "";
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
                this.maxNOR.Text = preferences?.RoomsCountConstraint?.MinValue.ToString() ?? "";
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
                this.maxNOB.Text = preferences?.BathroomsCountConstraint?.MinValue.ToString() ?? "";
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

        }

        private void DiscardButton_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
