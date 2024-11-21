using UnityEngine;

public class Wind : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IWindable windable = collision.gameObject.GetComponent<IWindable>();
        if (windable != null)
            windable.OnWinded();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IWindable windable = collision.gameObject.GetComponent<IWindable>();
        if (windable != null)
            windable.OnWinding();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IWindable windable = collision.gameObject.GetComponent<IWindable>();
        if (windable != null)
            windable.OnStopWinding();
    }
}
