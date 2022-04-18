using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Essains/Filter/PhysicLayerFilter")]
public class PhysicLayerFilter : ContextFilter
{
    public LayerMask mask;

        public override List<Transform> Filter(EssainsAgent agents, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform item in original)
        {
            if (mask == (mask | (0 << item.gameObject.layer)))
            {
                filtered.Add(item);
            }
        }
        return filtered;
    }
}