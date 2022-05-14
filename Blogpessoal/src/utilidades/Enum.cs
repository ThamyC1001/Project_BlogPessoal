using System.Text.Json.Serialization;

namespace Blogpessoal.src.utilidades
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoUsuario 
    {     
        NORMAL, 
        ADMINISTRADOR 
    }

}
