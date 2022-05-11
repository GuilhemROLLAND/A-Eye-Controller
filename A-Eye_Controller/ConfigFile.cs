namespace AEye
{
    public class ConfigFile
    {
        public ConfigFile()
        {
        }

        public ConfigFile(Config? config, Weights? weights, TakePicture? takePicture)
        {
            this.Config = config;
            this.Weights = weights;
            this.TakePicture = takePicture;
        }

        public Config? Config { get; set; }
        public Weights? Weights { get; set; }
        public TakePicture? TakePicture { get; set; }
    }

    public class TakePicture
    {
        public string Valid { get; set; }

        public TakePicture(string v)
        {
            Valid = v;
        }

        public TakePicture()
        {
            Valid = false.ToString();
        }
    }

    public class Weights
    {

        public string Valid { get; set; }
        public Weights(string v)
        {
            Valid = v;
        }

        public Weights()
        {
            this.Valid = false.ToString();
        }
    }

    public class Config
    {

        public string StartStop { get; set; }
        public string ModeSelector { get; set; }

        public Config(string @checked, string selectedIndex)
        {
            this.StartStop = @checked;
            this.ModeSelector = selectedIndex;
        }

        public Config()
        {
            this.StartStop = false.ToString();
            this.ModeSelector = false.ToString();
        }
    }
}