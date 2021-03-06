using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class EssainsAgent : MonoBehaviour
{
    Essains agentEssain;

    public Essains AgentEssains { get { return agentEssain; } }


    private Collider2D agentCollider;
    public Collider2D AgentCollider { get { return agentCollider; } }

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    
    public void Initialize(Essains essains)
    {
        agentEssain = essains;
    }
    
    public void Move(Vector2 velocity)
    {
            transform.up = velocity;
            transform.position += (Vector3)velocity * Time.deltaTime;
    }

  
}
