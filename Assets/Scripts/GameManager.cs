using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Canvas menu;

    public AudioSource musica;
    public AudioSource sonido;


    public static GameManager Instancia { get; private set; }


    private void Awake()
    {
        if(Instancia != null)
        {
            Destroy(this);
        }
        else
        {
            Instancia = this;
        }
    }


    // Start is called before the first frame update

    // Update is called once per frame

    public void Restart()
    {
        this.menu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        this.musica.Play();
        this.sonido.Play();
        SceneManager.LoadScene("Nivel");

    }

    public void FinishGame()
    {
        Time.timeScale = 0;
        this.menu.gameObject.SetActive(true);
        this.musica.Stop();
        this.sonido.Stop(); 
    }

}
