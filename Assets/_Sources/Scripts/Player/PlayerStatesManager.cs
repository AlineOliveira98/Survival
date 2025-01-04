using UnityEngine;

public class PlayerStatesManager : MonoBehaviour
{
    public PlayerState hungerState;
    public PlayerState thirstyState;

    void Start()
    {
        Initialise();
    }

    void Update()
    {
        hungerState.UpdateState();
        thirstyState.UpdateState();
    }

    public void Initialise()
    {
        hungerState.Initialise();
        thirstyState.Initialise();
    }
}