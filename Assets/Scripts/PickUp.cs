using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int scoreAmount = 0;
    public float timeAmount = 0.00f;
    // Start is called before the first frame update

    public GameObject explosionPrefab;

    private void OnTriggerEnter(Collider Collision)
    {
        if (GameManager.gm)
        {
            if (GameManager.gm.gameIsOver)
            {
                return;
            }
        }

        if(Collision.gameObject.tag == "Player")
        {
            if (explosionPrefab)
            {
                // Instantiate an explosion effect at the gameObjects position and rotation
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
            if (GameManager.gm)
            {
                GameManager.gm.targetHit(scoreAmount, timeAmount);
            }
            Destroy(gameObject);
        }
    }
}
