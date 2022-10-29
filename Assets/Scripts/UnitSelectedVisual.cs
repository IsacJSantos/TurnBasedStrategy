using UnityEngine;
using System;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField]
    Unit unit;

    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        UpdateVisual();
    }

    private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs args)
    {
        UpdateVisual();
    }

    void UpdateVisual()
    {
        meshRenderer.enabled = UnitActionSystem.Instance.GetSelectedUnit() == unit;
    }

}
