using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Device.Infrastructure.Persistance.Entities
{
    public sealed class Devices : BaseEntity
    {
        public string name { get; set; } = string.Empty;
        public int type { get; set; }
        public string type_detail { get; set; } = string.Empty;
        public string ip {get; set;} = string.Empty;
        public string mac {get; set;} = string.Empty;
        public string serial_number {get; set;} = string.Empty;
        public string metadata { get; set;  } = string.Empty;
        public DateTime last_sync { get; set; } = DateTime.UtcNow;

        public Devices(Device.Domain.Entities.Devices data) : base(data.LocationId,data.IsActive)
        {
            this.name = data.Name;
            this.type = (int)data.Type;
            this.type_detail = data.TypeDetail;
            this.ip = data.Ip;
            this.mac = data.Mac;
            this.serial_number = data.SerialNumber;
            this.metadata = data.Metadata;
            this.last_sync = data.LastSync;
        }
    }
}
