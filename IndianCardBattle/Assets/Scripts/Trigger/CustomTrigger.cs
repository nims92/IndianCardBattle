public class CustomTrigger : ITrigger
{
    private bool value;
    
    public bool Get()
    {
        if (value) 
        { 
            value = false; 
            return true; 
        } 
        else 
            return false; 
    }

    public void Set()
    {
        value = true;
    }

    public void Reset()
    {
        value = false;
    }
}