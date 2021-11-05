using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Functions : MonoBehaviour
{
    public AudioSource Button;
    public float ButtonWaitTime;
    public float ButtonStartWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Button = GetComponent<AudioSource>();
        ButtonStartWaitTime = ButtonWaitTime;
    }

    public void StartGame()
    {
        Button.Play();
        ButtonWaitTime -= Time.deltaTime;
        if (ButtonStartWaitTime <= 0)
        {
            ButtonWaitTime = ButtonStartWaitTime;
            SceneManager.LoadScene("Level");
        }
    }

    public void LoadMenu()
    {
        Button.Play();
        ButtonWaitTime -= Time.deltaTime;
        if (ButtonWaitTime <= 0) {
            ButtonWaitTime = ButtonStartWaitTime;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
