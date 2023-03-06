using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPreFab;
    public float bulletSpeed = 20;
    public float playerSpeed = 2;
    Vector2 movementVector;
    Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 movementVector = Vector2.zero;
        bulletSpawn = transform.Find("BulletSpawn");
        //e
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * movementVector.x);
        transform.Translate(Vector3.forward * movementVector.y * Time.deltaTime * playerSpeed);
    }
    
    void OnMove(InputValue inputValue)
    {
        movementVector = inputValue.Get<Vector2>();

        //Debug.Log(movementVector.ToString());
    }

    void OnFire()
    {
        GameObject bullet = Instantiate(bulletPreFab, bulletSpawn);
        bullet.transform.parent = null;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward*bulletSpeed, ForceMode.VelocityChange);
        Destroy(bullet, 5);
    }
}
