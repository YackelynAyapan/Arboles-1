using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbolBinario
{
    public class ArbolBinario
    {
        class Nodo
        {
            public int info;
            public Nodo izq, der;
        }
        private Nodo raiz;
        private int cant;
        

        public ArbolBinario()
        {
            raiz = null;
        }

        public void Insertar(int info)
        {
            if (!Existe(info))
            {
                Nodo nuevo;
                nuevo = new Nodo();
                nuevo.info = info;
                nuevo.izq = null;
                nuevo.der = null;
                if (raiz == null)
                    raiz = nuevo;
                else
                {
                    Nodo anterior = null, reco;
                    reco = raiz;
                    while (reco != null)
                    {
                        anterior = reco;
                        if (info < reco.info)
                            reco = reco.izq;
                        else
                            reco = reco.der;
                    }
                    if (info < anterior.info)
                        anterior.izq = nuevo;
                    else
                        anterior.der = nuevo;
                }
            }
        }

        public bool Existe(int info)
        {
            Nodo reco = raiz;
            while (reco != null)
            {
                if (info == reco.info)
                    return true;
                else
                    if (info > reco.info)
                    reco = reco.der;
                else
                    reco = reco.izq;
            }
            return false;
        }

     


        private void Cantidad(Nodo reco)
        {
            if (reco != null)
            {
                cant++;
                Cantidad(reco.izq);
                Cantidad(reco.der);
            }
        }

        public int Cantidad()
        {
            cant = 0;
            Cantidad(raiz);
            return cant;
        }

        static void Main(string[] args)
        {
            ArbolBinario abo = new ArbolBinario();
            abo.Insertar(100);
            abo.Insertar(50);
            abo.Insertar(25);
            abo.Insertar(75);
            abo.Insertar(150);
            Console.WriteLine("Cantidad de nodos del árbol:" + abo.Cantidad());
            Console.ReadKey();
          
        }
    }
}

