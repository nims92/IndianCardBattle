using UnityEngine;

public class WaitForTrigger : CustomYieldInstruction
{
    private readonly ITrigger trigger;

    public override bool keepWaiting
    {
        get
        {
            return !trigger.Get();
        }
    }
    
    public WaitForTrigger(ITrigger trigger) 
    {
        this.trigger = trigger;
    }
}