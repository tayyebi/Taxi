namespace Taxi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblServiceCar
    {
        public int ID { get; set; }

        public int ServiceID { get; set; }

        public int CarID { get; set; }

        public int RouteID { get; set; }

        public bool Payed { get; set; }

        public virtual tblCar tblCar { get; set; }

        public virtual tblRoute tblRoute { get; set; }

        public virtual tblService tblService { get; set; }
    }
}
