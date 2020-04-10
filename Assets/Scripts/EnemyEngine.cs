using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEngine : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer enemyRenderer;

    public const float greenPallete = 0.324f;
    public const float redPallete = 1f;

    private Vector3 boom = new Vector3(0.3f, 0.3f);
    void Start()
    {
        enemyRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 0)
        {
            Destroy(gameObject);
        }

        float ratio = player.transform.localScale.x / gameObject.transform.localScale.x;
        enemyRenderer.material.color = new Color(redPallete, greenPallete, ratio);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            transform.localScale -= collision.gameObject.transform.localScale;
            //player.transform.localScale -= new Vector3(0.3f, 0.3f);
        } 
        else if (collision.gameObject.name == "Enemy(Clone)" || collision.gameObject.name == "Player")
        {

            if (gameObject.transform.localScale.x > collision.gameObject.transform.localScale.x)
            {
                gameObject.transform.localScale += boom;
                collision.gameObject.transform.localScale -= boom;
            }
            else
            {
                collision.gameObject.transform.localScale += boom;
                gameObject.transform.localScale -= boom;
            }
        }
    }
}
