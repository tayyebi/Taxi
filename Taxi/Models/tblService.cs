namespace Taxi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblService()
        {
            tblMessages = new HashSet<tblMessage>();
            tblServiceCars = new HashSet<tblServiceCar>();
        }

        public int ID { get; set; }

        public int? CustomerID { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "خودتی")]
        public string FullName { get; set; }

        [StringLength(50)]
        public string Tellnumber { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]
        public string Time { get; set; }

        public int? OperatorID { get; set; }

        public virtual tblCustomer tblCustomer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMessage> tblMessages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblServiceCar> tblServiceCars { get; set; }

        public virtual tblUser tblUser { get; set; }
    }
}
