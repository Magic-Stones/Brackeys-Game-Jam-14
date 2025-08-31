using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    int score = 0;
    TMP_Text m_ScoreUI;
    public int GetScore { get => score; }

    float colorTransitionDuration = 0.75f;

    void Awake()
    {
        m_ScoreUI = GameObject.Find("Score").GetComponent<TMP_Text>();
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

        StartCoroutine(ScoreColorTransition(amount > 0));
    }

    private IEnumerator ScoreColorTransition(bool isPlusAmount)
    {
        Color startColor = Color.black;
        if (isPlusAmount) startColor = Color.green;
        else startColor = Color.red;

        Color endColor = Color.white;
        float elapsedTime = 0f;

        m_ScoreUI.color = startColor;

        while (elapsedTime < colorTransitionDuration)
        {
            m_ScoreUI.color = Color.Lerp(startColor, endColor, elapsedTime / colorTransitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        m_ScoreUI.color = endColor;
    }
}
