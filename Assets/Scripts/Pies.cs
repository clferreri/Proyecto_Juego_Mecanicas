using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pies : MonoBehaviour
{

    [SerializeField]
    private Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        this.playerScript.PuedoSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        this.playerScript.PuedoSaltar = false;
    }

}
