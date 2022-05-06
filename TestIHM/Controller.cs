using System.Net;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace AEye
{
    public partial class Controller : Form
    {
        public IPAddress? Ip;
        public Controller()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                visionneuse.Load(openFileDialog1.FileName);
            }
        }

        private void SetConfig_Click(object sender, EventArgs e)
        {
            // Get the current config
            ConfigFile config = new ConfigFile(
                new Config(startStop_cb.Checked, mode_lb.SelectedIndex), 
                new Weights(false), 
                new TakePicture(false));

            // Serialize in Json
            string jsonString = JsonSerializer.Serialize(config);
            // Write in file
            File.WriteAllText("config.json", jsonString);

            // Activate button
            if (mode_lb.SelectedIndex == 1)
            {
                takePict_btn.Enabled = true;
            }
            else
            {
                takePict_btn.Enabled = false;
            }
        }

        private void visionneuse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                visionneuse.Load(openFileDialog1.FileName);
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
            ConfigFile? config = JsonSerializer.Deserialize<ConfigFile>(str);
            if (config == null)
            {
                MessageBox.Show("Invalid json structure in config.json file");
                return ;
            }
            if (config.TakePicture == null)
            {
                config.TakePicture = new TakePicture(true);
            }
            else
            {
                config.TakePicture.Valid = true;
            }
            File.WriteAllText("config.json", JsonSerializer.Serialize<ConfigFile>(config));
        }

        private void ip_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Ip = IPAddress.Parse(ip_tb.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(Ip);
            if (reply.Status == IPStatus.Success)
            {
                MessageBox.Show("New IP set : " + Ip);
                Status.Text = "Connected";
                Status.BackColor = Color.YellowGreen;
            } 
            else
            {
                MessageBox.Show("Wrong IP set : " + Ip);
                Ip = null;
                Status.Text = "Wrong IP";
                Status.BackColor = Color.Red;
            }
        }
    }
}