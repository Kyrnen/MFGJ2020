using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;
    [SerializeField] PlayerController pc;
    [SerializeField] GameManager game;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            pc.enabled = false;
            movement.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }

        if (collision.collider.tag == "Waypoint")
        {
            pc.UpdateWaypoint();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.instance.GameOver();
        }
        else if (other.CompareTag("Coin"))
        {
            GameManager.instance.AddScore(1);
            pc.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("Waypoint"))
        {
            PathManager.instance.UpdateWaypoint();
            Debug.Log("moving waypoint");
        }
    }
}
