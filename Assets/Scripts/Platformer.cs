using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{
    // Update is called once per frame

    private Player player;
    private GameObject cam;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject enemyStaticPrefab;
    [SerializeField] private GameObject enemyDinamicPrefab;
    [SerializeField] private GameObject enemyFlyPrefab;
    private int rand;
    public Sprite[] sprites;

    private void Awake()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("MAP")];
        player = FindObjectOfType<Player>();
        cam = GameObject.Find("Main Camera");
        rand = Random.Range(0, 100);
        if (gameObject.transform.position.y > 2)
        {
            if (rand < 10) Instantiate(enemyStaticPrefab, this.transform.position, Quaternion.identity);
            if (rand > 10 && rand < 30) Instantiate(coinPrefab, this.transform.position, Quaternion.identity);
        }
    }
    void FixedUpdate()
    {
        interactWithPlayer();
        selfDestroy();
    }

    private void interactWithPlayer()
    {
        if (player.transform.position.y <= gameObject.transform.position.y && player.GetComponent<Rigidbody2D>().velocity.y > 0)
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        else if (player.transform.position.y > gameObject.transform.position.y && player.GetComponent<Rigidbody2D>().velocity.y <= 0)
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void selfDestroy()
    {
        if (gameObject.transform.position.y < cam.transform.position.y - cam.GetComponent<Camera>().orthographicSize)
        {
            Destroy(gameObject);
        }
    }
}
