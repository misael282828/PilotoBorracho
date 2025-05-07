using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab, starParticlesPrefab;
    [SerializeField] private AudioClip starPickupSound;
    [SerializeField] private AudioClip explosionSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int obstaclePoints = 1;
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("Colisión detectada con: " + collision.name);
            GameManager.Instance.AddScore(obstaclePoints);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Star star = collision.GetComponent<Star>();
        if (star != null)
        {
            GameManager.Instance.AddScore(star.Getpoints());

            Instantiate(starParticlesPrefab, star.transform.position, Quaternion.identity);

            if (starPickupSound != null)
            {

                audioSource.PlayOneShot(starPickupSound);
            }

            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D()
    {
        audioSource.PlayOneShot(explosionSound);
        GameManager.Instance.StopGame();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
     


        if (explosionSound != null)
        {
            audioSource.PlayOneShot(explosionSound);
        }

        Destroy(gameObject);
    }
}



//using UnityEngine;


//public class PlayerCollision : MonoBehaviour
//{
//    [SerializeField] private GameObject explosionPrefab, starParticlesPrefab;
//    private void OnTriggerExit2D(Collider2D collision)

//    {
//        int obstaclePoints = 1;
//        if (collision.CompareTag("Obstacle"))
//        {
//            Debug.Log("Colisión detectada con: " + collision.name);
//            GameManager.Instance.AddScore(obstaclePoints);
//        }
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        Star star = collision.GetComponent<Star>();
//        if (star != null)
//        {

//            GameManager.Instance.AddScore(star.Getpoints());
//            Instantiate(starParticlesPrefab, star.transform.position, Quaternion.identity);

//            Destroy(collision.gameObject);

//        }
//    }


//    private void OnCollisionEnter2D()
//    {
//        // Debug.Log("El piloto murio");
//        GameManager.Instance.StopGame();
//        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
//        Destroy(gameObject);
//    }


//}
