using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.6f;

    private float actualSpeed;
    [SerializeField]
    private float multiplayerSpeed = 4.5f;
    [SerializeField]
    private float rotationSpeed = 200;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float jumpForce = 16f;

    private bool puedoSaltar;

    private float x, y;

    private bool finishGame = false;

    public bool PuedoSaltar { get => puedoSaltar; set => puedoSaltar = value; }
    public bool FinishGame { get => finishGame; set => finishGame = value; }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.finishGame)
        {
            return;
        }

        this.Move();
        if (this.puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.animator.SetBool("Salte", true);
                rb.AddForce(new Vector3(0, this.jumpForce, 0), ForceMode.Impulse);
            }
            this.animator.SetBool("TocoSuelo", true);
        }
        else
        {
            this.animator.SetBool("TocoSuelo", false);
            this.animator.SetBool("Salte", false);
        }
    }

    void FixedUpdate()
    {
        this.Jump();
    }


    private void Move()
    {
        
        if (Input.GetKey(KeyCode.LeftShift) && this.puedoSaltar)
        {
            this.actualSpeed = this.speed * multiplayerSpeed;
            this.animator.SetBool("Corriendo", true);
        }
        else
        {
            this.actualSpeed = this.speed;
            this.animator.SetBool("Corriendo", false);
        }

        this.actualSpeed = Input.GetKey(KeyCode.LeftShift) ? this.speed * multiplayerSpeed : this.speed;

        float left = Input.GetAxis("Left");

        this.x = Input.GetAxis("Horizontal");
        this.y = Input.GetAxis("Vertical");
        this.transform.Rotate(0, x * Time.deltaTime * this.rotationSpeed, 0);
        this.transform.Translate(left * Time.deltaTime * this.actualSpeed, 0, y * Time.deltaTime * this.actualSpeed);

        this.animator.SetFloat("VelX", left);
        this.animator.SetFloat("VelY", this.y);
    }

    private void Jump()
    {
        
    }


}
