namespace Taxi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblMessage
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Message { get; set; }

        [StringLength(50)]
        public string Sender { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]
        public string Time { get; set; }

        public int? ServiceID { get; set; }

        public int? FeedBackRate { get; set; }

        public virtual tblService tblService { get; set; }
    }
}
