using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaEvaluacion.DTO;

namespace LibreriaEvaluacion.DAL
{
    public class PrestamoDAL
    {
        // ToDo: métodos
        public bool Insertar(PrestamoDTO datos)
        {
            return PrestamoDTO.Add(datos);
        }

        public bool Actualizar(PrestamoDTO datos)
        {
            return false;
        }

        public bool Eliminar(PrestamoDTO datos, int indice)
        {
            return PrestamoDTO.RemoveById(datos, indice);
        }

        public List<PrestamoDTO> Listar()
        {
            return PrestamoDTO.List();
        }

        public PrestamoDTO? BuscarPorId(int indice)
        {
            foreach (PrestamoDTO prestamo  in PrestamoDTO.List())
            {
                if (prestamo.Id == indice)
                {
                    return prestamo;
                }
            }

            return null;
        }
    }
}
