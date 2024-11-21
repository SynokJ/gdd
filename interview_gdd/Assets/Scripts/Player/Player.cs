using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Candle _candle;

    private Rigidbody2D _rb;
    private UserInput _input;
    private Movement _movement;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _input = new UserInput();
        _movement = new Movement(_rb, transform);
    }

    private void OnEnable()
    {
        _input.OnMovementTriggered += _movement.MoveByDir;
        _input.OnCandleActiveStatusInterracted += _candle.OnStateSwitched;
        _input.OnCandleProtectionStatusInterracted += _candle.SetProtectionStatus;
    }

    private void OnDisable()
    {
        _input.OnMovementTriggered -= _movement.MoveByDir;
        _input.OnCandleActiveStatusInterracted -= _candle.OnStateSwitched;
        _input.OnCandleProtectionStatusInterracted -= _candle.SetProtectionStatus;
    }

    private void Update()
    {
        _input.ListenMovementInput();
        _input.ListenCandleInterraction();
    }
}
