using Identity.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Identity.Domain.Entities
{
    public sealed partial class Feature
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Path { get; private set; } = string.Empty;
        public bool IsAllow { get; private set; }
        public bool IsCreate { get; private set; }
        public bool IsModify { get; private set; }
        public bool IsDelete { get; private set; }
        public bool IsAction { get; private set; }

        public Feature() { }

        public Feature(string name,string path,bool isAllow=false,bool isCreate=false,bool isModify=false,bool isDelete = false,bool isAction = false)
        {
            SetName(name);
            Path = path;
            IsAllow = isAllow;
            IsCreate = isCreate;
            IsModify = isModify;
            IsDelete = isDelete;
            IsAction = isAction;
        }
        private void SetName(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            if (!RegexHelper.IsValidName(name))
                throw new ArgumentException("Name must contain only letters and digits.", nameof(name));

            Name = name;

        }

        


    }
}
