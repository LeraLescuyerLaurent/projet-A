using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Essains/Comportement/Alignement")]
public class AlignementComportement : FilterEssainsComportement
{
    // Start is called before the first frame update
 public override Vector2 CalculMouvement(EssainsAgent agent, List<Transform> context, Essains essain)
    {
        if (context.Count == 0){
            return agent.transform.up;
        }
        Vector2 alignementMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            alignementMove += (Vector2)item.transform.up;
        }
        alignementMove /= context.Count;
        return alignementMove;
    }
}
