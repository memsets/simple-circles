using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEngine : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shotDir;
    public Rigidbody2D rbody;

    public float offsetRotation;
    public float playerSpeed;
    public float pewSpeed;
    void Start()
    {
        pewSpeed = 20;
        playerSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        #region

        float horizontalMoving = Input.GetAxis("Horizontal");
        float verticalMoving = Input.GetAxis("Vertical");

        Vector2 moving = new Vector2(playerSpeed * horizontalMoving * Time.deltaTime,
            playerSpeed * verticalMoving * Time.deltaTime);

        rbody.AddForce(moving, ForceMode2D.Impulse);

        #endregion

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pew = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); //google this statement for understand
            rbody.AddForce(pew * pewSpeed);
        }

        Debug.DrawRay(Input.mousePosition, transform.position);

        //----------=---------------------------------------
        Vector3 differerce = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float rotateZ = Mathf.Atan2(differerce.y, differerce.x) * Mathf.Rad2Deg; //math magic for me
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offsetRotation);

        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(bullet, shotDir.transform.position, transform.rotation);
        }

    }
}
