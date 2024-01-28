namespace WebApp.Models
{
    public class Label
    {
        public string Number { get; set; }
        public string Project { get; set; }
        public string Department { get; set; }
        public bool Check1 { get; set; }
        public bool Check2 { get; set; }
        public bool Check3 { get; set; }
        public bool Check4 { get; set; }
        public bool Check5 { get; set; }

        public override string ToString()
        {
            return $"{Number},{Project},{(Check1?"1":"0")},{(Check2 ? "1" : "0")},{(Check3 ? "1" : "0")},{(Check4 ? "1" : "0")},{(Check5 ? "1" : "0")}";
        }
    }
}
