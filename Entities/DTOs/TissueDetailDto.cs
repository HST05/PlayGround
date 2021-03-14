using Core;

namespace Entities
{
    public class TissueDetailDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Gender { get; set; }
        public string Sort { get; set; }
        public string Origin { get; set; }
    }
}