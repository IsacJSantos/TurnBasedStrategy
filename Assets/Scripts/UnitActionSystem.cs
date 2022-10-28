using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField]
    private Unit selectedUnit;

    [SerializeField]
    private LayerMask unitLayerMask;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (TryHandleUnitSelection()) return;
            selectedUnit.Move(MouseWorld.GetPosition());
        }
    }

    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, unitLayerMask))
        {
            if (hit.transform.TryGetComponent(out Unit unit))
            {
                selectedUnit = unit;
                return true;
            }

        }

        return false;
    }
}
