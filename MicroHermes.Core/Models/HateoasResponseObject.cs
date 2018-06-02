using System.Collections.Generic;
using System.Linq;

namespace MicroHermes.Core.Models
{
    public class HateoasResponseObject<T> where T : class, new()
    {
        public readonly T Content;
        public IList<HateoasLink> Links { get; }
        
        public HateoasResponseObject(T content, IList<HateoasLink> links = null)
        {
            Content = content;
            Links = links ?? new List<HateoasLink>();
        }

        public void AddLink(string hypertextReference, string relationship, string verb)
        {
            if (!Links.Any(x => x.Href == hypertextReference && x.Rel == relationship && x.Type == verb))
            {
                Links.Add(new HateoasLink(hypertextReference, relationship, verb));   
            }
        }

        public void AddLink(HateoasLink link)
        {
            if (!Links.Contains(link))
            {
                Links.Add(link);   
            }
        }
        
        public void AddLinks(IEnumerable<HateoasLink> links)
        {
            foreach (var link in links)
            {
                Links.Add(link);
            }
        }
    }
}