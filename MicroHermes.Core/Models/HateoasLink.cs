namespace MicroHermes.Core.Models
{
    public class HateoasLink
    {
        public HateoasLink(string relationship, string hypertextReference, string verb)
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