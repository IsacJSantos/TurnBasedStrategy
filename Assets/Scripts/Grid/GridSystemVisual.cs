using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{
    [SerializeField]
    private Transform gridSystemVisualSinglePrefab;

    private GridSystemVisualSingle[,] gridSystemVisualSingleArray;

    public static GridSystemVisual Instance { get; private set; }
    private int gridWidth;
    private int gridHeight;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's moro than one UnitActionSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        gridWidth = LevelGrid.Instance.GetWidth();
        gridHeight = LevelGrid.Instance.GetHeight();

        gridSystemVisualSingleArray = new GridSystemVisualSingle[
            gridWidth,
            gridHeight
            ];

        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                Transform gridSystemVisualSingleTransform =
                    Instantiate(gridSystemVisualSinglePrefab, LevelGrid.Instance.GetWorldPosition(gridPosition), Quaternion.identity);
                gridSystemVisualSingleArray[x, z] = gridSystemVisualSingleTransform.GetComponent<GridSystemVisualSingle>();
            }
        }
    }

    private void Update()
    {
        UpdateGridVisual();
    }

    public void HideAllGridPositions()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                gridSystemVisualSingleArray[x, z].Hide();
            }
        }
    }

    public void ShowGridPositionList(List<GridPosition> gridPositionList)
    {
        int count = gridPositionList.Count;
        for (int i = 0; i < count; i++)
        {
            gridSystemVisualSingleArray[gridPositionList[i].x, gridPositionList[i].z].Show();
        }
    }

    public void UpdateGridVisual() 
    {
        Instance.HideAllGridPositions();
        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();
        Instance.ShowGridPositionList(selectedUnit.GetMoveAction().GetValidActionGridPositionList());
    }
}
