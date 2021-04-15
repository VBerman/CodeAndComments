//public class AnalyseClass : ObservableObject{}
//public class analyseClass : ObservableObject
//{}
//public class observableObject : INotifyPropertyChanged{}
//public class ObservableObject : INotifyPropertyChanged
//{}
//public class obs : Page { }
//public class Osad : Ps
//{ }

//namespace Travel1.Model
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("Country")]
//    public partial class Country
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public Country()
//        {
//            Hotels = new HashSet<Hotel>();
//        }

//        [Key]
//        [StringLength(2)]
//        public string Code { get; set; }

//        [Required]
//        [StringLength(100)]
//        public string Name { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Hotel> Hotels { get; set; }
//    }
//}


//namespace Travel1.Model
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("Country")]
//    public partial class country : DSA
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public Country()
//        {
//            Hotels = new HashSet<Hotel>();
//        }

//        [Key]
//        [StringLength(2)]
//        public string Code { get; set; }

//        [Required]
//        [StringLength(100)]
//        public string Name { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Hotel> Hotels { get; set; }
//    }
//}