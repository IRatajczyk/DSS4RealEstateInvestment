using DecisionSystemForRealEastateInvestment.Application.DataManagement;
using DecisionSystemForRealEastateInvestment.Application.DecisionSupport;
using DecisionSystemForRealEastateInvestment.Application.DecisionSupport.Algorithms;
using System.Diagnostics;
using System.Text;

namespace DecisionSystemForRealEastateInvestment
{
    public partial class HomePage : Form
    {
        public class HomePageState
        {
            public bool IsScraping { get; set; } = false;
            public string City { get; set; }

            public string? ProcessingText { get; set; }

            public PreferenceManager PreferenceManager { get; set; }

            public List<DataModel> results { get; set; }

            public Int16 Counter { get; set; }


            public HomePageState()
            {
                City = "Warszawa";
                PreferenceManager = PreferenceManager.Default();
                results = new List<DataModel>();
                Counter = 0;

            }
        }

        public HomePageState State { get; set; } = new();
        public HomePage()
        {
            InitializeComponent();
            resultsPanel.Controls.Add(new Label() { Text = "empty results" });
            resultsPanel.BackColor = Color.White;

        }



        public void InsertPreferences(PreferenceManager? preferences)
        {
            if (preferences != null) State.PreferenceManager = preferences;
            FillResultsPanel(State.results.Where(State.PreferenceManager.IsSatisfied));
        }

        private void OnSpecifyPreferencesClick(object sender, EventArgs e)
        {
            var preferences = new Presentation.PreferencePage();
            preferences.PassDefaultPreferences(this, State.PreferenceManager, InsertPreferences);
            preferences.Show();

        }

        private void ScraperButton_Click(object sender, EventArgs e)
        {
            if (!State.IsScraping) Scrape();
        }


        private void FillResultsPanel(IEnumerable<DataModel> results)
        {
            int counter = 0;
            resultsPanel.Controls.Clear();
            foreach (var result in results)
            {
                Button button = new Button
                {
                    Width = resultsPanel.Width - 20,
                    Height = 120,
                    Text = result.ToString(),
                    Location = new Point(0, counter * 120),
                    TextAlign = ContentAlignment.MiddleLeft,

                };

                button.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(
                            new ProcessStartInfo
                            {
                                FileName = result.Url,
                                UseShellExecute = true
                            });
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Nie uda³o siê otworzyæ strony");
                    }


                };
                resultsPanel.Controls.Add(button);
                counter++;
            }
        }

        private void OnScrapingFinished()
        {
            FillResultsPanel(State.results.Where(State.PreferenceManager.IsSatisfied));
        }


        private async Task Scrape()
        {
            State.results.Clear();
            State.IsScraping = true;
            resultsPanel.Controls.Clear();
            string city = CintyNameTextBox.Text;
            State.ProcessingText = $"Scraping NO for {city}";
            NieruchomosciOnlineScraper NOscraper = new();
            NieruchomosciOnlineController NOcontroller = new(city: city.Trim());
            await NOcontroller.Run(NOscraper, 1, 2);
            State.results.AddRange(NOscraper.DataModels);

            State.ProcessingText = $"Scraping OTODOM for {city}";

            OtoDomScraper OTODOMscraper = new();
            OtoDomController OTODOMcontroller = new(city: city.Trim());
            await OTODOMcontroller.Run(OTODOMscraper, 1, 2);
            State.results.AddRange(OTODOMscraper.DataModels);

            Console.WriteLine("Scraping is done.");

            State.IsScraping = false;
            State.ProcessingText = null;
            OnScrapingFinished();
        }




        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SerializeResults_Click(object sender, EventArgs e)
        {


        }

        private void ProcessingTimer_Tick(object sender, EventArgs e)
        {
            if (State.ProcessingText != null)
            {
                StringBuilder text = new(State.ProcessingText);
                for (int i = 0; i < State.Counter; i++)
                {
                    text = text.Append('.');
                }

                this.DescriptionLabel.Visible = true;
                this.DescriptionLabel.Text = text.ToString();
                this.State.Counter++;
                this.State.Counter %= 4;
            }
            else
            {
                this.DescriptionLabel.Visible = false;
            }
        }

        private void ButtonVIKOR_Click(object sender, EventArgs e)
        {
            VIKOR vikor = new(State.PreferenceManager);
            FillResultsPanel(vikor.GetBestOfferts(State.results.Where(State.PreferenceManager.IsSatisfied).ToList()));
        }

        private void ButtonTOPSIS_Click(object sender, EventArgs e)
        {
            TOPSIS topsis = new(State.PreferenceManager);
            FillResultsPanel(topsis.GetBestOfferts(State.results.Where(State.PreferenceManager.IsSatisfied).ToList()));
        }

        private void VisualizationButton_Click(object sender, EventArgs e)
        {
            var visualization = new Presentation.VisualizationView();
            visualization.Show();
            visualization.FillChart(State.results.Where(State.PreferenceManager.IsSatisfied).ToList());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CintyNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }


    }
}