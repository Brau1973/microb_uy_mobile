using System;
using System.Collections.Generic;

namespace microb_uy_mobile.DTOs
{
    public class HashTagDto
    {
        public string NombreHT { get; set; }
        public int TenantId { get; set; }
        public int Cantidad { get; set; }

        // Constructor por defecto
        public HashTagDto()
        {
            // Puedes inicializar propiedades predeterminadas aquí si es necesario.
        }

        // Constructor con parámetros para facilitar la creación de instancias
        public HashTagDto(string nombreHT, int tenantId, int cantidad)
        {
            NombreHT = nombreHT;
            TenantId = tenantId;
            Cantidad = cantidad;
        }
    }
}
