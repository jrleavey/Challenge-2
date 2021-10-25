using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    private bool isGrounded;

    private Rigidbody2D rd2d;

    public float speed;

    private int scoreValue = 0;

    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioSource _audioSource2;
    [SerializeField]
    private AudioSource _audioSource3;

    [SerializeField]
    public float jumpVelocity = 20;

    [SerializeField]
    private AudioClip _PickupSound;
    [SerializeField]
    private AudioClip _music;
    [SerializeField]
    private AudioClip _winmusic;
    [SerializeField]
    private Text countText;
    [SerializeField]
    private Text wintext;
    [SerializeField]
    private Text loseText;
    [SerializeField]
    private Text livesText;
    [SerializeField]
    private int _lives = 3;
    private int Scorecount;
    private int Livescount;

    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        rd2d = GetComponent<Rigidbody2D>();
        Scorecount = 0;
        Livescount = 3;
        SetCountText();
        SetLivesText();
        wintext.text = "";
        loseText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _anim.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            _anim.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _anim.SetInteger("State", 2);
            speed = 15;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _anim.SetInteger("State", 0);
            speed = 10;

        }
        if (Input.GetKeyDown(KeyCode.Space))
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.up * jumpVelocity;
                isGrounded = false;
            }
        Vector3 characterscale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterscale.x = -0.5f;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterscale.x = 0.5f;
        }
        transform.localScale = characterscale;
    }
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, 0 * speed));
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            Scorecount = Scorecount + 1;
            SetCountText();
            AudioSource.PlayClipAtPoint(_PickupSound, transform.position);
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.tag == "Enemy")
        {
            Livescount = Livescount - 1;
            _lives -= 1;
            SetLivesText();
            Destroy(collision.collider.gameObject);
        }
    }
    void SetCountText()
    {
        countText.text = "Score: " + Scorecount.ToString();
        if (Scorecount >= 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + Livescount.ToString();
        if (_lives < 1)
        {
            loseText.text = "You Lose!";
            GameOverSequence();
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
    }
    public void GameOverSequence()
    {
        loseText.gameObject.SetActive(true);
    }


}
