using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Application.Shared
{
    public class BaseResponse<T>
    {
        public bool HuboError { get; private set; }
        public T?  Data { get; private set; }
        public string? Mensaje { get; private set; }
        public List<string>? Errores { get; private set; }
        public BaseResponse(string mensaje)
        {
            Mensaje = mensaje;
            HuboError = false;
        }
        public BaseResponse(List<string> errores)
        {
            Errores = errores;
            HuboError = true;
        }
        public BaseResponse(string mensaje, T data)
        {
            Mensaje = mensaje;
            Data = data;
            HuboError = false;
        }
    }
}
