//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusSystem.Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class RouteInfo
    {
        public RouteInfo()
        {
            this.BusSchedules = new HashSet<BusSchedule>();
        }
    
        public int RouteId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string ViaRoute { get; set; }
        public double Distance { get; set; }
    
        public virtual ICollection<BusSchedule> BusSchedules { get; set; }
    }
}
