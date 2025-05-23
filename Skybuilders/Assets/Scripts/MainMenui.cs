using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenui : MonoBehaviour
{

    public GameObject menuOne;
    public GameObject glossaryMenu;
    public GameObject optionsMenu;
    public GameObject playMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuOne.SetActive(true);
        playMenu.SetActive(false);
        glossaryMenu.SetActive(false);
        optionsMenu.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        playMenu.SetActive(true);
        menuOne.SetActive(false);
    }

    public void GlossaryButton()
    {
        glossaryMenu.SetActive(true);
        menuOne.SetActive(!false);
    }

    public void OptionsButton()
    {
        menuOne.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        menuOne.SetActive(true);
        playMenu.SetActive(false);
        glossaryMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void ContinueButton()
    {

    }

    public void LevelButton()
    {

    }

    public void GameStartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
