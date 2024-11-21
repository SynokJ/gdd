using UnityEngine;

public class Drops : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IWettable wettable = collision.gameObject.GetComponent<IWettable>();
        if (wettable != null)
            wettable.OnWetted();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IWettable wettable = collision.gameObject.GetComponent<IWettable>();
        if (wettable != null)
            wettable.OnWetted();
    }
}
