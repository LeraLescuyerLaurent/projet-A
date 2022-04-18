using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Essains/Comportement/LimitScreenView")]
public class LimitSceenViewComportement : EssainsComportement
{
    public Vector2 center;
    public float radius = 15f;

    public override Vector2 CalculMouvement(EssainsAgent agent, List<Transform> context, Essains essain)
    {
        Vector2 centerOffset = center - (Vector2)agent.transform.position;
        float t = centerOffset.magnitude / radius;
        if (t < 0.9f)
        {
             return Vector2.zero;
        }
        return centerOffset * t * t; 
    }
}
