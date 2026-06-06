using System.Collections.Generic;
using UnityEngine;

public class RobotBuilder : MonoBehaviour
{
    [Header("Available Parts")]
    [SerializeField] private List<RobotPartData> _heads;
    [SerializeField] private List<RobotPartData> _bodies;
    [SerializeField] private List<RobotPartData> _legs;

    [Header("Slots")]
    [SerializeField] private Transform _headSlot;
    [SerializeField] private Transform _bodySlot;
    [SerializeField] private Transform _legsSlot;

    private GameObject _currentHeadGO;
    private GameObject _currentBodyGO;
    private GameObject _currentLegsGO;

    public RobotModel Model { get; private set; }

    private void Awake()
    {
        Model = new RobotModel();
        Model.SetHead(_heads[0]);
        Model.SetBody(_bodies[0]);
        Model.SetLegs(_legs[0]);
        Model.OnChanged += RebuildVisuals;
        Model.OnColorChanged += ApplyColors;
        RebuildVisuals();
    }

    private void RebuildVisuals()
    {
        SpawPart(ref _currentHeadGO, Model.CurrentHead, _headSlot);
        SpawPart(ref _currentBodyGO, Model.CurrentBody, _bodySlot);
        SpawPart(ref _currentLegsGO, Model.CurrentLegs, _legsSlot);
        ApplyColors();
    }
    private void SpawPart(ref GameObject current, RobotPartData data, Transform slot)
    {
        Debug.Log($"data: {data}, prefab: {data?.PartPrefab}, slot: {slot}");
        if (current != null) Destroy(current);
        current = Instantiate(data.PartPrefab, slot);
    }
    private void ApplyColors()
    {
        ApplyColorToPart(_currentHeadGO, Model.HeadColor);
        ApplyColorToPart(_currentBodyGO, Model.BodyColor);
        ApplyColorToPart(_currentLegsGO, Model.LegsColor);
    }
    private void ApplyColorToPart(GameObject go, Color color)
    {
        if(go == null) return;
        foreach (var r in go.GetComponentsInChildren<Renderer>())
            r.material.color = color;
    }

    public List<RobotPartData> GetHeads() => _heads;
    public List<RobotPartData> GetBodies() => _bodies;
    public List<RobotPartData> GetLegs() => _legs;
}
