using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microb_uy_mobile.DTOs
{
    public class IntegracionDto
    {
        public int TenantId { get; set; }
        public string Nombre { get; set; }

        private string _perfilImg;
        public string PerfilImg
        {
            get
            {
                // Retorna la imagen predeterminada si _perfilImg no está establecida
                return string.IsNullOrEmpty(_perfilImg) ? "default_foro.jpg" : _perfilImg;
            }
            set
            {
                _perfilImg = value;
            }
        }

        public bool IntegracionUsuarios { get; set; }
        public bool IntegracionPost { get; set; }
        public bool IntegracionBusqueda { get; set; }

        // Constructor vacío
        public IntegracionDto() { }

        // Constructor con parámetros
        public IntegracionDto(int tenantId, string nombre, string perfilImg, bool integracionUsuarios, bool integracionPost, bool integracionBusqueda)
        {
            TenantId = tenantId;
            Nombre = nombre;
            _perfilImg = perfilImg;
            IntegracionUsuarios = integracionUsuarios;
            IntegracionPost = integracionPost;
            IntegracionBusqueda = integracionBusqueda;
        }
    }
}
