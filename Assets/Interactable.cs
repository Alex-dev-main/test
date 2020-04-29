using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private bool hasInteracted;
    private bool isDisplayingEngage;

    public virtual void Test()
    {
        Debug.Log("Interacting with base class.");
    }

    public virtual void Interact()
    {
        if (!hasInteracted)
        {
            Debug.Log("Interacting with base class.");
            hasInteracted = true;
        }
    }

    public virtual void DisplayEngage(bool displayEngage)
    {
        if (!isDisplayingEngage)
        {
            Debug.Log("Interacting with base class.");
            isDisplayingEngage = true;
        }
    }
}
