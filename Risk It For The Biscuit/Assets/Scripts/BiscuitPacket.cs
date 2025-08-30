using UnityEngine;

public class BiscuitPacket : MonoBehaviour
{
    bool isInteracted = false;

    Sprite sprite;
    BiscuitHandler handler;
    ScoreSystem scoreSystem;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        handler = GetComponentInParent<BiscuitHandler>();
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

    public void Interact(int mouseButtonIndex)
    {
        if (isInteracted) return;

        GameObject biscuit = transform.GetChild(0).gameObject;
        if (!biscuit.activeSelf) biscuit.SetActive(true);

        if (biscuit.name.Equals(handler.GetPfGoodBiscuit.name))
        {
            if (mouseButtonIndex == 0)
                scoreSystem.ChangeScore(1);
            else scoreSystem.ChangeScore(-1);
        }
        else
        {
            if (mouseButtonIndex == 1)
                scoreSystem.ChangeScore(1);
            else scoreSystem.ChangeScore(-1);
        }

        isInteracted = true;
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
