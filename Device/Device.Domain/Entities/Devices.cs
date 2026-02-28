using Device.Domain.Enums;
using Device.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Domain.Entities
{
    public sealed class Devices : BaseDomain
    {
        
        public string Name { get; private set; } = string.Empty;
        public DeviceType Type { get; private set; }
        public string TypeDetail { get; private set; } = string.Empty;
        public string Ip {get; private set;} = string.Empty;
        public string Mac {get; private set;} = string.Empty;
        public string SerialNumber {get; private set;} = string.Empty;
        public string Metadata { get; private set; } = string.Empty;
        public DateTime LastSync { get; private set; } = DateTime.UtcNow;


        public Devices(string name,int type,string ip,string mac,string serial,string metadata,int locationid,DateTime lastsync,bool isactive) : base(locationid,isactive)
        {
            SetName(name);
            SetType(type);
            SetMetadata(metadata);
            SetDeviceType(type);
            SetIp(ip);
            SetMac(mac);
            SetSerial(serial);
            //SetLastSync(lastsync);
            LastSync = lastsync;
        }



        private void SetName(string name) 
        {
            if (!RegexHelper.IsValidName(name)) throw new ArgumentException("Name must containt only character and digit",nameof(name));
            Name = name;
        }

        private void SetType(int type)
        {
            if (!Enum.IsDefined(typeof(DeviceType), type)) throw new ArgumentException("Device type incorrect.");

            Type = (DeviceType)type;
            TypeDetail = ((DeviceType)type).ToString();
            
        }

        private void SetMetadata(string metadata)
        {
            if(string.IsNullOrWhiteSpace(metadata)) throw new ArgumentException("Metadata must not be empty");

            Metadata = metadata;
        }

        

        private void SetDeviceType(int type)
        {
            switch (type)
            {
                case (int)DeviceType.Aero:
                this.Type = DeviceType.Aero;
                this.TypeDetail = DeviceType.Aero.ToString();
                break;
                case (int)DeviceType.Amico:
                this.Type = DeviceType.Amico;
                this.TypeDetail = DeviceType.Amico.ToString();
                break;
                default:
                break;
            }
        }

        private void SetIp(string ip)
        {
            if(string.IsNullOrWhiteSpace(ip)) throw new ArgumentException("Ip invalid.");
            this.Ip = ip;
        }

        private void SetMac(string mac)
        {
            if(string.IsNullOrWhiteSpace(mac)) throw new ArgumentException("Mac invalid.");
            this.Mac = mac;
        }

        private void SetSerial(string serial)
        {
            if(string.IsNullOrWhiteSpace(serial)) throw new ArgumentException("SerialNumber invalid.");
            this.SerialNumber = serial;
        }


    }
}

