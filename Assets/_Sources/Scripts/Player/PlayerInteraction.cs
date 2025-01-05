using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float interactionRange;
    Interactable currentInteractable;
    Camera mainCamera; 

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = new(mainCamera.transform.position, mainCamera.transform.forward);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, interactionRange))
        {
            if(hitInfo.transform.TryGetComponent(out Interactable interactableObj))
            {
                if(currentInteractable != interactableObj)
                {
                    DisableCurrentInteractable();
                }

                currentInteractable = interactableObj;
                interactableObj.Focus();
            }
            else
            {
                DisableCurrentInteractable();
            }
        }
        else
        {
            DisableCurrentInteractable();
        }
        
        if(Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void DisableCurrentInteractable()
    {
        if(currentInteractable != null)
        {
            currentInteractable.UnFocus();
            currentInteractable = null;
        }
    }
}
