using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float dirX, moveSpeed = 5f;
    private static int count = 0;
    public Text countText;
    public Text trgtText;
    private int target;
    public Vector3 spawn_postition;
    public Transform playerTransform;

    public GameObject gear;
    public GameObject badGear;

    private int badSpawnTime;
    private int spawnTime;
    public float fallSpeed = 40.0f;

    private float timer = 0;
    private float timerTwo = 0;
    private int randomNumber;


    public Sprite forward_sprite;
    public Sprite left_sprite;
    public Sprite right_sprite;
    private SpriteRenderer spriteRenderer;

    /* start nick's mess */
    public GameObject scoreManager;
    public GameObject scoreTracker;
    public GameObject currentScoreTop;

    public mg_transition_anim transition_Anim;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = scoreManager.GetComponent<score_handler>().getTargetOne();
        setCountText();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
       
    }

    public void set_spawn_times(int good, int bad)
    {
        spawnTime = good;
        badSpawnTime = bad;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

        timer += Time.deltaTime;

        if (timer > spawnTime)
        {
            spawnRandom();
            timer = 0;
        }


        timerTwo += Time.deltaTime;

        if (timerTwo > badSpawnTime)
        {
            spawnBadrandom();
            timerTwo = 0;
        }



        if ((Input.GetKey("up") || Input.GetKey("space")) && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 100f);

        if (playerTransform.position.y < -3.5)
        {
            playerTransform.position = spawn_postition;
        }


        //sprite changes
        if (Input.GetKey(KeyCode.LeftArrow))
            spriteRenderer.sprite = left_sprite;
        else if (Input.GetKey(KeyCode.RightArrow))
            spriteRenderer.sprite = right_sprite;
        else
            spriteRenderer.sprite = forward_sprite;

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

   

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Gear"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            scoreTracker.GetComponent<score_tracker>().spin_wheel_positive();
            setCountText();
        }

        if (other.gameObject.CompareTag("Evil"))
        {
            other.gameObject.SetActive(false);
            if(count != 0)
            count = count -1;
            if (count == 0)
                count = 0;
            scoreTracker.GetComponent<score_tracker>().spin_wheel_negative();
            setCountText();
        }
    }

    void setCountText()
    {
        var txt = currentScoreTop.GetComponent<Text>();
        txt.text = count.ToString();

        if (transition_Anim.get_mg() == 0)
        {
            if (count >= 5) transition_Anim.transition_true();
        }
        else if (transition_Anim.get_mg() == 3)
        {
            if (count >= 15) transition_Anim.transition_true();
        }
        else if (transition_Anim.get_mg() == 6)
        {
            if (count >= 25) transition_Anim.transition_true();
        }

        //if (count >= target)
        //{
            //winText.text = "You win!";
            //Invoke("changeScene", 1.5f);
        //}
    }

    void changeScene() {
        SceneManager.LoadScene("mg_360pong");
    }

    public void spawnRandom()
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(226, 654), Random.Range(675, 700), Camera.main.farClipPlane / 2));
        Instantiate(gear, screenPosition, Quaternion.identity);
    }

    public void spawnBadrandom()
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(226, 654), Random.Range(750, 800), Camera.main.farClipPlane / 2));
        Instantiate(badGear, screenPosition, Quaternion.identity);
    }
}
