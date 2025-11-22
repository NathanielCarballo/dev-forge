def weighted_graph():               #creating a graph with weighted nodes
    
    return {

        '27': {'14':14, '35':35},
        '14': {'27':27, '10':10, '19':19},
        '35': {'27':27, '31':31, '42':42},
        '10': {'14':14},
        '19': {'14':14},
        '31': {'35':35},
        '42': {'35':35}
        }


print(weighted_graph())

root = '27'                         #setting root for route
path = {}                           #assigning path variable to find shortest path
adj_node = {}                       #created to search the neighbouring nodes
queue = []                          #set for appending unvisted nodes and removing visited nodes
graph = weighted_graph()            #set to display the created graph

for node in graph:                  #loop visits every node in the graph
    path[node] = float("inf")
    adj_node[node] = None
    queue.append(node)

path[root] = 0

while queue:                        #setting Dijkstra algorithm to find the shortest path back to the root from given input
    key_min = queue[0]              
    min_val = path[key_min]
    for n in range(1, len(queue)):
        if path[queue[n]] < min_val:
            key_min = queue[n]
            min_val = path[key_min]
    cur = key_min
    queue.remove(cur)
                          

    for i in graph[cur]:
        alternate = graph[cur][i] + path[cur]
        if path[i] > alternate:
            path[i] = alternate
            adj_node[i] = cur

                    
x ='42'
                                    #setting to node 42 and finding path back to node 27(root)
print('The heaviest path between node27 and node42')     
print(x, end = '<-')
while True:
    x = adj_node[x]
    if x is None:
        print("")
        break
    print(x, end='<-')
      


