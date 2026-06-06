using UnityEngine;

[CreateAssetMenu(fileName = "RobotPartData", menuName = "Scriptable Objects/RobotPartData")]
public class RobotPartData : ScriptableObject
{
    [SerializeField] private string _partName;
    [SerializeField] private int _weight;
    [SerializeField] private int _power;
    [SerializeField] private GameObject _partPrefab;

    public string PartName => _partName;
    public int Weight => _weight;
    public int Power => _power;
    public GameObject PartPrefab => _partPrefab;
}
