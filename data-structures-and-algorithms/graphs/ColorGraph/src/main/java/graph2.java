
import java.util.*; 
import java.util.LinkedList; 
  
 
class Graph
{ 
    private int V;    
    private LinkedList<Integer> adj[];  
  
     
    Graph(int v) //creates graph based on the number of vertices
    { 
        V = v; 
        adj = new LinkedList[v]; 
        for (int i=0; i<v; ++i) 
            adj[i] = new LinkedList(); 
    } 
  
     
    void addEdge(int v,int w) //allows for adding edges to vertices
    { 
        adj[v].add(w); 
        adj[w].add(v);  
    } 
  
    
    void graphColoring()   //assigns colors to all vertices 
    { 
        int result[] = new int[V]; 
  
         
        Arrays.fill(result, -1); 
  
         
        result[0]  = 0; 
  
        //temp array for storing colors
        boolean available[] = new boolean[V]; 
          
        
        Arrays.fill(available, true); 
  
         
        for (int u = 1; u < V; u++) 
        { 
            //proccess near nodes and mark their colors as not available
            Iterator<Integer> it = adj[u].iterator() ; 
            while (it.hasNext()) 
            { 
                int i = it.next(); 
                if (result[i] != -1) 
                    available[result[i]] = false; 
            } 
  
           //finds first color that is available
            int cr; 
            for (cr = 0; cr < V; cr++){ 
                if (available[cr]) 
                    break; 
            } 
  
            result[u] = cr; //assign that color
  
             
            Arrays.fill(available, true); 
        } 
  
        //prints out the results
        for (int u = 0; u < V; u++) 
            System.out.println("Vertex " + u + " --->  Color "
                                + result[u]); 
    } 
  
    
    public static void main(String args[]) 
    { 
        Graph g1 = new Graph(6); 
        g1.addEdge(4, 0); 
        g1.addEdge(4, 1); 
        g1.addEdge(4, 2); 
        g1.addEdge(4, 5); 
        g1.addEdge(3, 1);
        g1.addEdge(3, 2);
        g1.addEdge(0, 1);
        g1.addEdge(0, 5);
        System.out.println("Graph Coloring"); 
        g1.graphColoring(); 
  
   
    } 
} 