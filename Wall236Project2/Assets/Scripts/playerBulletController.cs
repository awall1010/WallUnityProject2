using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerBulletController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.WorldToViewportPoint(transform.position).y > 1)
        {

            scoreText.GetComponent<ScoreController>().score -= 5;
            scoreText.GetComponent<ScoreController>().updateScore();

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);
            scoreText.GetComponent<ScoreController>().score += 10;
            scoreText.GetComponent<ScoreController>().updateScore();

        }
    }
}
