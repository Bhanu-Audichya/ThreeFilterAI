using Unity.VisualScripting;
using UnityEngine;

public abstract class AIBaseState
{
    public abstract void Execute(AIStateManager state);
    public abstract void Updating(AIStateManager state);
    
}
