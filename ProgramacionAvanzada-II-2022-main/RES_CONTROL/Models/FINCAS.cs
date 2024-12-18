//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RES_CONTROL.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class FINCAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FINCAS()
        {
            this.POTREROS = new HashSet<POTREROS>();
        }

        // [DisplayFormat(ApplyFormatInEditMode = true)] permite aplicar las validaciones definidas en las anotaciones en los campos de edici�n y creaci�n

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Identificador de finca en el sistema")]
        public int ID_FINCA { get; set; }

        [DisplayName("Nombre de la finca")]
        public string NOMBRE_FINCA { get; set; }

        [DisplayName("Ubicaci�n de la finca")]
        public string LOCACION_FINCA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POTREROS> POTREROS { get; set; }
    }
}
