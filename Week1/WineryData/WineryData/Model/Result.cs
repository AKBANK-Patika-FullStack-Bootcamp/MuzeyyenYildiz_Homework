namespace WineryData.Model
{
    public class Result
    {
        public int status { get; set; }
        public string? Message { get; set; }
        public List<Wine>? Winelist { get; set; }
    }
}
