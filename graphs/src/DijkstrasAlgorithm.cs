using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

public class DijkstrasAlgorithm {
    public class ShortestPathResult<T> {
        public ReadOnlyCollection<T> Path { get; private set; }

        public double Distance { get; private set; }

        public ShortestPathResult(IList<T> path, double distance) {
            this.Path = new ReadOnlyCollection<T>(path);
            this.Distance = distance;
        }

        public override string ToString() {
            StringBuilder str = new StringBuilder();

            bool first = true;

            foreach (T key in this.Path) {
                if (!first) {
                    str.Append(" -> ");
                }

                first = false;

                str.Append(key);
            }

            str.Append($" {this.Distance}");

            return str.ToString();
        }
    }

    private class PartialSolution<T> {
        public Vertex<T> Vertex { get; set; }

        public PartialSolution<T> PreviousVertex { get; set; }

        public double DistanceToSource { get; set; }

        public PartialSolution(Vertex<T> vertex, double distanceToSource, PartialSolution<T> prev = null) {
            this.Vertex = vertex;
            this.DistanceToSource = distanceToSource;
            this.PreviousVertex = prev;
        }

        public ShortestPathResult<T> ToResult() {
            List<T> path = new List<T>();

            PartialSolution<T> vertexSolution = this;

            while (vertexSolution != null) {
                path.Add(vertexSolution.Vertex.Key);
                vertexSolution = vertexSolution.PreviousVertex;
            }

            path.Reverse();

            return new ShortestPathResult<T>(path, this.DistanceToSource);
        }
    }

    public ShortestPathResult<T> ShortestPath<T,V>(Graph<T,V> graph, T source, T destination) where V : Vertex<T> {
        Dictionary<T,PartialSolution<T>> solutions = new Dictionary<T,PartialSolution<T>>();

        List<PartialSolution<T>> queue = new List<PartialSolution<T>>();

        queue.Add(new PartialSolution<T>(graph.GetVertex(source), 0));

        while (queue.Count > 0) {
            PartialSolution<T> vertexSolution = queue.PopMin(ps => ps.DistanceToSource);

            if (vertexSolution.Vertex.Key.Equals(destination)) return vertexSolution.ToResult();

            foreach (NextVertex<T> nextVertex in vertexSolution.Vertex.GetNextVetices()) {
                PartialSolution<T> nextVertexSolution;

                if (solutions.TryGetValue(nextVertex.Vertex.Key, out nextVertexSolution)) {
                    if (vertexSolution.DistanceToSource + nextVertex.Weight < nextVertexSolution.DistanceToSource) {
                        nextVertexSolution.PreviousVertex = vertexSolution;
                        nextVertexSolution.DistanceToSource = vertexSolution.DistanceToSource + nextVertex.Weight;
                    }
                } else {
                    nextVertexSolution = new PartialSolution<T>(nextVertex.Vertex, vertexSolution.DistanceToSource + nextVertex.Weight, vertexSolution);
                    solutions[nextVertexSolution.Vertex.Key] = nextVertexSolution;
                    queue.Add(nextVertexSolution);
                }
            }
        }

        return null; // No solution
    }
}
