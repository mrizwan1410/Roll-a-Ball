using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    float speed = 5;
    public Text txtScore;
    int score;

    public ParticleSystem pSysPlayer;
    public ParticleSystem pSysEnemy;
    bool isGameOver;
    public GameObject panelGameOver;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        panelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude < 3)
        {
            pSysPlayer.Stop();
        }
        else
        {
            if(!pSysPlayer.isPlaying)
            {
                pSysPlayer.Play();
            }
        }
    }
    void FixedUpdate()
    {
        if (!isGameOver)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Coin")
        {
            Destroy(other.gameObject);
            score++;
            txtScore.text = "Score: " + score;
        }

        if(other.gameObject.tag=="Enemy")
        {
            isGameOver = true;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            Destroy(other.gameObject, 1.0f);
            pSysEnemy.Play();
            panelGameOver.SetActive(true);
        }
    }
    public void btnPlayAgain()
    {
        SceneManager.LoadScene("SceneOne");
    }
}
