public class Movement
{
    private const float _MOVEMENT_SPEED = 30.0f;

    private UnityEngine.Rigidbody2D _targetRb;
    private UnityEngine.Transform _targetTr;

    public Movement(UnityEngine.Rigidbody2D rb, UnityEngine.Transform targetTr)
    {
        _targetRb = rb;
        _targetTr = targetTr;
    }

    ~Movement()
    {
        _targetRb = null;
        _targetTr = null;
    }

    public void MoveByDir(float hor, float ver)
    {
        UnityEngine.Vector2 dir = new UnityEngine.Vector2(hor, ver);
        float speed = _MOVEMENT_SPEED * UnityEngine.Time.deltaTime;
        _targetRb.MovePosition((UnityEngine.Vector2)_targetTr.position + dir * speed);
    }
}
