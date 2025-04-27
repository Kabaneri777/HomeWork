using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeWork.Data;
using HomeWork.Models;

namespace HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityInfoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IdentityInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 查詢全部資料
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityInfo>>> GetIdentityInfos()
        {
            return await _context.IdentityInfos.ToListAsync();
        }

        /// <summary>
        /// 根據指定id查詢一筆資料
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityInfo>> GetIdentityInfo(int id)
        {
            var identityInfo = await _context.IdentityInfos.FindAsync(id);

            if (identityInfo == null)
            {
                return NotFound();
            }

            return identityInfo;
        }

        /// <summary>
        /// 新增一筆資料
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<IdentityInfo>> PostIdentityInfo(IdentityInfo identityInfo)
        {
            _context.IdentityInfos.Add(identityInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIdentityInfo), new { id = identityInfo.SerialId }, identityInfo);
        }

        /// <summary>
        /// 修改一筆資料
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentityInfo(int id, IdentityInfo identityInfo)
        {
            if (id != identityInfo.SerialId)
            {
                return BadRequest();
            }

            _context.Entry(identityInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentityInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// 刪除一筆資料
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdentityInfo(int id)
        {
            var identityInfo = await _context.IdentityInfos.FindAsync(id);
            if (identityInfo == null)
            {
                return NotFound();
            }

            _context.IdentityInfos.Remove(identityInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IdentityInfoExists(int id)
        {
            return _context.IdentityInfos.Any(e => e.SerialId == id);
        }
    }
}
