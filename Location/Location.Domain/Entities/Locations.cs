using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Location.Domain.Entities
{
    public sealed partial class Locations
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        private readonly List<int> _operators = [];
        public IReadOnlyCollection<int> Operators => _operators.AsReadOnly();

        private Locations() { } // For EF

        public Locations(string name, string description, IEnumerable<int>? operators = null)
        {
            SetName(name);
            SetDescription(description);

            if (operators is not null)
                _operators = operators.Distinct().ToList();
        }

        public void Update(string name, string description)
        {
            SetName(name);
            SetDescription(description);
        }

        public void AddOperator(int operatorId)
        {
            if (operatorId <= 0)
                throw new ArgumentException("OperatorId must be greater than zero.", nameof(operatorId));

            if (!_operators.Contains(operatorId))
                _operators.Add(operatorId);
        }

        public void RemoveOperator(int operatorId)
        {
            _operators.Remove(operatorId);
        }

        private void SetName(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            if (!NameRegex().IsMatch(name))
                throw new ArgumentException("Name must contain only letters and digits.", nameof(name));

            Name = name;
        }

        private void SetDescription(string description)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(description);

            Console.WriteLine($"[{description}] Length: {description.Length}");

            if (!NameRegex().IsMatch(description))
                throw new ArgumentException("Description must contain only letters and digits.", nameof(description));

            Description = description;
        }

        [GeneratedRegex(@"^[\p{L}\p{M}\p{N} ]+$")]
        private static partial Regex NameRegex();
    }
}
