

using System;

namespace AlgoritmoDijkstra
{
    class Grafo
    {
        static int numeroVertices = 9;

        int pesoMinimo(int[] pesos, bool[] conjuntoCaminhosCurtos)
        {
            int minimo = int.MaxValue, indice_minimo = -1;
            
            for (int vertice = 0; vertice < numeroVertices; vertice++)
                if (conjuntoCaminhosCurtos[vertice] == false && pesos[vertice] <= minimo){
                    minimo = pesos[vertice];
                    indice_minimo = vertice;
                }
            return indice_minimo;
        }

        void printSolucao(int[] pesos)
        {
            Console.Write("Vértice \t\t Peso "
                            + "a partir da Origem\n");
            for (int i = 0; i < numeroVertices; i++)
                Console.Write(i + " \t\t " + pesos[i] + "\n");
        }

        void dijkstra(int[,] grafo, int origem)
        {
            int[] pesos = new int[numeroVertices];
            bool[] conjuntoCaminhosCurtos = new bool[numeroVertices];
            
            for (int i = 0; i < numeroVertices; i++){
                pesos[i] = int.MaxValue;
                conjuntoCaminhosCurtos[i] = false;
            }
            
            pesos[origem] = 0;

            for (int contagem = 0; contagem < numeroVertices - 1; contagem++){
                int u = pesoMinimo(pesos, conjuntoCaminhosCurtos);
                
                conjuntoCaminhosCurtos[u] = true;

                for (int vertice = 0; vertice < numeroVertices; vertice++)
            
                if (!conjuntoCaminhosCurtos[vertice] && grafo[u, vertice] != 0
                    && pesos[u] != int.MaxValue && pesos[u] + grafo[u, vertice] < pesos[vertice])
                    pesos[vertice] = pesos[u] + grafo[u, vertice];
            }

            printSolucao(pesos);
        }

        public static void Main()
        {

            int[,] grafo = new int[,] {
                { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                { 0, 0, 2, 0, 0, 0, 6, 7, 0 } 
                };

                Grafo exemplo = new Grafo();

                exemplo.dijkstra(grafo, 0);
        }
    }

}

