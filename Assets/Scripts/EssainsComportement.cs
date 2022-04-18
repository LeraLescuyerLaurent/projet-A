using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class EssainsComportement : ScriptableObject
{

    public abstract Vector2 CalculMouvement (EssainsAgent agent, List<Transform> context, Essains essain);
        
}
