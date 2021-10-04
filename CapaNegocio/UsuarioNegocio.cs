using System;
using System.Data;
using CapaEntidad;
using CapaDatos;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace CapaNegocio
{
    public class UsuarioNegocio
    {
        UsuarioDatos usuarioDatos = new UsuarioDatos();

        public SqlDataReader Login(int dni, string contraseña)
        {
            return usuarioDatos.Login(dni,contraseña);
        }      
               
        public Boolean GrabarUsuario(Usuario usuario)
        {
            EnviarMail(usuario);
            return usuarioDatos.GrabarUsuario(usuario);
        }

        public void EnviarMail(Usuario usuario)
        {
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "mailparahacerpruebas259@gmail.com",
                    Password = "Optica1234",
                }
            };

            MailAddress FromEmail = new MailAddress("mailparahacerpruebas259@gmail.com", "Óptica Lara");

            MailAddress ToEmail = new MailAddress(usuario.email, usuario.Nombre + " " + usuario.Apellido);

            MailMessage message = new MailMessage()
            {
                From = FromEmail,
                Subject = "Registro exitoso",
                Body = "Óptica Lara\n\nBienvenido a nuestro sistema de gestión.\nSus datos de acceso son:\nDNI: " + usuario.Dni +"\nContraseña: " + usuario.Contraseña,  
            };

            message.To.Add(ToEmail);

            try
            {
                Client.Send(message);
            }
            catch (Exception ex)
            {
            }
        }

        public DataTable ConsultarUsuarios()
        {
            return usuarioDatos.ConsultarUsuarios();
        }

        public DataTable BuscarUsuarioDni(int dni)
        {
            return usuarioDatos.BuscarUsuarioDni(dni);
        }

        public DataTable BuscarUsuarioApeNom(string ApeNom)
        {
            return usuarioDatos.BuscarUsuarioApeNom(ApeNom);
        }

        public DataTable CargarComboUsuarios()
        {
            return usuarioDatos.CargarComboUsuarios();
        }
    }
}
