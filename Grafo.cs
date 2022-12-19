using System;

namespace DijkstraAlgorithm
{
    class Grafo
    {
        static void Main(string[] args)
        {
            DijkstraAlgorithm grafo = new DijkstraAlgorithm();

            grafo.InserirVertice("Zero");
            grafo.InserirVertice("Um");
            grafo.InserirVertice("Dois");
            grafo.InserirVertice("Três");
            grafo.InserirVertice("Quatro");
            grafo.InserirVertice("Cinco");
            grafo.InserirVertice("Seis");
            grafo.InserirVertice("Sete");
            grafo.InserirVertice("Oito");

            Console.ReadLine();
        }
    }
}
