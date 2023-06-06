using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Bll.Models.DishDTOs;
using Restaurant.Bll.Services.Interfaces;
using Restaurant.Dal.Entities;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;
        private readonly IMapper _mapper;
        private const string folderName = "Menu";

        public DishController(IDishService dishService, IMapper mapper)
        {
            this._dishService = dishService ?? throw new ArgumentNullException(nameof(dishService));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet("api/dishes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDishList(bool dividedByType = false)
        {
            if (dividedByType)
            {
                var dishesDictionary = await _dishService.GetDictionaryDishesAsync();
                
                return Ok(_mapper.Map<Dictionary<string, IEnumerable<DishForListDTO>>>(dishesDictionary));
            }
            var dishes = await _dishService.GetDishesAsync();
            return Ok(_mapper.Map<IEnumerable<DishForListDTO>>(dishes));
        }

        [HttpGet("api/dishes/{PositionId}", Name = "GetDish")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DishDetailInfoDTO>> GetDish(Guid PositionId)
        {
            var dish = await _dishService.GetDishAsync(PositionId);
            if (dish == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DishDetailInfoDTO>(dish));
        }

        [HttpDelete("api/dishes")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAllDishes()
        {
            await _dishService.DeleteAllDishes();
            await _dishService.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("api/dishes/{positionId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDish(Guid positionId)
        {
            var dishToDelete = await _dishService.GetDishAsync(positionId);
            if (dishToDelete == null)
            {
                return NotFound();
            }
            _dishService.DeleteDish(dishToDelete);
            await _dishService.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("api/dishes/{positionId}")]
        public async Task<IActionResult> PartiallyUpdateDish(Guid positionId, JsonPatchDocument<DishForUpdateDTO> patchDocument)
        {

            var dishForUpdate = await _dishService.GetDishAsync(positionId);

            if (dishForUpdate == null)
            {
                return NotFound();
            }

            var dishToPatch = _mapper.Map<DishForUpdateDTO>(dishForUpdate);

            patchDocument.ApplyTo(dishToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(dishToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(dishToPatch, dishForUpdate);

            await _dishService.SaveChangesAsync();

            return NoContent();
        }
    }
}
