namespace CustomWindow
{
    public class LinkData
    {
        public LinkData(string description, string address)
        {
            Description = description;
            Address = address;
        }
        public string Description { get; set; }
        public string Address { get; set; }
    }
}