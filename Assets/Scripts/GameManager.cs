using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text playerHealth;
    public Text enemyCount;
    public Text Win;
    public Text Lose;

    public string PlayerHealthText;
    public string EnemyCountText;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var health = player.GetComponent<Player>().Health;
        PlayerHealthText = $"Player Health: {health}";
        int numEnemies = GameObject.FindGameObjectsWithTag("enemy").Length;
        EnemyCountText = $"Enemies: {numEnemies}";
        playerHealth.text = PlayerHealthText;
        enemyCount.text = EnemyCountText;

        if(health == 0)
        {
            Lose.gameObject.SetActive(true);
        }

        if(numEnemies == 0)
        {
            Win.gameObject.SetActive(true);
        }

    }
}
