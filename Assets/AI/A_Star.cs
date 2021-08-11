using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Linq;

public class A_Star : MonoBehaviour
{
    private Grid grid;
    
    private void Start()
    {
        grid.GetComponent<Grid>();
    }
    public void reconstruct_path(Vector3 startPoint, Vector3 current)
    {
        Node currentNode = grid.NodeFromWorldPoint(current);
        Node startNode = grid.NodeFromWorldPoint(startPoint);
    }

    public void a_star(Vector3 visitedPoint, Vector3 goalPoint) 
    {
        
        Queue<Vector3> nodesPos = new Queue<Vector3>();
        List<Vector3> discovredPos = new List<Vector3>();
        nodesPos.Enqueue(visitedPoint);
        discovredPos.Add(visitedPoint);
        
        bool isFull= false;
        while (!isFull) 
        {
            Vector3 current = nodesPos.Dequeue();

        //    for (int next = 0; next < graph.neightbours; next++)
          //  {
           // }
            
          
            
         
        }
       

    }
}
