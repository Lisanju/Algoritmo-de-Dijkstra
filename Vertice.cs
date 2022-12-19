using System;

namespace DijkstraAlgorithm
{
    class Vertice
    {
        public String nome;
        public int status;
        public int predecessor;
        public int peso;

        public Vertice(String nome)
        {
            this.nome = nome;
        }

    }
}

