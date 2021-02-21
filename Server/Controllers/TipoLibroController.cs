using appBlazorIntro.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appBlazorIntro.Server.Controllers
{
    [ApiController]
    public class TipoLibroController : Controller
    {
        
        [HttpGet]
        [Route("api/TipoLibro/Get")]
        public List<TipoLibro> Get()
        {
            List<TipoLibro> lista = new List<TipoLibro>();
            using (BDBibliotecaContext db = new BDBibliotecaContext())
            {
                lista = (from tipoLibro in db.TipoLibro
                         where tipoLibro.Bhabilitado == 1
                         select new TipoLibro
                         {
                             Iidtipolibro = tipoLibro.Iidtipolibro,
                             Nombretipolibro = tipoLibro.Nombretipolibro,
                             Descripcion = tipoLibro.Descripcion
                         }).ToList();
            }
            return lista;

        }



        [HttpGet]
        [Route("api/TipoLibro/Filtrar/{data?}")]
        public List<TipoLibro> Filtrar(string data)
        {
            List<TipoLibro> lista = new List<TipoLibro>();
            using (BDBibliotecaContext db = new BDBibliotecaContext())
            {
                if (data == null)
                {
                    lista = (from tipoLibro in db.TipoLibro
                             where tipoLibro.Bhabilitado == 1
                             select new TipoLibro
                             {
                                 Iidtipolibro = tipoLibro.Iidtipolibro,
                                 Nombretipolibro = tipoLibro.Nombretipolibro,
                                 Descripcion = tipoLibro.Descripcion
                             }).ToList();
                }

                else
                {

                    
                            lista = (from tipoLibro in db.TipoLibro
                                     where tipoLibro.Bhabilitado == 1
                                     && tipoLibro.Nombretipolibro.Contains(data)
                                     select new TipoLibro
                                     {
                                         Iidtipolibro = tipoLibro.Iidtipolibro,
                                         Nombretipolibro = tipoLibro.Nombretipolibro,
                                         Descripcion = tipoLibro.Descripcion
                                     }).ToList();
                       

                }
            }
            return lista;

        }


    }
    
}
