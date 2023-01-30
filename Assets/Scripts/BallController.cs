using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public float speed = 0;
    public int playerIndex;

    private Transform respawnPoint;
    private MenuController menuController;
    private Rigidbody rigidbody;
    private ScoreHandler scoreHandler;
    public TextMeshProUGUI countText;
    private float movementX;
    private float movementY;
    private int count;
    private float jumpSpeed = 5;
    private bool onGround = true;
    private const int MAX_JUMP = 2;
    private int currentJump = 0;
    private int pickupsPerLevel = 0;
    
    void Start()
    {
        pickupsPerLevel = GameObject.FindGameObjectsWithTag("PickUp").Length;
        respawnPoint = GameObject.Find("RespawnPoint").transform;
        menuController = GameObject.Find("Canvas").GetComponent<MenuController>();
        scoreHandler = GameObject.Find("Canvas/CountPanel").GetComponent<ScoreHandler>();
        rigidbody = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            scoreHandler.Score += 1;
            SetCountText();
        }
        
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 movementVector = inputValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (scoreHandler.Score == pickupsPerLevel)
        {
            //winTextObject.SetActive(true);

            menuController.WinGame();
            Invoke("NextScene", 5f);
        }
    }

    void NextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && (onGround || MAX_JUMP > currentJump ))
        {
            rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            onGround = false;
            currentJump++;
        }
        rigidbody.AddForce((new Vector3(movementX,0,movementY))*speed );

        if (transform.position.y < -10)
        {
            Respawn();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
        currentJump = 0;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.Sleep();
        transform.position = respawnPoint.position;
    }

    void EndGame()
    {
        menuController.LoseGame();
        gameObject.SetActive(false);
    }

}
