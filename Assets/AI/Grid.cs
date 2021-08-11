using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public LayerMask NotWalkable;
    public Vector2 gridWorldSize;
    public float nodeRadius;

    Node[,] grid;

    float nodeDiameter;
    int GridSizeX, GridSizeY;

    public Transform player;


    

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;


        GridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        GridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();


       
    }

    void CreateGrid()
    {
        grid = new Node[GridSizeX, GridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;
        for (int x = 0; x < GridSizeX; x++)
        {
            for (int y = 0; y < GridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool walkable = !Physics.CheckSphere(worldPoint, nodeRadius, NotWalkable);
                grid[x, y] = new Node(walkable, worldPoint);
               
            }

        }
    }


    public Node NodeFromWorldPoint(Vector3 worldPosition) 
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);
        print("PERCENT X " + percentX);
        print("PERCENT Y " + percentX);
        int x = Mathf.RoundToInt((GridSizeX- 1) * percentX);
        int y = Mathf.RoundToInt((GridSizeY - 1) * percentY);
        print("X AXIS-> " + x);
        print("Y AXIS-> " + y);
        return grid[x, y];

    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

        if (grid != null)
        {
            Node playerNode = NodeFromWorldPoint(player.position);
            foreach (var n in grid)
            {
               
                Gizmos.color = (n.Walkable) ? Color.white : Color.red;
                if (playerNode == n) 
                {
                    Gizmos.color = Color.cyan;
                }
                    Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - 0.1f));
            }
        }

    }
}
