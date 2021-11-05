using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Canvas GameOverCanvas;
    public GameObject everything;
    public bool isGameOver = false;
    public Camera cam;
    public int score = 0;
    public bool isLevel;
    public GameObject PauseMenu;
    public bool isPaused = false;
    public bool isResumed = false;
    public AudioSource BackgroundAudio;
    public Text PauseMenuScoreText;
    public AudioSource Button;
    public Button MuteButton;
    public Button UnmuteButton;
    public bool isMuted = false;

    private void Update()
    {
        if (AudioListener.volume == 0)
        {
            isMuted = true;
        }
        else if (AudioListener.volume == 1)
        {
            isMuted = false;
        }

        if (isMuted && !isLevel)
        {
            MuteButton.image.enabled = false;
            UnmuteButton.image.enabled = true;
        }
        else if(!isMuted && !isLevel)
        {
            MuteButton.image.enabled = true;
            UnmuteButton.image.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.P) && isLevel && !isGameOver)
        {
            Pause();
        }

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            isLevel = false;
        }

        if (isPaused && !isGameOver)
        {
            PauseMenuScoreText.gameObject.SetActive(true);
        }

        if (isResumed)
        {
            PauseMenuScoreText.gameObject.SetActive(false);
        }

        if (isLevel)
        {
            
        }
    }

    public void GameOver()
    { 
        GameOverCanvas.gameObject.SetActive(true);
        everything.SetActive(false);
        isGameOver = true;
        cam.gameObject.GetComponent<AudioSource>().enabled = false;
    }

    public void Pause()
    {
        BackgroundAudio = GetComponent<AudioSource>();
        BackgroundAudio.Pause();
        Time.timeScale = 0f;
        isPaused = true;
        isResumed = false;
        PauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Button = GetComponent<AudioSource>();
        Button.Play();
        new WaitForSeconds(0.5f);
        BackgroundAudio.Play();
        Time.timeScale = 1;
        isPaused = false;
        isResumed = true;
        PauseMenu.SetActive(false);
    }

    public void Mute ()
    {
        AudioListener.volume = 0;
        isMuted = true;
    }

    public void Unmute ()
    {
        AudioListener.volume = 1;
        isMuted = false;
    }

    private IEnumerator Wait ()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
