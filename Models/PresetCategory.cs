namespace Budget_Tracking_App.Models
{
    public class PresetCategory : Category
    {
        // PresetCategoryのインスタンスを保持する静的リスト
        private static List<PresetCategory> instances = new List<PresetCategory>();

        // PresetCategoryの新しいインスタンスを作成するコンストラクタ
        public PresetCategory()
        {
            // インスタンスをリストに追加
            instances.Add(this);
        }

        // 作成済みのすべてのインスタンスにアクセスするための静的メソッド
        public static List<PresetCategory> GetInstances()
        {
            return instances;
        }
    }
}
