namespace CEGES_Core.ViewModels
{
    public class DetailInfoVM
    {
        public string Caption { get; set; }
        public string Value { get; set; }
        public DetailInfoVM(string caption, string value)
        {
            Caption = caption;
            Value = value;
        }
    }
}
