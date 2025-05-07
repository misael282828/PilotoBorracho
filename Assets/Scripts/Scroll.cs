
using UnityEngine;

public class Scroll : MonoBehaviour
{
    
    [SerializeField] private float scrollSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * scrollSpeed);
    }

    public void StopScroll()
    {
        scrollSpeed = 0;
    }
}
