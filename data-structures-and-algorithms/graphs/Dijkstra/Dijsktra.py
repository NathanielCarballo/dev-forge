from collections import defaultdict

#creating a graph class for edges and weights
class Graph():
    def __init__(self):
        self.edges = defaultdict(list)
        self.weights = {}

    def add_edge(self, from_node, to_node, weight):
        self.edges[from_node].append(to_node)
        self.edges[to_node].append(from_node)
        self.weights[(from_node, to_node)] = weight
        self.weights[(to_node, from_node)] = weight

#initializing the graph and inputting the weights and edges
graph = Graph()

edges = [
    ('a','b',4),
    ('a','c',2),
    ('b','c',1),
    ('b','d',5),
    ('c','d',8),
    ('c','e',10),
    ('d','e',2),
    ('d','z',6),
    ('e','z',5),
    ]

for edge in edges:
    graph.add_edge(*edge)

#creating the dijsktra algorithm to find the shortest path
#and shortest weights between the edges
def dijsktra(graph,initial,end):
    shortest_paths={initial:(None, 0)}
    current_node = initial
    visited = set()
    while current_node != end:
        visited.add(current_node)
        destinations = graph.edges[current_node]
        weight_to_current_node = shortest_paths[current_node][1]

        for next_node in destinations:
            weight = graph.weights[(current_node, next_node)] + weight_to_current_node
            if next_node not in shortest_paths:
                shortest_paths[next_node] = (current_node, weight)
            else:
                current_shortest_weight = shortest_paths[next_node][1]
                if current_shortest_weight > weight:
                        shortest_paths[next_node] = (current_node, weight)

        next_destinations = {node: shortest_paths[node] for node in shortest_paths if node not in visited}

#setting error message for Routes not possible
        if not next_destinations:
            return "Route Not Possible"
        current_node = min(next_destinations , key=lambda k: next_destinations[k][1])

        path = []

        while current_node is not None:
            path.append(current_node)
            next_node = shortest_paths[current_node][0]
            current_node = next_node

        path = path[::-1]
        return path


print(dijsktra(graph,'a','z'))
