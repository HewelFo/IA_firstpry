using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_IA
{
    class Nodo
    {
        
        int[,] estado;
        List<Nodo> hijos = new List<Nodo>();
        Nodo Father;
        private List<Nodo> expancion;

        public Nodo(int[,] estado)
        {
            this.estado = estado;
            hijos = null;
            Father = null;

        }

        public Nodo(List<Nodo> expancion)
        {
            this.expancion = expancion;
        }

        public int[,] GetEstado()
        {
            return estado;
        }

        public void SetEstado(int[,] estado)
        {
            this.estado = estado;
        }

        public List<Nodo> GetHijos()
        {
            return hijos;
        }

        public void SetHijos(List<Nodo> hijos)
        {
            this.hijos = hijos;
            /*if (hijos != null)
            {
                for (Nodo h:hijos)
                {
                    h.Father = this;
                }
            }*/
        }

        public Nodo GetFather()
        {
            return Father;
        }

        public void SetFather(Nodo Father)
        {
            this.Father = Father;
        }
/*
        public Nodo TakePosition(int [,] estado)
        {
            int d = 0;
            int a = 0;
            int leng = estado.Length;
            for (int i=0; i < leng; i++)
            {
                for (int t = 0; t < leng; t++)
                {
                    estado[i, t] = estado[a, d];
                    d++;
                }
                a++;
            }
            SetEstado(estado);
            return Father;
        }
*/
    }
}
