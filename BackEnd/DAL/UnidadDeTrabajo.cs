﻿using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
   public class UnidadDeTrabajo<T> : IDisposable where T : class
    {

        private readonly BDContext context;
       
        public IGenericoDAL<T> genericDAL;


        public UnidadDeTrabajo(BDContext _context)
        {
            context = _context;
            genericDAL = new GenericoDALImpl<T>(context);
            
        }

        public bool Complete()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }

        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
