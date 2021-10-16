using CapaDatos;
using CapaEntidad;
using System;

namespace CapaNegocio
{
    public class PrecioNegocio
    {
        PrecioDatos precioDatos = new PrecioDatos();

        public Boolean GrabarPrecio(Precio precio)
        {
            return precioDatos.GrabarPrecio(precio);
        }
    }
}
