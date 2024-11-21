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

    public partial class VACUNAS
    {
        // [DisplayFormat(ApplyFormatInEditMode = true)] permite aplicar las validaciones definidas en las anotaciones en los campos de edici�n y creaci�n

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Identificador de vacuna en el sistema")]
        public int ID_VACUNA { get; set; }

        [DisplayName("Nombre de la vacuna")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public string NOMBRE_VACUNA { get; set; }

        [DisplayName("Descripci�n de la vacuna")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public string DESCRIPCION_VACUNA { get; set; }

        [DisplayName("Fecha de aplicaci�n")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA { get; set; }

        [DisplayName("Dosis")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public Nullable<int> DOSIS { get; set; }

        [DisplayName("Dosis recomendada")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public Nullable<int> DOSIS_RECOMENDADA { get; set; }

        [DisplayName("Res en que se aplic�")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public int ID_RES { get; set; }

        [DisplayName("Colaborador responsable")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public int ID_COLABORADOR { get; set; }

        public virtual COLABORADORES COLABORADORES { get; set; }
        public virtual RESES RESES { get; set; }
    }
}
