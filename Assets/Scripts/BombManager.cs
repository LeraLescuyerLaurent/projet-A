using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public GameObject ciblePrefab;
    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject cibleAgent = Instantiate(
                ciblePrefab,
                new Vector3(cursorPosition.x, cursorPosition.y, 0f),
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
            );
            Collider2D[] colliders = Physics2D.OverlapCircleAll(cibleAgent.transform.position, 6f);
            // Destroy agent in CircleOverlap2D
            if (colliders.Length >= 1)
            {
                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject != null && collider.gameObject.tag == "bird") {
                        // Change color of bird
                        collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                        Destroy(collider.gameObject, 0.2f);
                    }
                }
                
            }
            // Destroy cibleAAgent apres 0.5s
            Destroy(cibleAgent, 0.2f);
        }
    }


}