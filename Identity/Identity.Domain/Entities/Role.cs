using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Identity.Domain.Entities
{
    public sealed partial class Role
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public List<Feature> Features { get; private set; } = new List<Feature>();
        public int LocationId { get; private set; }
        public Role() { }
        public Role(string name,List<Feature> features,int location)
        {
            SetName(name);
            SetFeatures(features);
            SetLocation(location);
        }

        private void SetName(string name)
        {

            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            if (!NameRegex().IsMatch(name))
                throw new ArgumentException("Name must contain only letters and digits.", nameof(name));

            Name = name;
        }

        private void SetFeatures(List<Feature> features) 
        {
            if(features.Count == 0)
                throw new ArgumentException("Features must contain at least one feature.",nameof(features));

            Features = features;
        }

        private void SetLocation(int id)
        {
            if (id <= 0) 
                throw new ArgumentException("Location must greater than 0.",nameof(id));

            LocationId = id; 
        }

        [GeneratedRegex(@"^[\p{L}\p{M}\p{N} ]+$")]
        private static partial Regex NameRegex();


    }
}
