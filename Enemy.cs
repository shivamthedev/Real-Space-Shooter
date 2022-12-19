using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 4f;
    [SerializeField]
    private GameObject Laser;
    void Start()
    {
        
    }

    void Update()
    {

        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        if(transform.position.y < -5.5f)
        {
            float randomX = Random.Range(-8.05f, 8f);
            transform.position = new Vector3(randomX, 7.5f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Laser")
        {
            Destroy(other);
            Destroy(this.gameObject);
        }
        
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }
    }
}
