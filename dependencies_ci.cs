//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DependenciesvManagerv2
{
    using System;
    using System.Collections.Generic;
    
    public partial class dependencies_ci
    {
        public int id_dependency { get; set; }
    
        public virtual configuration_items configuration_items { get; set; }
        public virtual configuration_items configuration_items1 { get; set; }
    }
}