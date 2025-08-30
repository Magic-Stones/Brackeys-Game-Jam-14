using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    RaycastHit2D ray;

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

        ray.collider.GetComponent<BiscuitPacket>().Interact(0);
    }

    public void OnClickRight(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!ray.collider) return;

        ray.collider.GetComponent<BiscuitPacket>().Interact(1);
    }
}
