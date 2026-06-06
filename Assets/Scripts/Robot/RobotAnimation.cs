using DG.Tweening;
using UnityEngine;

public class RobotAnimation : MonoBehaviour
{
    [SerializeField] private RobotBuilder _builder;

    private void Start()
    {
        _builder.Model.OnTestAction += PlayAnimation;
    }

    private void PlayAnimation()
    {
        transform.DOKill();
        transform.DOJump(transform.position, 2f, 1, 0.6f);
        transform.DORotate(new Vector3(0, 360, 0), 0.6f, RotateMode.FastBeyond360);
    }
}
