using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01_IA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbmov.Text = movimientos.ToString();
        }

        private const int V = 0;

        /// <summary>
        /// Ui--> mas que nada los botones, label, etc
        /// </summary>
        private bool boton1 = false;
        private bool boton2 = false;
        private bool boton3 = false;
        private bool boton4 = false;
        private bool boton5 = false;
        private bool boton6 = false;
        private bool boton7 = false;
        private bool boton8 = false;
        private bool boton9 = false;
        private bool botonEnviar = false;

        

        int movimientos = 0;
        
        public void Intercarmbio(Button origen, Button destino)
        {
            string aux;
            if (origen.Text != "0")
            {
                if(destino.Text == "0")
                {
                    aux = origen.Text;
                    origen.Text = "0";
                    destino.Text = aux;
                }
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            boton1 = true;
            if(botonEnviar == true)
            {
                movimientos++;
            }
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button1, button2);
            Intercarmbio(button1, button4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            boton2 = true;
            if (botonEnviar == true)
            {
                movimientos++;
            }
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button2, button1);
            Intercarmbio(button2, button3);
            Intercarmbio(button2, button5);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            boton3 = true;
            if (botonEnviar == true)
            {
                movimientos++;
            }
            Intercarmbio(button3, button6);
            Intercarmbio(button6, button2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            boton4 = true;
            if (botonEnviar == true)
            {
                movimientos++;
            }
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button4, button1);
            Intercarmbio(button4, button5);
            Intercarmbio(button4, button7);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            boton5 = true;
            if (botonEnviar == true)
            {
                movimientos++;
            }
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button5, button2);
            Intercarmbio(button5, button4);
            Intercarmbio(button5, button6);
            Intercarmbio(button5, button8);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            boton6 = true;
            if (botonEnviar == true)
            {
                movimientos++;
            }
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button6, button3);
            Intercarmbio(button6, button5);
            Intercarmbio(button6, button9);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            boton7 = true;
            if (botonEnviar == true)
            {
                movimientos++;
            }
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button7, button4);
            Intercarmbio(button7, button8);
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            boton8 = true;
            if (botonEnviar == true)
            {
                movimientos++;
            }
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button8, button5);
            Intercarmbio(button8, button7);
            Intercarmbio(button8, button9);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            boton9 = true;
            if (botonEnviar == true)
            {
                movimientos++;
            }
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button9, button6);
            Intercarmbio(button9, button8);
            
        }

        /*
         Inicia algoritmo de busqueda
         */
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            botonEnviar = true;
            int a = (int.Parse(button1.Text));

            /*
             Tomo los valores del boton
             */
            int[,] inicio = { { System.Int32.Parse(button1.Text), Int32.Parse(button2.Text), Int32.Parse(button3.Text) },
                              { Int32.Parse(button4.Text), Int32.Parse(button5.Text), Int32.Parse(button6.Text) }, 
                              { Int32.Parse(button7.Text), Int32.Parse(button8.Text), Int32.Parse(button9.Text) } 
                            };
            int[,] sino = { { Int32.Parse(button01.Text), Int32.Parse(button02.Text), Int32.Parse(button03.Text) }, 
                            { Int32.Parse(button04.Text), Int32.Parse(button05.Text), Int32.Parse(button06.Text) }, 
                            { Int32.Parse(button07.Text), Int32.Parse(button08.Text), Int32.Parse(button09.Text) } 
                           };
            /*Me percate que no imprime el arreglo*/
            //vv_lb.Text = inicio.ToString();
            Nodo inicial = new Nodo(inicio);
            inicial.Equals(inicio);
            BuscarSolucion(inicial, sino);

            void BuscarSolucion(Nodo inici, int[,] sin)
            {
                List<Nodo> Expancion = new List<Nodo>();// crea un arraylist para guardar el nodo creado
                List<Nodo> visitar = new List<Nodo>();// array para identificar las rutas encontradas
                Expancion.Add(inici);
                Expancion.RemoveAt(0);
                int contador = 0;
                /*
                 * Todo el algoritmo de busqueda quedo en esta parte
                 */
                int ayu = 0;
                while (Expancion.Count != 0)
                {
                    contador++;
 
                    Nodo Revisar = new Nodo(Expancion);//no se que error tiene
                    int[] zerop = UbicacionCero(Revisar.GetEstado());//recive las pocisiones 

                    List<Nodo> hijos = new List<Nodo>();
                    visitar.Add(Revisar);
                    /*Aqui esta lo que te digo, necesito enviar tanto la clase como el los dos puntos de zerop[0],zerop[1]*/
                    if (zerop[0] != 0) 
                    {
                        Nodo hijo = new Nodo(clonar(Revisar.GetEstado()));
                        int[,] arrb = hijo.GetEstado();
                        ayu = arrb[zerop[0], zerop[0]];
                        arrb[zerop[0], zerop[0]] = arrb[zerop[0]-1, zerop[1]];
                        arrb[zerop[0], zerop[1]] = ayu;

                       /* int[,] arrb = hijo.GetEstado() [zerop[0] - 1 zerop[1]];
                        hijo.GetEstado()[zerop[0]][zerop[1]] = arrb; *//*aqui necesito igualar tanto el objeto como el array al entero arrb*/
                        /* hijo.GetEstado() + [zerop[0] - 1][zerop[1]] = 0;
                         Expancion.Add(hijo);
                         hijos.Add(hijo);
                         */
                    }
                    if (zerop[0] != 2)
                    {
                        Nodo hijo = new Nodo(clonar(Revisar.GetEstado()));
                        int[,] arrb = hijo.GetEstado();
                        ayu = arrb[zerop[0], zerop[0]];
                        arrb[zerop[0], zerop[0]] = arrb[zerop[0] + 1, zerop[1]];
                        arrb[zerop[0], zerop[1]] = ayu;

                        /* int[,] abj = hijo.GetEstado() + [zerop[0] + 1][zerop[1]];
                         hijo.GetEstado() + [zerop[0]][zerop[1]] = abj;
                         hijo.GetEstado() + [zerop[0] + 1][zerop[1]] = 0;
                         Expancion.Add(hijo);
                         hijos.Add(hijo);*/
                    }
                    if (zerop[1] != 0)
                    {
                        Nodo hijo = new Nodo(clonar(Revisar.GetEstado()));
                        int[,] arrb = hijo.GetEstado();
                        ayu = arrb[zerop[0], zerop[0]];
                        arrb[zerop[0], zerop[0]] = arrb[zerop[0], zerop[1]-1];
                        arrb[zerop[0], zerop[1]] = ayu;

                        /*int[,] izq = hijo.GetEstado() +[zerop[0]][zerop[1] - 1];
                        hijo.GetEstado() + [zerop[0]][zerop[1]] = izq;
                        hijo.GetEstado() + [zerop[0]][zerop[1] - 1] = 0;
                        Expancion.Add(hijo);
                        hijos.Add(hijo);*/
                    }
                    if (zerop[1] != 2)
                    {
                        Nodo hijo = new Nodo(clonar(Revisar.GetEstado()));
                        int[,] arrb = hijo.GetEstado();
                        ayu = arrb[zerop[0], zerop[0]];
                        arrb[zerop[0], zerop[0]] = arrb[zerop[0], zerop[1]+1];
                        arrb[zerop[0], zerop[1]] = ayu;
                        /*int[,] der = hijo.GetEstado() + [zerop[0]][zerop[1] + 1];
                        hijo.GetEstado() + [zerop[0]][zerop[1]] = der;
                        hijo.GetEstado() + [zerop[0]][zerop[1] + 1] = 0;
                        Expancion.Add(hijo);
                        hijos.Add(hijo);*/
                    }
                    Revisar.SetHijos(hijos);
                };
            }

            // muchas de las propiedas de las funciones mandaban un error que no eran compatibles entre ellas
            // por eso algunas veces crea objetos de mas solo para poder guardarlos y utilizarlos 
            int[] UbicacionCero(int[,] revisar)
            {
                // otra vez se crea un arraylist para resivir el nodo
                int[] Posicion = new int[2];// este solo guarda las ubucaciones de los nodos finales o el nodo final
                                            // pase el arraylist a un array para poder examinarlo en for 
                for (int i = 0; i < revisar.Length; i++)
                {
                    for (int g = 0; g < revisar.Length; g++)
                    {
                        if (revisar[i, g] == 0)
                        {
                            Posicion[0] = i;
                            Posicion[1] = g;
                        }
                    }

                }
                return Posicion;
            }

            int[,] clonar(int[,] v)//clonamos los array, para poder imprimirlos sin errores
            {
                int[,] clon = new int[v.Length, v.Length];
                for (int i = 0; i < v.Length; i++)
                {
                    for (int g = 0; g < v.Length; g++)
                    {
                        clon[i, g] = v[i, g];
                    }

                }
                return clon;
            }

            /*
             * Finaliza Algoritmo de busqueda
             */

        }


        private void button01_Click(object sender, EventArgs e)
        {
            boton1 = true;
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button01, button02);
            Intercarmbio(button01, button04);
        }

        private void button02_Click(object sender, EventArgs e)
        {
            boton2 = true;
  
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button02, button01);
            Intercarmbio(button02, button03);
            Intercarmbio(button02, button05);
        }

        private void button03_Click(object sender, EventArgs e)
        {
            boton3 = true;
            Intercarmbio(button03, button06);
            Intercarmbio(button06, button02);
        }

        private void button04_Click(object sender, EventArgs e)
        {
            boton4 = true;
            
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button04, button01);
            Intercarmbio(button04, button05);
            Intercarmbio(button04, button07);
        }

        private void button05_Click(object sender, EventArgs e)
        {
            boton5 = true;
           
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button05, button02);
            Intercarmbio(button05, button04);
            Intercarmbio(button05, button06);
            Intercarmbio(button05, button08);
        }

        private void button06_Click(object sender, EventArgs e)
        {
            boton6 = true;
            
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button06, button03);
            Intercarmbio(button06, button05);
            Intercarmbio(button06, button09);
        }

        private void button07_Click(object sender, EventArgs e)
        {
            boton7 = true;
            
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button07, button04);
            Intercarmbio(button07, button08);
        }

        private void button08_Click(object sender, EventArgs e)
        {
            boton8 = true;
           
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button08, button05);
            Intercarmbio(button08, button07);
            Intercarmbio(button08, button09);
        }

        private void button09_Click(object sender, EventArgs e)
        {
            boton9 = true;
            
            lbmov.Text = movimientos.ToString();
            Intercarmbio(button09, button06);
            Intercarmbio(button09, button08);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
