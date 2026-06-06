using UnityEngine;

public class RobotModel
{
    public RobotPartData CurrentHead { get; private set; }
    public RobotPartData CurrentBody { get; private set; }
    public RobotPartData CurrentLegs { get; private set; }
    public Color HeadColor { get; private set; } = Color.white;
    public Color BodyColor { get; private set; } = Color.white;
    public Color LegsColor { get; private set; } = Color.white;

    public int TotalWeight => CurrentHead.Weight + CurrentBody.Weight + CurrentLegs.Weight;
    public int TotalPower => CurrentHead.Power + CurrentBody.Power + CurrentLegs.Power;

    public event System.Action OnChanged;
    public event System.Action OnColorChanged;

    public void SetHead(RobotPartData data) { CurrentHead = data; OnChanged?.Invoke(); }
    public void SetBody(RobotPartData data) { CurrentBody = data; OnChanged?.Invoke(); }
    public void SetLegs(RobotPartData data) { CurrentLegs = data; OnChanged?.Invoke(); }

    public void SetHeadColor(Color color) { HeadColor = color; OnColorChanged?.Invoke(); }
    public void SetBodyColor(Color color) { BodyColor = color; OnColorChanged?.Invoke(); }
    public void SetLegsColor(Color color) { LegsColor = color; OnColorChanged?.Invoke(); }
}

