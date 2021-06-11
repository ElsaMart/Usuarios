using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Usuario_Practica.Models;
using Usuarios.Data;
using Usuario_Practica.Utitlities;

namespace Usuario_Practica.Repository
{
    public class UsuarioRepository
    {
        public OperationResponse<List<UsuarioDTO>> GetAll()
        {
            OperationResponse<List<UsuarioDTO>> Response;
            try
            {
                using (var db = new Usuario_PracticaEntities())
                {
                    Response = new OperationResponse<List<UsuarioDTO>>()
                    {
                        Result = ResponseType.Ok,
                        Data = db.Usuario.Select(u => new UsuarioDTO
                        {
                            Id = u.ID,
                            Nombre = u.NOMBRE,
                            Edad = u.EDAD.Value,
                            Correo = u.CORREO
                        }).ToList(),
                        HTTPCode = 200
                    };
                }
            }
            catch (Exception ex)
            {
                Response = new OperationResponse<List<UsuarioDTO>>()
                {
                    Result = ResponseType.Error,
                    ErrorMessage = Utils.ErrorException(ex)
                };
            }
            return Response;
        }
        public OperationResponse<UsuarioDTO> Get(int Id)
        {
            OperationResponse<UsuarioDTO> Response;
            try
            {
                using (var db = new Usuario_PracticaEntities())
                {
                    Response = new OperationResponse<UsuarioDTO>()
                    {
                        Data = db.Usuario.Where(u => u.ID == Id).Select(n => new UsuarioDTO()
                        {
                            Id = n.ID,
                            Nombre = n.NOMBRE,
                            Edad = n.EDAD.Value,
                            Correo = n.CORREO
                        }).FirstOrDefault()
                    };
                }
                
            }
            catch (Exception ex)
            {
                Response = new OperationResponse<UsuarioDTO>()
                {
                    Result = ResponseType.Error,
                    ErrorMessage = Utils.ErrorException(ex)
                };
            }
            return Response;
        }
        public OperationResponse<bool> CreateorSave(UsuarioDTO data)
        {
            OperationResponse<bool> Response;
            try
            {
                using (var db = new Usuario_PracticaEntities())
                {
                    if (data.Id == 0) 
                    {
                        db.Usuario.Add(new Usuario()
                        {
                            NOMBRE = data.Nombre,
                            EDAD = data.Edad,
                            CORREO = data.Correo
                        });
                    }
                    else
                    {
                        var user = db.Usuario.Where(u => u.ID == data.Id).FirstOrDefault();
                        user.NOMBRE = data.Nombre;
                        user.EDAD = data.Edad;
                        user.CORREO = data.Correo;
                    }
                    db.SaveChanges();
                    Response = new OperationResponse<bool>()
                    {
                        Data = true,
                        Result = ResponseType.Ok,
                        HTTPCode = 200
                    };
                }
            }
            catch (Exception ex)
            {
                Response = new OperationResponse<bool>()
                {
                    Result = ResponseType.Error,
                    ErrorMessage = Utils.ErrorException(ex),
                    HTTPCode = 500
                };
            }
            return Response;
        }
        public OperationResponse<bool> Delete(int Id)
        {
            OperationResponse<bool> Response;
            try
            {
                using (var db = new Usuario_PracticaEntities())
                {
                    var user = db.Usuario.Where(u => u.ID == Id).FirstOrDefault();
                    if (user != null)
                        db.Usuario.Remove(user);

                    db.SaveChanges();

                    Response = new OperationResponse<bool>()
                    {
                        Data = true,
                        Result = ResponseType.Ok,
                        HTTPCode = 200
                    };
                }
            }
            catch (Exception ex)
            {
                Response = new OperationResponse<bool>()
                {
                    Result = ResponseType.Error,
                    ErrorMessage = Utils.ErrorException(ex),
                    HTTPCode = 500
                };
            }
            return Response;
        }
    }
}