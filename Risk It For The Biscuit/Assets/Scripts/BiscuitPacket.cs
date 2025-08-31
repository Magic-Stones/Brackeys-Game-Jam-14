using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class BiscuitPacket : MonoBehaviour
{
    bool isInteracted = false;

    Sprite sprite;
    ScoreSystem scoreSystem;
    GameLoop gameLoop;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        scoreSystem = GameObject.Find("Game Manager").GetComponent<ScoreSystem>();
        gameLoop = GameObject.Find("Game Manager").GetComponent<GameLoop>();
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
        BiscuitTable table = GetComponentInParent<BiscuitTable>();

        if (biscuit.name.Equals(table.GetPfGoodBiscuit.name))
        {
            if (mouseButtonIndex == 0)
            {
                if (!biscuit.activeSelf) biscuit.SetActive(true);
                scoreSystem.ChangeScore(1);
            }
            else
            {
                gameObject.SetActive(false);
                scoreSystem.ChangeScore(-1);
            }
        }
        else
        {
            if (mouseButtonIndex == 1)
            {
                gameObject.SetActive(false);
                scoreSystem.ChangeScore(1);
            }
            else
            {
                if (!biscuit.activeSelf) biscuit.SetActive(true);
                scoreSystem.ChangeScore(-1);
            }
        }

        isInteracted = true;
        gameLoop.InteractPlate();
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
