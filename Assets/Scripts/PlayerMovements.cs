
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float upForce;
    private Rigidbody2D rd;
    private float yInput;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {   //Toma de inputs
        yInput = Input.GetAxisRaw("Vertical");

        //al mantener la pantalla del movil presionada el player debe subir, con touching
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
            {
                yInput = 1;
            }
            else
            {
                yInput = 0;
            }
        }


    }

    private void FixedUpdate()
    {
        //fisicas
        // rd.AddForce(new Vector2 (yInput, upForce));
        rd.AddForce(Vector2.up * upForce * yInput);
    }
}
