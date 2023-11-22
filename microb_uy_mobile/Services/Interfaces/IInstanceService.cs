﻿using microb_uy_mobile.DTOs;
using microb_uy_mobile.DTOs.Base;
using Refit;

internal interface IInstanceService
{
    [Get("/api/tenants")]
    Task <BaseApiResponseDTO<InstanceDTO>> GetInstancesAsync();
}