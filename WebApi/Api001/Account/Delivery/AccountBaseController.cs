using Api001.Domain.Account;
using Api001.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api001.Account.Delivery
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountBaseController : ControllerBase
    {
        private readonly AccountInterop _accountInterop;
        public AccountBaseController(AccountInterop interop)
        {
            this._accountInterop = interop;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var token = HttpContext.Request.Headers["Authorization"];
            var result = this._accountInterop.GetAll(token);
            return Ok(result);
        }

        [HttpGet("{id}",Name = "GetByAccount")]
        public ActionResult<AccountDTO> GetById(string id)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            var result = this._accountInterop.GetById(token,id);
            if (result.Result != null)
            {
                return result.Result;
            }
            /* return 404 not found */
            return NotFound("Account not found");
        }

        [HttpPost]
        public ActionResult Create([FromBody] AccountDTO account)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            try
            {
                this._accountInterop.Create(token, account);
            }
            catch (AccountExceptions.AccountNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AccountExceptions.AccountExistsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AccountExceptions.AccountInvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtRoute("GetByAccount", new { id = account.Id }, account);
        }

        [HttpPut("{id}")]
        public ActionResult Update(string id, [FromBody] AccountDTO account)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            try
            {
                this._accountInterop.Update(token, account);
            }
            catch (AccountExceptions.AccountNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AccountExceptions.AccountInvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            try
            {
                this._accountInterop.Delete(token, id);
            }
            catch (AccountExceptions.AccountNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }
    }
}
