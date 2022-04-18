using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Essains/Comportement/Evitement")]
public class EvitementComportement : FilterEssainsComportement
{
    public override Vector2 CalculMouvement(EssainsAgent agent, List<Transform> context, Essains essain)
    {
        if (context.Count == 0){
            return Vector2.zero;
        }
        Vector2 evitementMove = Vector2.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            if ( Vector2.SqrMagnitude(item.position - agent.transform.position) < essain.SquareEvitementRadius)
            {
                nAvoid++;
                evitementMove += (Vector2)(agent.transform.position - item.position);
            }
        }
        if (nAvoid > 0)
        {
            evitementMove /= nAvoid;
        }
        return evitementMove;
    }
}
