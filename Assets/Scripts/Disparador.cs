using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tipo { seguidor, simpleRapido, simpleLento, random}

public class Disparador : MonoBehaviour
{
    [SerializeField] 
    private GameObject flecha;

    [SerializeField]
    private int maximoFlechas = 4;


    public Transform spawnPoint;
    private Transform playerTransform;

    [SerializeField]
    private float tiempoDisparo = 1.5f;
    private float tiempo;

    [SerializeField]
    private Tipo tipo;

    private float velocidad = 20;
    private float distanciaMinimaDisparos = 50;


    private List<GameObject> flechas = new List<GameObject>();
    private List<Flecha> scriptFlechas = new List<Flecha>();

    void Awake()
    {
        this.CargarDependencias();
        this.PrepararFlechas();
        this.tiempo = 5;
    }
    // Start is called before the first frame update

    void Start()
    {
        switch (this.tipo)
        {
            case Tipo.seguidor:
                this.tiempoDisparo = 3;
                this.distanciaMinimaDisparos = 15;
                break;
            case Tipo.simpleLento:
                this.tiempoDisparo = this.tiempoDisparo * 2.2f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, this.playerTransform.position);

        switch (this.tipo)
        {
            case Tipo.seguidor:
                this.MirarJugador();
                break;
            case Tipo.random:
                this.tiempoDisparo = Random.Range(0.8f, 5);
                break;
        }
        
        if(dist <= this.distanciaMinimaDisparos)
        {
            this.tiempo -= Time.deltaTime;
            this.Disparar();
        }
        else
        {
            this.tiempo = this.tiempoDisparo;
        }

    }

    private void CargarDependencias()
    {
        this.spawnPoint = this.transform.GetChild(0).transform;
        this.playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void PrepararFlechas()
    {
        for (int i = 0; i < this.maximoFlechas; i++)
        {
            GameObject nuevaFlecha = Instantiate(this.flecha, spawnPoint.position, this.transform.rotation);
            //nuevaBala.transform.SetParent(spawnPoint.transform);
            nuevaFlecha.SetActive(false);
            this.flechas.Add(nuevaFlecha);
            this.scriptFlechas.Add(nuevaFlecha.GetComponent<Flecha>());
        }
    }


    private void MirarJugador()
    {
        Quaternion rotacion = Quaternion.LookRotation(this.playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotacion, velocidad * Time.deltaTime);
    }


    private void Disparar()
    {
        if (this.tiempo <= 0)
        {
            int index = 0;
            foreach (GameObject flecha in this.flechas)
            {
                Flecha script = this.scriptFlechas[index];
                if (!script.EstaEnUso())
                {
                    flecha.SetActive(true);
                    script.Disparar(this.spawnPoint.transform);
                    this.tiempo = this.tiempoDisparo;
                    break;
                }
                index++;
            }
        }
    }
}
