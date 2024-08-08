using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaAxen_CasaBolsa.Models.Enums;
using PruebaYachtme.Models;
using PruebaYachtme.Models.DTO;
using PruebaYachtme.Models.Generics;
using PruebaYachtme.Repository.IRepository;
using System.Net;

namespace PruebaYachtme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _itemsRepository;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public ItemsController(IItemsRepository itemsRepository, IMapper mapper)
        {
            _itemsRepository = itemsRepository;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {

                var list = await _itemsRepository.GetAll(i => i.Status != (short)StatusEnum.Completado);

                _response.Result = list;
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("AddItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> AddItem([FromBody] ItemAddDTO itemAdd)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (itemAdd == null)
                {
                    return BadRequest(itemAdd);
                }

                var modelo = _mapper.Map<Items>(itemAdd);

                await _itemsRepository.Create(modelo);
                _response.StatusCode = HttpStatusCode.Created;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("Done")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Done([FromBody] int Id)
        {
            var modelo = await _itemsRepository.Get(v => v.Id == Id, false);
            if (Id < 1 || modelo == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            modelo.Status = (short)StatusEnum.Completado;
            await _itemsRepository.Update(modelo);
            _response.StatusCode = HttpStatusCode.NoContent;

            return Ok(_response);
        }

    }
}
