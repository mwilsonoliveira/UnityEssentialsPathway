using UnityEngine;

public class BallCollides : MonoBehaviour
{
    public AudioClip colliderSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Whenever the ball collides with a collider, play a sound effect
        if (colliderSound != null)
        {
            AudioSource.PlayClipAtPoint(colliderSound, transform.position);
        }
    }
}
