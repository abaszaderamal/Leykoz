using System.ComponentModel.DataAnnotations;

namespace Leykoz.Core.Entities
{
    public class SiteSetting
    {
         public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

    }
}
