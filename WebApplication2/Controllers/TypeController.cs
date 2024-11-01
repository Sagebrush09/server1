using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : Controller
    {
        private readonly IsrpoContext _context;

        public TypeController(IsrpoContext context) => _context = context;

        [HttpGet]
        [Route("/getAll")]
        public async Task<ActionResult<IEnumerable<Model.Type>>> GetAllType() => await _context.Types.ToListAsync();


        [HttpGet]
        [Route("/getOneType/{id}")]
        public async Task<ActionResult<Model.Type>> GetOneType(int? id)
        {
            if (id < 0 || id == null)
                return Json(new
                {
                    message = "Пожалуйста, укажите идентификатор!"
                });
            return (await _context.Types.FindAsync(id))!;
        }

        [HttpDelete]
        [Route("/deleteOneType/{id}")]
        public async Task<ActionResult<Model.Type>> DeleteOneBook(int id)
        {
            var book = await _context.Types.FindAsync(id);

            if (book == null)
                return Json(new
                {
                    message = "Данной записи нет в Базе Данных!"
                });

            _context.Types.Remove(book);
            await _context.SaveChangesAsync();
            return Json(new
            {
                message = $"Запись с идентификатором {id} успешно удалена!"
            });
        }

        [HttpPost]
        [Route("/postOneType")]
        public async Task<ActionResult<Model.Type>> PostOneType([FromBody] Model.Type type)
        {
            if (type == null)
                return BadRequest("!");
            try
            {
                await _context.Types.AddAsync(type);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    message = "!"
                });
            }
        }

        [HttpPut]
        [Route("/putOneType/{id}")]
        public async Task<ActionResult<Model.Type>> PutOneType(int id, [FromBody] Model.Type type)
        {
            var _type = await _context.Types.FindAsync(id);

            if (_type == null)
                return BadRequest("!");

            try
            {
                _type.NameType = type.NameType;
                _type.Info = type.Info;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    message = "!"
                });
            }
        }
    }
}
