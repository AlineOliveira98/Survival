using UnityEngine;

public class PlayerStatesManager : MonoBehaviour
{
    public PlayerState hungerState;
    public PlayerState thirstyState;

    #region Singleton
    public static PlayerStatesManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        
        // DontDestroyOnLoad(gameObject);
    }
    #endregion

    void Start()
    {
        Initialise();
    }

    public void Initialise()
    {
        hungerState.Initialise();
        thirstyState.Initialise();
    }

    void Update()
    {
        hungerState.UpdateState();
        thirstyState.UpdateState();
    }
    
    public void UpdateHunger(float amount) => hungerState.Modify(amount);
    public void UpdateThirsty(float amount) => thirstyState.Modify(amount);
}