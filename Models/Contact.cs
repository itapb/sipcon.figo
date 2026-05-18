using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace Models
{
    /// <summary>
    /// Representa la información de un cliente, proveedor, planta o concesionario
    /// </summary>
    public class Contact 
    {
        /// <summary>Cedula o Rif del contacto</summary>
        [Required(ErrorMessage = "El Vat es obligatorio")] [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")] [MaxLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string? Vat { get; set; } = string.Empty;

        /// <summary>Razon Social del contacto o primer nombre de persona natural</summary>
        [Required(ErrorMessage = "El FirstName es obligatorio")][MinLength(1, ErrorMessage = "Mínimo 1 caracteres")][MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string? FirstName { get; set; } = string.Empty;

        /// <summary>Segundo nombre del contacto persona natural</summary>
        public string? LastName { get; set; } = string.Empty;

        /// <summary>Direccion Fiscal del contacto</summary>
        [Required(ErrorMessage = "El Address es obligatorio")][MinLength(5, ErrorMessage = "Mínimo 1 caracteres")][MaxLength(250, ErrorMessage = "Máximo 250 caracteres")]
        public string? Address { get; set; } = string.Empty;

        /// <summary>Nombre de la ciudad del contacto</summary>
        [Required(ErrorMessage = "El CityName es obligatorio")][MinLength(1, ErrorMessage = "Mínimo 1 caracteres")][MaxLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string? CityName { get; set; } = string.Empty;

        /// <summary>Numero de Telefono de contacto</summary>
        [Required(ErrorMessage = "El Phone1 es obligatorio")][MinLength(1, ErrorMessage = "Mínimo 1 caracteres")][MaxLength(12, ErrorMessage = "Máximo 12 caracteres")]
        public string? Phone1 { get; set; } = string.Empty;

        /// <summary>Numero de Telefono alterno del contacto</summary>
        [MaxLength(100, ErrorMessage = "Máximo 12 caracteres")]
        public string? Phone2 { get; set; } = string.Empty;

        /// <summary>Correo electronico del contacto</summary>
        [Required(ErrorMessage = "El Email es obligatorio")] [MinLength(1, ErrorMessage = "Mínimo 1 caracteres")] [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Email { get; set; } = string.Empty;

        /// <summary>Fecha de nacimiento del contacto, en caso de aplicar</summary>
        public DateTime? Birthday { get; set; } = DateTime.Now;

        /// <summary>Genero del contacto, en caso de aplicar</summary>
        public bool? Male { get; set; }

        /// <summary>Codigo interno o de referencia del contacto</summary>
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        public string? Reference { get; set; } = string.Empty;

        /// <summary>Rif de la planta asociado al contacto tipo Dealer, en caso de aplicar</summary>
        [Required(ErrorMessage = "El SupplierVat es obligatorio")][MinLength(1, ErrorMessage = "Mínimo 1 caracteres")][MaxLength(12, ErrorMessage = "Máximo 12 caracteres")]
        public string? SupplierVat { get; set; } = string.Empty;

        /// <summary>Indica si el contacto es cliente</summary>
        public bool? IsCustomer { get; set; } = false;

        /// <summary>Indica si el contacto es Concesionario</summary>
        public bool? IsDealer { get; set; } = false;

        /// <summary>Indica si el contacto es Proveedor</summary>
        public bool? IsProvider { get; set; } = false;



    }
}
