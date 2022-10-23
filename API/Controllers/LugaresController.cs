using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.Datos;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("[controller]")]
    public class LugaresController : Controller
    {
        private readonly ApplicationDbContext _Db;

        public LugaresController(ApplicationDbContext db)
        {
            _Db = db;

        }



        [HttpGet]
        public async Task< ActionResult<List<Lugar>>> GetLugares()
        {
           var lugares =await _Db.Lugar.ToListAsync();
           return Ok( lugares);
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<Lugar> > GetLugar (int id)
        {
            return await _Db.Lugar.FindAsync(id);
        }
    }
}