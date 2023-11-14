namespace ConsoleApp8
{
    class DijkstraAlgorithm
    {
        private const int INF = int.MaxValue; // "Бесконечность" для алгоритма
        public int[,] graph; // Матрица смежности для представления графа
        private int verticesCount; // Количество вершин в графе

        public DijkstraAlgorithm(int[,] adjMatrix)
        {
            this.graph = adjMatrix;
            this.verticesCount = adjMatrix.GetLength(0);
        }

        // Алгоритм Дейкстры
        public void Dijkstra(int startNode)
        {
            int[] distance = new int[verticesCount]; // Расстояние от начальной вершины
            bool[] shortestPathsSet = new bool[verticesCount]; // Флаг для хранения информации о вершинах с найденными кратчайшими путями

            // Инициализация расстояний и флажков
            for (int i = 0; i < verticesCount; i++)
            {
                distance[i] = INF; // Устанавливаем "бесконечность" для начального расстояния
                shortestPathsSet[i] = false; // Изначально ни одна вершина не имеет кратчайшего пути
            }

            distance[startNode] = 0; // Расстояние до самой себя равно нулю

            // Алгоритм Дейкстры
            for (int count = 0; count < verticesCount - 1; count++)
            {
                // Найти вершину с минимальным расстоянием из набора вершин, которые еще не вошли в кратчайший путь
                int u = MinimumDistance(distance, shortestPathsSet);
                shortestPathsSet[u] = true; // Включаем вершину в множество вершин с минимальными путями

                // Обновляем расстояния смежных вершин
                for (int v = 0; v < verticesCount; v++)
                {
                    if (!shortestPathsSet[v] && graph[u, v] != 0 && distance[u] != INF && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                    }
                }
                PrintDijkstraStep(distance); // Отображаем шаг алгоритма
            }
        }

        // Вспомогательная функция для поиска вершины с минимальным расстоянием
        private int MinimumDistance(int[] distance, bool[] shortestPathsSet)
        {
            int min = INF, minIndex = -1;

            for (int v = 0; v < verticesCount; v++)
            {
                if (!shortestPathsSet[v] && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }

        // Вспомогательная функция для вывода шага алгоритма Дейкстры
        private void PrintDijkstraStep(int[] distance)
        {
            Console.Write("Шаг алгоритма Дейкстры: [");

            for (int i = 0; i < verticesCount; i++)
            {
                Console.Write(distance[i]);
                if (i < verticesCount - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }


        public void PrintGraph()
        {
            Console.WriteLine("Матрица смежности графа:");
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Вспомогательная функция для нахождения максимальной дистанции
        public int FindMaxDistance(int[] distance)
        {
            int max = 0;
            for (int i = 0; i < verticesCount; i++)
            {
                if (distance[i] > max)
                {
                    max = distance[i];
                }
            }
            return max;
        }
    }



class Program
    {
        static void Main()
        {
            int[,] graph = new int[,]
            {
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

            DijkstraAlgorithm dijkstra = new DijkstraAlgorithm(graph);
            dijkstra.PrintGraph(); // Выводим граф в консоль
            dijkstra.Dijkstra(0); // Начинаем обход алгоритмом Дейкстры с вершины 0
         //   int maxDistance = dijkstra.FindMaxDistance(dijkstra.graph); // Находим максимальное расстояние
           // Console.WriteLine("Максимальное расстояние: " + maxDistance);
            Console.ReadLine();
        }
    }
}