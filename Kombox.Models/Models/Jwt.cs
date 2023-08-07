using System.Security.Claims;

namespace Kombox.Models.Models
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        public class ValidarTokenResult
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public Usuario Result { get; set; }
        }

        public static ValidarTokenResult ValidarToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0)
                {
                    return new ValidarTokenResult
                    {
                        Success = false,
                        Message = "Verifica si estás enviando un token válido",
                        Result = null
                    };
                }

                var id = identity.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
                Usuario usuario = Usuario.DB().FirstOrDefault(x => x.IdUser == id);

                return new ValidarTokenResult
                {
                    Success = true,
                    Message = "exito",
                    Result = usuario
                };
            }
            catch (Exception ex)
            {
                return new ValidarTokenResult
                {
                    Success = false,
                    Message = "Catch: " + ex.Message,
                    Result = null
                };
            }
        }
    }

}
