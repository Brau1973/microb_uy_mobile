using microb_uy_mobile.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace microb_uy_mobile.Helpers;

public class IntegracionMapper
{
    public static List<IntegracionDto> MapToIntegracionDtoList(List<IntegracionWSDto> wsDtos)
    {
        var integracionDtos = new List<IntegracionDto>();

        foreach (var wsDto in wsDtos)
        {
            // Buscar si ya existe un IntegracionDto con el mismo IdTenant y Nombre
            var existingDto = integracionDtos.FirstOrDefault(i => i.TenantId == wsDto.IdTenant && i.Nombre == wsDto.NombreTenat);

            if (existingDto != null)
            {
                // Actualizar los valores booleanos del objeto existente
                UpdateBooleanValues(existingDto, wsDto.TipoAsociacion);
            }
            else
            {
                // Crear un nuevo IntegracionDto y agregarlo a la lista
                var newDto = new IntegracionDto
                {
                    TenantId = wsDto.IdTenant,
                    Nombre = wsDto.NombreTenat,
                    PerfilImg = "default_image.png"
                };
                UpdateBooleanValues(newDto, wsDto.TipoAsociacion);
                integracionDtos.Add(newDto);
            }
        }

        return integracionDtos;
    }

    private static void UpdateBooleanValues(IntegracionDto dto, string tipoAsociacion)
    {
        switch (tipoAsociacion)
        {
            case "Usuarios":
                dto.IntegracionUsuarios = true;
                break;
            case "Post":
                dto.IntegracionPost = true;
                break;
            case "Busqueda":
                dto.IntegracionBusqueda = true;
                break;
        }
    }
}
