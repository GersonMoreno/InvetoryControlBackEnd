using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain.Base
{
    public class Response
    {
        public string? Mensaje { get; private set; }
        public bool HuboError { get; private set; }

        public Response(string? mensaje)
        {
            Mensaje = mensaje;
            HuboError = true;
        }
        public Response(string? mensaje, bool huboError)
        {
            Mensaje = mensaje;
            HuboError = huboError;
        }
    }
}
