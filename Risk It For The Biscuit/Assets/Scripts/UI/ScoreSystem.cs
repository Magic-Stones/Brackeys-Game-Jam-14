using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    int score = 0;
    TextMeshProUGUI m_ScoreUI;

    void Awake()
    {
        m_ScoreUI = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScore(int amount)
    {
        score += amount;

        if (score < 0) score = 0;

        m_ScoreUI.text = score.ToString();
    }
}
