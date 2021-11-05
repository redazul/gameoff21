using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    public int score = 0;
    public MonoBehaviour GameManager;
    public Text highscorenumbertext;
    public Text highscoretext;
    public Text New;
    public Text uiText;
    public MonoBehaviour Trigger;
    public bool hasReset;
    public bool isLevel;
    public Text Menuhighscoretext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            isLevel = false;
        }else
        {
            isLevel = true;
        }
        if (isLevel)
        {
            
        }
        if (hasReset)
        {
            highscorenumbertext.text = "0";
            New.gameObject.SetActive(false);
        }
        if (score > PlayerPrefs.GetInt("HIGHSCORE", 0)&&!hasReset&&isLevel)
        {
            New.gameObject.SetActive(true);
            highscoretext.text = "High Score : ".ToString();
            PlayerPrefs.SetInt("HIGHSCORE" , score);
            highscorenumbertext.text = score.ToString();
        }
        else if (isLevel)
        {
            highscoretext.text = "High Score : ".ToString();
            highscorenumbertext.text = PlayerPrefs.GetInt("HIGHSCORE").ToString();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highscorenumbertext.text = "0";
        hasReset = true;
    }
}
