using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{

    public GameObject endMenu;
    public GameObject gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.GetComponent<GameManager>().canInput = false;
            endMenu.SetActive(true);
            Time.timeScale = 0f;
            if (gameManager.GetComponent<GameManager>().coinsCollected == 1)
            {
                endMenu.transform.GetChild(9).gameObject.SetActive(true);
            }
            //if (gameManager.GetComponent<GameManager>().boolforusingcorrectblock == true)
            //{
            //    endMenu.transform.GetChild(10).gameObject.SetActive(true);
            //}
        }
    }
}
