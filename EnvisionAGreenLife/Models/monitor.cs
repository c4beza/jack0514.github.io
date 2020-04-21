//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnvisionAGreenLife.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class monitor
    {
        public int Monitor_Id { get; set; }
        public Nullable<int> Record_ID { get; set; }
        public string Status { get; set; }
        public string Brand_Name { get; set; }
        public string Model_Number { get; set; }
        public string Family_Name { get; set; }
        public string Selling_Countries { get; set; }
        public string Manufacturing_Countries { get; set; }
        public Nullable<decimal> Screen_Size { get; set; }
        public string Screen_Technology { get; set; }
        public Nullable<decimal> Comparative_Energy_Consumption { get; set; }
        public Nullable<decimal> Active_Standby_Power { get; set; }
        public Nullable<decimal> Star_Rating_Index { get; set; }
        public Nullable<decimal> Star_Rating { get; set; }
        public string Product_Website { get; set; }
        public string Representative_Brand_URL { get; set; }
        public string Availability_Status { get; set; }
        public Nullable<System.DateTime> Expiry_Date { get; set; }
        public string Star_Image_Large { get; set; }
        public string Star_Image_Small { get; set; }
        public Nullable<int> Type_Id { get; set; }
    
        public virtual appliance_types appliance_types { get; set; }
    }
}