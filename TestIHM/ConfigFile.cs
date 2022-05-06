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
            Weights = weights;
            TakePicture = takePicture;
        }

        public Config? Config {get;set;}
        public Weights? Weights { get; set; }
        public TakePicture? TakePicture { get; set; }
    }

    public class TakePicture
    {
        public bool Valid { get; set;}

        public TakePicture(bool v)
        {
            Valid = v;
        }

    }

    public class Weights
    {
        public Weights(bool v)
        {
            Valid=v;
        }

        public bool Valid { get; set; }
    }

    public class Config
    {
        public bool StartStop { get; set; }
        public int ModeSelector { get; set; }

        public Config(bool @checked, int selectedIndex)
        {
            this.StartStop = @checked;
            this.ModeSelector = selectedIndex;
        }

    }
}