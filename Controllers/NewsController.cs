#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rapid_news_media_news_api.Models;

namespace rapid_news_media_news_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsDBContext _context;

        public NewsController(NewsDBContext context)
        {
            _context = context;
        }

        // GET: api/News
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsReport>>> GetNewsReport()
        {
            return await _context.NewsReports.ToListAsync();
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsReport>> GetNewsReport(long id)
        {
            var newsReport = await _context.NewsReports.FindAsync(id);

            if (newsReport == null)
            {
                return NotFound();
            }

            return newsReport;
        }

        // PUT: api/News/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsReport(long id, NewsReport newsReport)
        {
            if (id != newsReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(newsReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsReportExists(id))
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

        // POST: api/News
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NewsReport>> PostNewsReport(NewsReport newsReport)
        {
            _context.NewsReports.Add(newsReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsReport", new { id = newsReport.Id }, newsReport);
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewsReport(long id)
        {
            var newsReport = await _context.NewsReports.FindAsync(id);
            if (newsReport == null)
            {
                return NotFound();
            }

            _context.NewsReports.Remove(newsReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewsReportExists(long id)
        {
            return _context.NewsReports.Any(e => e.Id == id);
        }
    }
}
