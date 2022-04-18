using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Essains/Comportement/Composite")]
public class CompositeComportement : EssainsComportement
{
    // public List<EssainsComportement> comportements = new List<EssainsComportement>();

    public EssainsComportement[] comportements;
    public float[] weights;

    public override Vector2 CalculMouvement(EssainsAgent agent, List<Transform> context, Essains essain)
    {
        if (weights.Length != comportements.Length)
        {
            Debug.LogError("Comportement and weights must have the same length");
            return Vector2.zero;
        }

        Vector2 move = Vector2.zero;
        for (int i = 0; i < comportements.Length; i++)
        {
            Vector2 partialMove = comportements[i].CalculMouvement(agent, context, essain) * weights[i];

            if (partialMove != Vector2.zero)
            {
                if ( partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }
                move += partialMove;
            }
        }
        return move;
    }
}
