using System.Web.Script.Serialization;

namespace StockTool
{
    public class Config
    {
        public string StockCode { get; set; }

        public int UpdateInterval { get; set; }

        public int? DiffSeconds { get; set; }

        public float? Diff { get; set; }

        public string DiffType { get; set; }

        public bool AlertEnabled { get; set; }

        public string ToJson()
        {
            var js = new JavaScriptSerializer();
            return js.Serialize(this);
        }

        public static Config FromJson(string json)
        {
            var js = new JavaScriptSerializer();
            return js.Deserialize<Config>(json);
        }
    }
}
