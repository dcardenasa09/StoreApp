using System.Text.Json;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Common.Validator;
using Store.Business.Common.Services;
using Store.Entities.Common.Interfaces;

namespace Store.Api.Common.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController<TEntity, TDTO, TService> : ControllerBase where TEntity : IEntity where TDTO : IDTO where TService : IBaseService<TEntity, TDTO> {

    private readonly TService _service;
    private readonly IValidatorHelper<TDTO> _validator;

    public BaseController(TService service, IValidatorHelper<TDTO> validator) {
        _service   = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] string[]? includes = null) {
        Expression<Func<TEntity, bool>> expression = t => t.IsActive;
        var entities = await _service.GetList(expression, includes);
        if (entities == null) {
            return NotFound();
        }

        return Ok(entities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TDTO>> Get(int id, [FromQuery] string[]? includes = null) {
        var entity = await _service.GetById(id, includes);
        if (entity == null) {
            return NotFound();
        }

        return Ok(entity);
    }

    [HttpPost]
    public virtual async Task<ActionResult<TDTO>> Create(TDTO entity) {
        await _validator.Validate(entity);
        var entityResult = await _service.Create(entity);
        return CreatedAtAction(null, entityResult);
    }


    [HttpPut]
    public async Task<IActionResult> Put(TDTO entity) {
        await _validator.Validate(entity);
        var result = await _service.Update(entity);
        return Ok(result);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(int id) {
        await _service.Delete(id);
        return Ok();
    }
}