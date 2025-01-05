using StarterAssets;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] StarterAssetsInputs input;
    [SerializeField] float costSprintStamina;

    bool triggered;

    void Update()
    {
        if(input.sprint)
        {
            if(!triggered) 
            {
                PlayerStamina.Instance.ModifyConsumeStamina(costSprintStamina);
                triggered = true;
            }
        }
        else
        {
            if(triggered) 
            {
                PlayerStamina.Instance.ModifyConsumeStamina(-costSprintStamina);
                triggered = false;
            }
        }
    }
}
