using System;

namespace Device.Domain.Entities;

public class BaseDomain
{
      public int LocationId { get; private set; } 
      public bool IsActive {get; private set;}

      public BaseDomain(int location,bool isactive)
      {
            SetLocationId(location);
            this.IsActive = isactive;
      }

      private void SetLocationId(int locationid)
        {
            if(locationid <= 0) throw new ArgumentOutOfRangeException("Location Id must greater than 0", nameof(locationid));

            LocationId = locationid;
        }
}
