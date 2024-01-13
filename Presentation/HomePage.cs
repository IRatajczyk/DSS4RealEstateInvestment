using DecisionSystemForRealEastateInvestment.Application.DecisionSupport;

namespace DecisionSystemForRealEastateInvestment
{

    public class HomePageState
    {

        public string City { get; set; }

        public PreferenceManager PreferenceManager { get; set; }


        public HomePageState() 
        {
            City = "Warszawa";
            PreferenceManager = PreferenceManager.Default();
        }
    }
    public partial class HomePage : Form
    {

        public HomePageState State { get; set; } = new();
        public HomePage()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //label1.Text = "Aplikacja stworzona przez MS, D¯, IR";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void InsertPreferences(PreferenceManager? preferences)
        {
            State.PreferenceManager = preferences;
        }

        private void OnSpecifyPreferencesClick(object sender, EventArgs e)
        {
            var preferences = new Presentation.PreferencePage();
            preferences.PassDefaultPreferences(this, State.PreferenceManager, InsertPreferences);
            preferences.Show();

        }
    }
}