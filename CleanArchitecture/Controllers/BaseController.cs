using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, T1> : ControllerBase where T : class where T1 : class
    {
        private readonly IBaseManager<T, T1> _baseManager;

        public BaseController(IBaseManager<T, T1> baseManager)
        {
            _baseManager = baseManager;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public virtual async Task<IActionResult> Get()
        {
            var result = await _baseManager.Get().ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public virtual async Task<IActionResult> Get(int id)
        {
            var result = await _baseManager.GetbyId(id).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public virtual async Task<IActionResult> Add(T entity)
        {
            var result = await _baseManager.Add(entity).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public virtual async Task<IActionResult> Update(int id, T entity)
        {
            await _baseManager.Update(id, entity).ConfigureAwait(false);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await _baseManager.Delete(id).ConfigureAwait(false);
            return Ok();
        }
    }
}