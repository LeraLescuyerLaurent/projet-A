using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddActionInputKey : MonoBehaviour
{

    // le Add bird se fait dans Essains.cs update
    public GameObject obstacle;
    public GameObject ciblePrefab;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(obstacle, new Vector3(mousePos.x, mousePos.y, 0f), Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject cibleAgent = Instantiate(
                ciblePrefab,
                new Vector3(cursorPosition.x, cursorPosition.y, 0f),
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
            );
            Collider2D[] colliders = Physics2D.OverlapCircleAll(cibleAgent.transform.position, 0.5f);
            // Destroy agent in CircleOverlap2D
            if (colliders.Length >= 1)
            {
                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject != null && collider.gameObject.tag == "Obstacle") {
                        // Change color of bird
                        collider.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                        Destroy(collider.gameObject);
                    }
                }
                
            }
            // Destroy cibleAAgent apres 0.5s
            Destroy(cibleAgent, 0.2f);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        } 
    }
}