namespace Taxi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblCar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCar()
        {
            tblServiceCars = new HashSet<tblServiceCar>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string CarName { get; set; }

        [StringLength(50)]
        public string IdentityNumber { get; set; }

        [StringLength(50)]
        public string CarColor { get; set; }

        public int? DriverID { get; set; }

        public virtual tblUser tblUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblServiceCar> tblServiceCars { get; set; }
    }
}
