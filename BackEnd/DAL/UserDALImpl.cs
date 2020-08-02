using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class UserDALImpl : IUserDAL
    {

        private BDContext context;
        public bool eliminar(string idRole, int idUsuario)
        {
            throw new NotImplementedException();
        }

        public string[] gerRolesForUser(string userName)
        {
            string[] result;
            using (context = new BDContext())
            {
                result = context.sp_getRolesForUser(userName).ToArray();
            }


            return result;
        }

        public Users get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Users> getAll()
        {
            throw new NotImplementedException();
        }

        public Users getUser(string userName)
        {
            try
            {
                Users resultado;
                using (UnidadDeTrabajo<Users> unidad = new UnidadDeTrabajo<Users>(new BDContext()))
                {
                    Expression<Func<Users, bool>> consulta = (u => u.UserName.Equals(userName));
                    resultado = unidad.genericDAL.Find(consulta).ToList().FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Users getUser(string userName, string password)
        {
            try
            {
                Users resultado;
                using (UnidadDeTrabajo<Users> unidad = new UnidadDeTrabajo<Users>(new BDContext()))
                {
                    Expression<Func<Users, bool>> consulta = (u => u.UserName.Equals(userName) && u.Password.Equals(password));
                    resultado = unidad.genericDAL.Find(consulta).ToList().FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Users getUser(int EmpleadoId)
        {
            throw new NotImplementedException();
        }

        public List<Users> getUsuariosRole(string roleName)
        {
            List<Users> result = new List<Users>();
            List<string> lista;
            using (context = new BDContext())
            {
                lista = context.sp_getUsuariosRole(roleName).ToList();
                Users user;
                foreach (var item in lista)
                {
                    user = this.getUser(item);
                    result.Add(user);
                }

            }


            return result;
        }

        public bool insertar(int idRole, string login)
        {
            throw new NotImplementedException();
        }

        public bool insertar(string roleName, string login)
        {
            throw new NotImplementedException();
        }

        public bool isUserInRole(string userName, string roleName)
        {
            bool result = false;


            using (context = new BDContext())
            {
                result = (bool)context.sp_isUserInRole(userName, roleName).First();
                //  result  = (bool)context.sp_isUserInRole(userName, roleName).FirstOrDefault();

            }

            return result;
        }

        public List<Roles> listarRoles()
        {
            throw new NotImplementedException();
        }

        public Users ObtenerPorID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
