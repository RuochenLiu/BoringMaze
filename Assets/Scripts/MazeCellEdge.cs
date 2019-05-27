using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MazeCellEdge : MonoBehaviour
{
    public MazeCell cell, otherCell;

    public MazeDirection direction;

    public void Initialize(MazeCell cell, MazeCell otherCell, MazeDirection direction)
    {
        this.cell = cell;
        this.otherCell = otherCell;
        this.direction = direction;

        cell.SetEdge(this.direction, this);
        transform.parent = cell.transform;
        Vector3 edgeOffset = new Vector3(0.5f * direction.ToIntVector2().x, 0.5f, 0.5f * direction.ToIntVector2().z);
        transform.localPosition = edgeOffset;
        transform.localRotation = direction.ToRotation();

    }
}
