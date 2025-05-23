using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public GameObject gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager.GetComponent<GameManager>().coinsCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.GetComponent<GameManager>().coinsCollected = gameManager.GetComponent<GameManager>().coinsCollected + 1;
        Destroy(gameObject);
    }
}
