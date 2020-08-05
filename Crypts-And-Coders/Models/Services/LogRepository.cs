using Crypts_And_Coders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Crypts_And_Coders.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.WebApiCompatShim;

namespace Crypts_And_Coders.Models.Services
{
    public class LogRepository : ILog
    {
        private readonly CryptsDbContext _context;

        public LogRepository(CryptsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Return a specific log
        /// </summary>
        /// <param name="id">Unique id of log</param>
        /// <returns>Successful result of log data</returns>
        public async Task<LogData> GetLogData(int id)
        {
            var result = await _context.Logs.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        /// <summary>
        /// Return list of all logs
        /// </summary>
        /// <returns>Successful result of list of log data</returns>
        public async Task<List<LogData>> GetAllLogData()
        {
            var result = await _context.Logs.ToListAsync();
            return result;
        }

        /// <summary>
        /// Create a new log
        /// </summary>
        /// <param name="context">Http context for current action</param>
        /// <returns>Successful result of log data</returns>
        public async Task<LogData> CreateLog(HttpContext context, string userName)
        {
            // Get message from context
            HttpRequestMessageFeature hreqmf = new HttpRequestMessageFeature(context);
            HttpRequestMessage req = hreqmf.HttpRequestMessage;
            LogData log = new LogData()
            {
                RequestMethod = req.Method.Method,
                RequestTimestamp = DateTime.Now,
                RequestUri = req.RequestUri.ToString(),
                RequestContent = await req.Content.ReadAsStringAsync(),
                RequestContentType = req.Content.Headers.ContentType.ToString(),
                UserName = userName
            };
            _context.Entry(log).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return log;
        }
    }
}
