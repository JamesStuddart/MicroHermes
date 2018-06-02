namespace MicroHermes.Core.Models
{
    public class HateoasLink
    {
        public HateoasLink(string hypertextReference, string relationship, string verb)
        {
            Rel = relationship;
            Href = hypertextReference;
            Type = verb;
        }
        
        public string Rel { get; }
        public string Href { get; }
        public string Type { get; }
    }
}