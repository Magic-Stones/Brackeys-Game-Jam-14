using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    RaycastHit2D ray;
    GameObject biscuit = null;

    CardHandler cardHandler;
    ScoreSystem scoreSystem;

    void Awake()
    {
        cardHandler = GameObject.Find("Card Handler").GetComponent<CardHandler>();
        scoreSystem = GameObject.Find("UI Manager").GetComponent<ScoreSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLeft(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!ray.collider) return;

        biscuit = ray.collider.transform.GetChild(0).gameObject;
        if (!biscuit.activeInHierarchy) biscuit.SetActive(true);
        else return;

        if (IsGoodBiscuit) 
            scoreSystem.ChangeScore(1);
        else 
            scoreSystem.ChangeScore(-1);
    }

    public void OnClickRight(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!ray.collider) return;

        biscuit = ray.collider.transform.GetChild(0).gameObject;
        if (!biscuit.activeInHierarchy) biscuit.SetActive(true);
        else return;

        if (!IsGoodBiscuit)
            scoreSystem.ChangeScore(1);
        else
            scoreSystem.ChangeScore(-1);
    }

    public bool IsGoodBiscuit
    {  
        get 
        { 
            if (biscuit.name.Equals(cardHandler.GetPfGoodBiscuit.name)) return true;
            else return false;
        } 
    }
}
