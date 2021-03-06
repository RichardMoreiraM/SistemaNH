﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SistemaNH.Models.DTO;

namespace SistemaNH.Models.DAO
{
    public class UserDAO
    {
        private readonly MySqlConnection _cnn;

        public UserDAO() {
            _cnn = Conexion.GetInstance().GetConnection();
        }

        public Usuario Login(Usuario user) {
            user.Estado = -1;
            try { 
                var command = new MySqlCommand("call login(@email, @clave)", _cnn);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@clave", user.Clave);
                using MySqlDataReader oReader = command.ExecuteReader();
                while (oReader.Read()) {
                    user.Id = oReader["id"].ToString();
                    user.Nombres = oReader["nombres"].ToString();
                    user.Estado = int.Parse(oReader["estado"].ToString());
                    user.Rol = new Rol { Descripcion = oReader["descripcion"].ToString() };
                }
                return user;
            } catch (Exception) {
                return user;
            }
        }

        public bool AddUser(Usuario user) {
            try {
                var command = new MySqlCommand("call add_usuario(@json)", _cnn);
                command.Parameters.AddWithValue("@json", user.ToJSON());
                return command.ExecuteNonQuery() > 0;
            } catch (Exception) {
                return false;
            }
        }

        public List<string> GetCursos(string id) {
            var cursos = new List<string>();
            try {
                var command = new MySqlCommand("call usuario_cursos(@id)", _cnn);
                command.Parameters.AddWithValue("@id", id);
                using (var oReader = command.ExecuteReader()) {
                    while (oReader.Read()) {
                        cursos.Add(oReader["id_curso"].ToString());
                    }
                }
                return cursos;
            } catch (Exception) {
                return cursos;
            }
        } 

        public Usuario GetUsuario(string id) {
            var user = new Usuario();
            try {
                var command = new MySqlCommand("call usuario_por_id(@id)", _cnn);
                command.Parameters.AddWithValue("@id", id);
                using (var oReader = command.ExecuteReader()) {
                    while (oReader.Read()) {
                        user.Id = oReader["usuario_id"].ToString();
                        user.Cedula = oReader["cedula"].ToString();
                        user.Nombres = oReader["nombres"].ToString();
                        user.Email = oReader["email"].ToString();
                        user.Rol = new Rol { Id = oReader["rol_id"].ToString() };
                    }
                }
                //user.Cursos = GetCursos(id);
                return user;
            } catch (Exception) {
                return user;
            }
        }

        public List<Usuario> GetUsuarios() {
            var users = new List<Usuario>();
            try {
                var command = new MySqlCommand("call usuarios()", _cnn);
                using (var oReader = command.ExecuteReader()) {
                    while (oReader.Read()) {
                        var user = new Usuario();
                        user.Id = oReader["id"].ToString();
                        user.Cedula = oReader["cedula"].ToString();
                        user.Nombres = oReader["nombres"].ToString();
                        user.Email = oReader["email"].ToString();
                        user.Estado = int.Parse(oReader["estado"].ToString());
                        user.UsuarioIngreso = oReader["usuario_ingreso"].ToString();
                        user.FechaIngreso = Parse(oReader["fecha_ingreso"].ToString());
                        user.FechaExpiracion = Parse(oReader["fecha_expiracion"].ToString());
                        user.UsuarioModificacion = oReader["usuario_modificacion"].ToString();
                        user.FechaModificacion = Parse(oReader["fecha_modificacion"].ToString());
                      //  user.Jornada = new Jornada { IdJornada = oReader["jornada"].ToString() };
                        user.Rol = new Rol { Descripcion = oReader["descripcion"].ToString() };
                        users.Add(user);
                    }
                }
                return users;
            } catch (Exception) {
                return users;
            }
        }

        public bool Enabled(string id) {
            try {
                var command = new MySqlCommand("call activar_usuario(@id)", _cnn);
                command.Parameters.AddWithValue("@id", id);
                return command.ExecuteNonQuery() > 0;
            } catch (Exception) {
                return false;
            }
        }

        public bool Disabled(string id) {
            try {
                var command = new MySqlCommand("call desactivar_usuario(@id)", _cnn);
                command.Parameters.AddWithValue("@id", id);
                return command.ExecuteNonQuery() > 0;
            } catch (Exception) {
                return false;
            }
        } 

        private DateTime? Parse(string date) {
            if(date.Length > 0)
                return DateTime.Parse(date);
            return null;
        }
    }
}
