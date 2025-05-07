
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
    }

    private void FixedUpdate()
    {
        //fisicas
       // rd.AddForce(new Vector2 (yInput, upForce));
        rd.AddForce(Vector2.up * upForce * yInput);
    }
}
