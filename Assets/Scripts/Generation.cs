using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{

    public List<Vector3> figureCoords = new List<Vector3>();

    public GameObject enemy;
    public GameObject player;

    public float figureCount;
    // Start is called before the first frame update
    void Start()
    {
        figureCount = 2;

        float x;
        float y;
        
        for (int i = 0; i < figureCount; i++)
        {
            x = Random.Range(-10, 10);
            y = Random.Range(-5, 5);

            Vector2 figureCoord = new Vector2(x, y);
            figureCoords.Add(figureCoord);
        }

        foreach(Vector2 figureCoord in figureCoords)
        {
            GameObject obj = Instantiate(enemy, figureCoord, Quaternion.identity);
            float scaleCircle = Random.Range(1f, 12f);
            obj.transform.localScale = new Vector3(scaleCircle, scaleCircle, 0);

            Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
            body.AddForce(new Vector3(Random.Range(0.05f, 0.6f), 
                Random.Range(0.1f, 10), 0), ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
