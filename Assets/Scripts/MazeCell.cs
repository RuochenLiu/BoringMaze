using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    private MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];

    private int initializedEdgeCount;

    public IntVector2 coordinates;

    public  MazeCellEdge GetEdge(MazeDirection direction)
    {
        return edges[(int)direction];
    }

    public void SetEdge(MazeDirection direction, MazeCellEdge edge)
    {
        edges[(int)direction] = edge;
        initializedEdgeCount += 1;
    }

    public bool IsFullyInitialized()
    {
        
        return initializedEdgeCount == MazeDirections.Count;
    }

    public MazeDirection RandomUninitializedDirection()
    {
        int skips = Random.Range(0, MazeDirections.Count - initializedEdgeCount);
        for (int i = 0; i < MazeDirections.Count; i++)
        {
            if (edges[i] == null)
            {
                if (skips == 0)
                {
                    return (MazeDirection)i;
                }
                skips -= 1;
            }
        }
        throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
    }
}
