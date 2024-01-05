using DL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {

        public static bool Add(ML.Usuario usuario)
        {
            //usuario.Rol = new ML.Rol();
            bool result = false;
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new JGarciaTrakingAndTraceEntities())
                {
                    usuario.Password = EcriptaString(usuario.Contra);

                    int rowAffected = context.UsuarioAdd(
                        usuario.UserName,
                        usuario.Password,
                        usuario.Rol.IdRol,
                        usuario.Email,
                        usuario.Nombre,
                        usuario.ApellidoMaterno,
                        usuario.ApellidoMaterno);

                    if (rowAffected > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool Update(ML.Usuario usuario)
        {
            //usuario.Rol = new ML.Rol();
            bool result = false;
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new JGarciaTrakingAndTraceEntities())
                {
                    usuario.Password = EcriptaString(usuario.Contra);
                    int rowAffected = context.UpdateUsuario(
                        usuario.IdUsuario,
                        usuario.UserName,
                        usuario.Password,
                        usuario.Rol.IdRol,
                        usuario.Email,
                        usuario.Nombre,
                        usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno);
                    if(rowAffected > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool Delete(int IdUsuario)
        {
            bool result = false;
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new JGarciaTrakingAndTraceEntities())
                {
                    int rowAffected = context.DeleteUsuario(IdUsuario);

                    if(rowAffected > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static List<object> GetAll()
        {
            var result = new List<object>();
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new JGarciaTrakingAndTraceEntities())
                {
                    var query = context.GetAllUsuario().ToList();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.Rol = new ML.Rol();

                            usuario.IdUsuario = registro.IdUsuario;
                            usuario.UserName = registro.UserName;
                            usuario.Password = registro.Password;
                            usuario.Rol.IdRol = registro.IdRol;
                            usuario.Rol.Tipo = registro.Tipo;
                            usuario.Nombre = registro.Nombre;
                            usuario.ApellidoPaterno = registro.ApellidoPaterno;
                            usuario.ApellidoMaterno = registro.ApellidoMaterno;

                            result.Add(usuario);
                        }
                    }
                }
            }
            catch
            {
                result = null;
            }
            return result;
        }

        public static ML.Usuario GetById(int idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new JGarciaTrakingAndTraceEntities())
                {
                    var query = context.GetByIdUsuario(idUsuario).SingleOrDefault();

                    if (query != null)
                    {
                        usuario.UserName = query.UserName;
                        usuario.Password = query.Password;
                        usuario.Rol.IdRol = query.IdRol;
                        usuario.Email = query.Email;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno= query.ApellidoPaterno;
                        usuario.ApellidoMaterno= query.ApellidoMaterno;
                        usuario.Contra = Encoding.UTF8.GetString(usuario.Password);
                    }

                }
            }
            catch{

            }
            return usuario;
        }

        public static byte[] Encriptar(byte[] pass)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] emcriptada = sha256.ComputeHash(pass);
                return emcriptada;
            }
        }

        public static byte[] EcriptaString(string contra)
        {
            byte[] array = Encoding.UTF8.GetBytes(contra);
            return array;
        }

        public static ML.Usuario GetByEmail(string email)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new DL.JGarciaTrakingAndTraceEntities())
                {
                    var query = context.GetByEmailUsuario(email).SingleOrDefault();
                    if (query != null)
                        {
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Rol.IdRol = query.IdRol;
                        usuario.Rol.Tipo = query.Tipo;
                        usuario.Contra = Encoding.UTF8.GetString(usuario.Password);
                    }
                }
            }catch (Exception ex)
            {
                usuario.MensajeError = ex.Message;
            }
            return usuario;
        }
    }
}
