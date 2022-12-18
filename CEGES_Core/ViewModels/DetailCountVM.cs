namespace CEGES_Core.ViewModels
{
    public class DetailCountVM : DetailInfoVM
    {
        public DetailCountVM(string caption, int count, string pluriel, string aucun) : base(caption + (count > 1 ? pluriel : ""), count == 0 ? aucun : count.ToString())
        {

        }
    }
}
