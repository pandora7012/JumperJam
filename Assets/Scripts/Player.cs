using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private GameObject mouse;
    public static bool gameIsOver; 
    public static int score  ;
    private SpriteRenderer spriteRenderer;
    // player sprite 
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

    public DATA data;

    public AudioSource audio;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        gameIsOver = false;
        score = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprite1 = data.characters[PlayerPrefs.GetInt("character")].die;
        sprite2 = data.characters[PlayerPrefs.GetInt("character")].idle;
        sprite3 = data.characters[PlayerPrefs.GetInt("character")].jump;
        
            audio.Play();
        audio.volume = PlayerPrefs.GetFloat("audio");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerControl();
        scoreUpdater();
        spriteHandle();
        outofBound();
    }

    private void PlayerControl()
    {
        Vector2 vvel = mouse.GetComponent<Rigidbody2D>().velocity;
        rigidbody.velocity = new Vector2(vvel.x * 10, rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platformer")
            rigidbody.AddForce(new Vector2(0, 400f));
        if (collision.collider.name == "GameOver" || collision.collider.tag == "Enemy")
        {
            spriteRenderer.sprite = sprite1;
            StartCoroutine(waitfors(3));
            Time.timeScale = 0;
            gameIsOver = true;
            highScorehandle();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            int p = PlayerPrefs.GetInt("coin");
            Destroy(collision.gameObject);
            p++;
            PlayerPrefs.SetInt("coin", p);

        }
    }

    private void highScorehandle()
    {
        int f = PlayerPrefs.GetInt("first");
        int s = PlayerPrefs.GetInt("second");
        int t = PlayerPrefs.GetInt("third");
        if (f < score)
        {
            PlayerPrefs.SetInt("first", score);
            return; 
        }
        else if ( s < score)
        {
            PlayerPrefs.SetInt("second", score);
            return;
        }
        else if (t < score)
        {
            PlayerPrefs.SetInt("third", score);
            return;
        }
    }
    private IEnumerator waitfors (float s)
    {
        yield return new WaitForSeconds(s);
       
    }

    private void outofBound ()
    {
        if (transform.position.x <= -3 && rigidbody.velocity.x < 0)
        {
            transform.position = new Vector2(3, transform.position.y);
        }
        if (transform.position.x >= 3 && rigidbody.velocity.x > 0)
        {
            transform.position = new Vector2(-3, transform.position.y);
        }
    }
    private void scoreUpdater()
    {
        score = Mathf.Max(score, (int)gameObject.transform.position.y );
    }

    private void spriteHandle()
    {
        if ( rigidbody.velocity.y > 0 )
            spriteRenderer.sprite = sprite3; 
        else if (rigidbody.velocity.y < 0 )
            spriteRenderer.sprite = sprite2;
    }
       
    
}
