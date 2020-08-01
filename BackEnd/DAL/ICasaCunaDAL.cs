using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BackEnd.DAL
{
    public interface ICasaCunaDAL
    {
        List<sp_ReporteCasaCuna_Result> datosReporte(int ProvinciaId);

        List<SelectListItem> getProvincias();
    }
}
