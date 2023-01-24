

using System.Collections.Generic;
using Unity.VisualScripting;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private List<Unit> unitList;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit>();
    }

    public void AddUnit(Unit unit)
    {
        this.unitList.Add(unit);
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }


    public void RemoveUnit(Unit unit)
    {
        unitList.Remove(unit);
    }

    public override string ToString()
    {
        string unitName = "";
        foreach (var unit in unitList)
        {
            unitName += unit != null ? unit.name + "\n" : "";
        }
        return gridPosition.ToString() + unitName;
    }
}
