using UnityEngine;

public class UserInput
{

    public event System.Action<float, float> OnMovementTriggered = default;
    public event System.Action OnCandleActiveStatusInterracted = default;
    public event System.Action OnCandleProtectionStatusInterracted = default;

    public UserInput()
    {
    }

    ~UserInput()
    {
    }

    public void ListenMovementInput()
    {
        float horDir = UnityEngine.Input.GetAxisRaw("Horizontal");
        float verDir = UnityEngine.Input.GetAxisRaw("Vertical");
        OnMovementTriggered?.Invoke(horDir, verDir);
    }

    public void ListenCandleInterraction()
    {
        if (Input.GetKeyDown(KeyCode.R))
            OnCandleActiveStatusInterracted?.Invoke();

        if (Input.GetKey(KeyCode.E))
            OnCandleProtectionStatusInterracted?.Invoke();
    }
}
