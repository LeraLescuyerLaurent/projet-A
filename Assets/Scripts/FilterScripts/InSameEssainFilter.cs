using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Essains/Filter/InSameEssainFilter")]
public class InSameEssainFilter : ContextFilter
{
    public override List<Transform> Filter(EssainsAgent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform item in original)
        {
            EssainsAgent itemAgent = item.GetComponent<EssainsAgent>();
            if (itemAgent != null && itemAgent.AgentEssains == agent.AgentEssains)
            {
                filtered.Add(item);
            }
        }
        return filtered;
    }
}