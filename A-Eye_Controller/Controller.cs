using System.Net;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace AEye
{
    public partial class Controller : Form
    {
        
        public Controller()
        {
            InitializeComponent();
            mode_cb.SelectedIndex = 1;
        }

        private void SetConfig_Click(object sender, EventArgs e)
        {
            // Get the current config
            var config = new ConfigFile(
                new Config(startStop_cb.Checked.ToString(), mode_cb.SelectedIndex.ToString()), 
                new Weights(false.ToString()), 
                new TakePicture(false.ToString()));

            // Serialize in Json
            string jsonString = JsonSerializer.Serialize(config);

            // Write in file
            File.WriteAllText("config.json", jsonString);

            // Set the trigger
            Program.trigger.EncodeTC = true;

            // Activate button
            if (mode_cb.SelectedIndex == 1)
            {
                takePict_btn.Enabled = true;
            }
            else
            {
                takePict_btn.Enabled = false;
            }

        }

        private void takePict_btn_Click(object sender, EventArgs e)
        {
            // Open the file
            String str;
            try
            {
                str = File.ReadAllText("config.json");
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot read config.json");
                return;
            }
            if (str == null)
            {
                MessageBox.Show("Invalid content in config.json file");
                return ;
            }

            // Deserialize
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            ConfigFile? config = JsonSerializer.Deserialize<ConfigFile>(str, options);
            if (config == null)
            {
                MessageBox.Show("Invalid json structure in config.json file");
                return ;
            }

            // Modify the JSON
            if (config.TakePicture == null)
            {
                config.TakePicture = new TakePicture(true.ToString());
            }
            else
            {
                config.TakePicture.Valid = true.ToString();
            }

            // Save in JSON
            File.WriteAllText("config.json", JsonSerializer.Serialize<ConfigFile>(config));

            // Set the trigger
            Program.trigger.EncodeTC = true;
        }

        private void ip_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ip = IPAddress.Parse(ip_tb.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(Program.Ip);
            if (reply.Status == IPStatus.Success)
            {
                MessageBox.Show("New IP set : " + Program.Ip);
                Status.Text = "Connected";
                Status.BackColor = Color.YellowGreen;
            } 
            else
            {
                MessageBox.Show("Wrong IP set : " + Program.Ip);
                Program.Ip = null;
                Status.Text = "Wrong IP";
                Status.BackColor = Color.Red;
            }
        }

        private void SelectPict_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                visionneuse.Load(openFileDialog1.FileName);
            }
        }

        private void viewLog_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Program.log);
        }
    }
}