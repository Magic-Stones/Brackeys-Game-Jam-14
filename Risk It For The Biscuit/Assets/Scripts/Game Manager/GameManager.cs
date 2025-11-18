using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int platesInteracted = 0;
    [SerializeField] GameObject pnlGameOver;
    ScoreSystem scoreSystem;

    void Awake()
    {
        pnlGameOver = GameObject.Find("Canvas").transform.Find("Game Over").gameObject;
        scoreSystem = GetComponent<ScoreSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractPlate()
    {
        platesInteracted++;

        int stopGameCondition = 9;
        if (platesInteracted == stopGameCondition)
        {
            Invoke("GameOver", 3f);
        }
    }

    private void GameOver()
    {
        pnlGameOver.SetActive(true);
        TMP_Text m_TotalScoreUI = GameObject.Find("Total Score").GetComponent<TMP_Text>();
        m_TotalScoreUI.text = scoreSystem.GetScore.ToString();
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
