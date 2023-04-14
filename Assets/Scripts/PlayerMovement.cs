using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource gameOverAudio;
    public AudioSource gameWinAudio;
    //public AudioSource gameStart;
    public Score score;
    public GameController gameController;
    public Rigidbody rigidbody;
    //public float playerspeed = 10f;
    public float speed = 8f;
    public float maxX;
    public float minX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if(pos.x<minX)
        {
            pos.x= minX;
        }
        transform.position = pos;
        if(pos.x>maxX)
        {
            pos.x = maxX;
        }
        transform.position = pos;

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - new Vector3(speed * Time.deltaTime, 0, 0);
        }
        
    }
    private void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(0, 0, 10f * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "score")
        {
            score.AddScore(1);
            audioSource.Play();
            Debug.Log(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag=="Enemy")
        {

            //transform.position = new Vector3(0, 0, 0);
            Time.timeScale = 0f;
            gameOverAudio.Play();
            gameController.GameOver();
        }
        if (collision.gameObject.tag=="Win")
        {
            Time.timeScale = 0f;
            gameWinAudio.Play();
            gameController.GameOver();
        }
    }
}
