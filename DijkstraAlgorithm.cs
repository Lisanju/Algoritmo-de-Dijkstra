using System;

namespace DijkstraAlgorithm
{
    class DijkstraAlgorithm
    {
        public readonly int Maximo_de_Vertices = 30;

        int vertice;
        int aresta;
        int[,] adjacente;
        Vertice[] Lista_de_Vertices;

        private readonly int Temporario = 1;
        private readonly int Permanente = 2;
        private readonly int Nulo = -1;
        private readonly int Infinito = 9999;

        public void Grafo_Orientado_e_com_Peso()
        {
            adjacente = new int[Maximo_de_Vertices, Maximo_de_Vertices];
            Lista_de_Vertices = new Vertice[Maximo_de_Vertices];
        }

        private void Dijkstra(int origem)
        {
            int vertice, atual;
            for (vertice = 0; vertice < this.vertice; vertice++)
            {
                Lista_de_Vertices[vertice].status = Temporario;
                Lista_de_Vertices[vertice].peso = Infinito;
                Lista_de_Vertices[vertice].predecessor = Nulo;
            }
            Lista_de_Vertices[origem].peso = 0;

            while (true)
            {
                atual = Vertice_Temporario_com_Peso_Minimo();

                if (atual == Nulo) return;

                Lista_de_Vertices[atual].status = Permanente;

                for (vertice = 0; vertice < this.vertice; vertice++)
                {
                    if (Lista_de_Vertices[vertice].status == Temporario)
                        if (Lista_de_Vertices[atual].peso + adjacente[atual,vertice] < Lista_de_Vertices[vertice].peso)
                        {
                            Lista_de_Vertices[vertice].predecessor = atual;
                            Lista_de_Vertices[vertice].peso = Lista_de_Vertices[atual].peso + adjacente[atual, vertice];
                        }
                }
            }
        }

        public void AcharCaminhos(String nome_origem)
        {
            int origem = PegarIndice(nome_origem);

            Dijkstra(origem);

            Console.WriteLine("Vértice de origem: " + nome_origem + "\n");

            for (int vertice = 0; vertice < this.vertice; vertice++)
            {
                Console.WriteLine("Vértice de destino: " + Lista_de_Vertices[vertice].nome);
                if (Lista_de_Vertices[vertice].peso == Infinito)
                    Console.WriteLine("Não há caminho de " + nome_origem + " para " + Lista_de_Vertices[vertice].nome);
                else AcharOCaminho(origem, vertice);
            }
        }

        private void AcharOCaminho(int origem, int vertice)
        {
            int i, precedente;
            int[] caminho = new int[this.vertice];
            int distancia_mais_curta = 0;
            int quantidade_de_vertices = 0;

            while (vertice != origem)
            {
                quantidade_de_vertices++;
                caminho[quantidade_de_vertices] = vertice;
                precedente = Lista_de_Vertices[vertice].predecessor;
                distancia_mais_curta += adjacente[precedente, vertice];
                vertice = precedente;
            }
            quantidade_de_vertices++;
            caminho[quantidade_de_vertices] = origem;

            Console.WriteLine("O caminho mais curto é: ");
            for (i = quantidade_de_vertices; i >= 1; i--)
                Console.WriteLine(caminho[i] + " ");
            Console.WriteLine("\n A distância mais curta é: " + distancia_mais_curta + "\n");
        }

        private int Vertice_Temporario_com_Peso_Minimo()
        {
            int minimo = Infinito;
            int partida = Nulo;
            for (int vertice = 0; vertice < this.vertice; vertice++)
            {
                if (Lista_de_Vertices[vertice].status == Temporario && Lista_de_Vertices[vertice].peso < minimo)
                {
                    minimo = Lista_de_Vertices[vertice].peso;
                    partida = vertice;
                }
            }
            return partida;
        }

        private int PegarIndice(String origem)
        {
            for (int i = 0; i < this.vertice; i++)
                if (origem.Equals(Lista_de_Vertices[i].nome))
                    return i;
            throw new System.InvalidOperationException("Vértice invalido");
        }

        public void InserirVertice(String nome)
        {

        }
    }
}
