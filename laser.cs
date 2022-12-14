using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    float _laserspeed = 8.0f;
    void Start()
    {

    }

    void Update()
    {
        caluclateMovement();
    }

    void caluclateMovement()
    {
        transform.Translate(Vector3.up * _laserspeed * Time.deltaTime);

        if(transform.position.y >= 8)
        {
            Destroy(this.gameObject);
        }
    }
}
