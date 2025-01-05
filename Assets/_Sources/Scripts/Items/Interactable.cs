using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] UnityEvent OnFocus;
    [SerializeField] UnityEvent OnUnFocus;
    [SerializeField] UnityEvent OnInteract;

    protected virtual void Start()
    {
        UnFocus();
    }

    public virtual void Focus()
    {
        OnFocus.Invoke();
    }

    public virtual void UnFocus()
    {
        OnUnFocus.Invoke();
    }

    public virtual void Interact()
    {
        OnInteract.Invoke();
    }
}
