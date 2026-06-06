using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RobotUI : MonoBehaviour
{
    [SerializeField] private RobotBuilder _builder;
    [SerializeField] private TMP_Text _weightText;
    [SerializeField] private TMP_Text _powerText;
    [SerializeField] private Button _animButton;

    private int _headIndex, _bodyIndex, _legsIndex;

    private void Start()
    {
        _builder.Model.OnChanged += UpdateStats;
    }

    private void UpdateStats()
    {
        _weightText.text = $"Weight: {_builder.Model.TotalWeight}";
        _powerText.text = $"Power: {_builder.Model.TotalPower}";
    }
    public void NextHead()
    {
        _headIndex = (_headIndex + 1) % _builder.GetHeads().Count;
        _builder.Model.SetHead(_builder.GetHeads()[_headIndex]);
    }
    public void NextBody()
    {
        _bodyIndex = (_bodyIndex + 1) % _builder.GetBodies().Count;
        _builder.Model.SetBody(_builder.GetBodies()[_bodyIndex]);
    }
    public void NextLegs()
    {
        _legsIndex = (_legsIndex + 1) % _builder.GetLegs().Count;
        _builder.Model.SetLegs(_builder.GetLegs()[_legsIndex]);
    }

    //Methods to change color
    
    public void SetHeadRed() => _builder.Model.SetHeadColor(Color.red); //head
    public void SetHeadBlue() => _builder.Model.SetHeadColor(Color.blue);
    public void SetHeadGreen() => _builder.Model.SetHeadColor(Color.green);
    public void SetBodyRed() => _builder.Model.SetBodyColor(Color.red); //body
    public void SetBodyBlue() => _builder.Model.SetBodyColor(Color.blue);
    public void SetBodyGreen() => _builder.Model.SetBodyColor(Color.green);
    public void SetLegsRed() => _builder.Model.SetLegsColor(Color.red); //legs
    public void SetLegsBlue() => _builder.Model.SetLegsColor(Color.blue);
    public void SetLegsGreen() => _builder.Model.SetLegsColor(Color.green);

    public void OnTestButton() => _builder.Model.TriggerTest();
}
