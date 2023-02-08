using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    MoveAction moveAction;

    private GridPosition gridPosition;
    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
    }
    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);
    }

    private void Update()
    {       

        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if (gridPosition != newGridPosition) 
        {
            LevelGrid.Instance.UnitMoveGridPosition(this,gridPosition,newGridPosition);
            gridPosition = newGridPosition;
        }
    }

    public MoveAction GetMoveAction() => moveAction;

    public GridPosition GetGridPosition() => gridPosition;

}
