namespace Budget_Tracking_App.Models
{
    public class PresetCategory : Category
    {
        private static List<PresetCategory> instances = new List<PresetCategory>();

        public PresetCategory()
        {
            instances.Add(this);
        }

        public static List<PresetCategory> GetInstances()
        {
            return instances;
        }
    }
}
