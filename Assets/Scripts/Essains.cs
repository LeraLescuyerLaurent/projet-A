using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essains : MonoBehaviour
{
    public EssainsAgent agentPrefab;
    private List<EssainsAgent> agents = new List<EssainsAgent>();
    public EssainsComportement comportement;

    public int nbAgents = 0;
    public float AgentDensite = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 100f;
    [Range(1f, 100f)]
    public float agentMaxSpeed = 5f;
    [Range(1f, 100f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 100f)]
    public float evitementRadiusMultiplicateur = 0.5f;


    // Calcul des ²
    float squareMaxSpeed;
    float squareNeightborRadius;
    float squareEvitementRadius;
    public float SquareEvitementRadius { get { return squareEvitementRadius; } }


    void Start()
    {
        squareMaxSpeed = agentMaxSpeed * agentMaxSpeed;
        squareNeightborRadius = neighborRadius * neighborRadius;
        squareEvitementRadius = squareNeightborRadius * evitementRadiusMultiplicateur * evitementRadiusMultiplicateur;

    }

    // Update is called once per frame
    void Update()
    {


        if ( Input.GetMouseButtonDown(0) )
        {
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            EssainsAgent newAgent = Instantiate(
                agentPrefab,
                new Vector3(cursorPosition.x, cursorPosition.y, 0f),
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
            );
            newAgent.name = "Agent" + Random.Range(0, 100000);
            newAgent.Initialize(this);
            
            agents.Add( newAgent );
        }

    

        foreach(EssainsAgent agent in agents)
        {
            List<Transform> context = GetNearByBirds(agent);
            // For ONLY DEMO
            // agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);

            if (context.Count >=0)
            {
                if ( agent != null)
                {
                    Vector2 move = comportement.CalculMouvement(agent, context, this);

                    move = move * driveFactor;
                    if (move.sqrMagnitude > squareMaxSpeed)
                    {
                        move = move.normalized * agentMaxSpeed ;
                    }
                    agent.Move(move);
                }
            }
        }
    }

    List<Transform> GetNearByBirds(EssainsAgent agent){

        List<Transform> context = new List<Transform>();
        if (context.Count >=0)
            {
                if ( agent != null)
                {
                    Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
                    foreach (Collider2D c in contextColliders)
                    {
                        if (c != agent.AgentCollider)
                        {
                            context.Add(c.transform);
                        }
                    }
                }
            }
        return context;
    }

}
