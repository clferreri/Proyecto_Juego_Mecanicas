using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroRayCast : MonoBehaviour
{
    [SerializeField]
    private GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        this.transform.LookAt(this.jugador.transform.position);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.tag);
            if(hit.transform.tag == "Player")
            {
                Debug.DrawRay(ray.origin, ray.direction * 50, Color.red);
                Debug.Log("Distancia del jugador a la pared: " + hit.distance);
            }
            else
            {
                Debug.Log("Distancia del objeto a la pared: " + hit.distance);
            }
           
        }
    }
}
