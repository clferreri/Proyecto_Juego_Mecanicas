using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{

    public float timepoVida = 4;
    private bool enUso = false;
    private float contador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.enUso)
        {
            this.Mover();
            if (this.contador <= 0)
            {
                this.enUso = false;
                this.gameObject.SetActive(false);
            }
            this.contador -= Time.deltaTime;
        }
    }

    public void Disparar(Transform posicion)
    {
        this.transform.position = posicion.position;
        this.transform.rotation = posicion.rotation;
        this.enUso = true;
        this.contador = this.timepoVida;
    }

    public bool EstaEnUso()
    {
        return this.enUso;
    }

    private void Mover()
    {
        this.transform.Translate(new Vector3(0, -1, 0) * 8 * Time.deltaTime);
    }
}
