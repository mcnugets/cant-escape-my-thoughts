using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public bool Walkable;
    public bool NotWalkable;
    public Vector3 worldPosition;

    public Node(bool walkable, Vector3 worldposition) 
    {
        Walkable = walkable;
        worldPosition = worldposition;


    }
}
