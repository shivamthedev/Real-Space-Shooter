using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables
    [SerializeField]
    float _playerSpeed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    float _laserSpawnPoint = 0.8f;
    [SerializeField]
    private float fireRate = 0.15f;
    private float canFire = -1f;

    void Start()
    {
        transform.position = new Vector3 (0, 0f, 0);
    }

    void Update()
    {
        PlayerMovement();
        PlayerBound();
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            shoot();
        }
    }

    void shoot()
    {
        canFire = Time.time + fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, _laserSpawnPoint, 0), Quaternion.identity);
    }

    void PlayerMovement()
    {
        float horrizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 dirrection = new Vector3(horrizontalInput, verticalInput, 0);
        transform.Translate(dirrection * _playerSpeed * Time.deltaTime);
    }

    void PlayerBound()
    {
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        if (transform.position.x > 10.23)
        {
            transform.position = new Vector3(-10.23f, transform.position.y, 0);
        }
        else if (transform.position.x < -10.23)
        {
            transform.position = new Vector3(10.23f, transform.position.y, 0);
        }
    }
}
