using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaEvaluacion.DTO
{
    public class PrestamoDTO
    {
        // ToDo: atributos
        private int id;
        private int monto;

        private static List<PrestamoDTO> prestamos = new List<PrestamoDTO>()
        {
            new PrestamoDTO() {id = 1, monto = 50000},
            new PrestamoDTO() {id = 2, monto = 100000},
            new PrestamoDTO() {id = 3, monto = 90000}
        };

        // ToDo: propiedades
        public int Id
        {
            get => id;
            set => id = value;
        }

        public int Monto
        {
            get => monto;
            set => monto = value;
        }

        public int MontoMasIntereses
        {
            get => (monto + (monto * 10 / 100));
        }

        public int MontoAtraso
        {
            get => (MontoMasIntereses + (monto * 5 / 100));
        }
        // ToDo: métodos
        public static bool Add(PrestamoDTO datos)
        {
            try
            {
                prestamos.Add(datos);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("debe ingresar un numero");
                return false;
            }
        }

        public static List<PrestamoDTO> List()
        {
            return prestamos;
        }

        public static int Find(int id)
        {
            for (int i = 0; i < prestamos.Count; i++)
            {
                if (prestamos[i].id == id)
                {
                    return i;
                }
            }

            return -1;
        }

        public static PrestamoDTO Find(PrestamoDTO datos)
        {
            return datos;
        }

        public static bool Edit(PrestamoDTO datos, int index)
        {
            return false;
        }

        public static bool RemoveById(PrestamoDTO datos, int index)
        {
            int id = Find(index);

            if (id >= 0)
            {
                prestamos.RemoveAt(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool RemoveAtIndex(PrestamoDTO datos, int index)
        {
            return false;
        }

        public override string ToString()
        {
            return $"Id: {id} | Monto: {monto} | Monto con interes: {MontoMasIntereses} | Monto con interes y atraso: {MontoAtraso}";
        }
    }
}
