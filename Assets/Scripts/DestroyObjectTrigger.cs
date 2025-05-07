
using UnityEngine;

public class DestroyObjectTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
     //   Debug.Log("Trigger detectado con: " + collision.gameObject.name);
        Destroy(collision.gameObject);
    }

}
