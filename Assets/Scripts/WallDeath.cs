using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDeath : MonoBehaviour
{

    [SerializeField]
    private float speed = 1.8f;


    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(this.speed * Time.deltaTime, 0,0));
    }
}