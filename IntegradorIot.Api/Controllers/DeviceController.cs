using Azure;
using IntegradorIoc.Application.Interfaces;
using IntegratorIot.Domain.DTOs;
using IntegratorIot.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace IntegradorIot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class DeviceController : Controller
    {
        private readonly IDeviceService service;

        public DeviceController(IDeviceService service)
        {
            this.service = service;
        }

        [HttpPost]
        [ProducesResponseType<DeviceDto>(StatusCodes.Status201Created)]
        public async Task<ActionResult> Save(DeviceDto deviceDto)
        {
            try
            {
                deviceDto.Url = Request.Path;
                var deviceIncluido = await service.Save(deviceDto);
                return Ok(deviceIncluido.Url);
            }
            catch (Exception ex)
            {

                return BadRequest($"Ocorreu um erro ao salvar o novo dispositivo : {ex.Message}");
            }
            

        }

        [HttpPut]
        [ProducesResponseType<DeviceDto>(StatusCodes.Status200OK)]
        [ProducesResponseType<DeviceDto>(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType<DeviceDto>(StatusCodes.Status404NotFound)]        
        public async Task<ActionResult> UpDate(DeviceDto deviceDto)
        {
            var deviceIncluido = await service.UpDate(deviceDto);
            if (deviceIncluido == null)
                return BadRequest("Ocorreu um erro ao Atualizar o dispositivo");
            return Ok("Requisição realizada com sucesso");

        }

        [HttpDelete]
        [ProducesResponseType<DeviceDto>(StatusCodes.Status200OK)]
        [ProducesResponseType<DeviceDto>(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType<DeviceDto>(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(DeviceDto deviceDto)
        {
            var deviceIncluido = await service.Delete(deviceDto);
            if (deviceIncluido == null)
                return BadRequest("Ocorreu um erro ao Atualizar o dispositivo");
            return Ok("Requisição realizada com sucesso");

        }
        [ProducesResponseType<DeviceDto>(StatusCodes.Status200OK)]
        [ProducesResponseType<DeviceDto>(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var deviceDto = await service.GetAsync(id);
            if (deviceDto == null)
                return NotFound("Dispositivo não encontrado");
            return Ok(deviceDto);
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<DeviceListDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType<DeviceDto>(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var devices = await service.GetAllAsync();
                return Ok(devices);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro ao buscar os Dispositivos :{ex.Message}");
            }
            
                

            
        }

    }
}
