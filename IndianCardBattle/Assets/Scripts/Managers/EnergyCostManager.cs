public class EnergyCostManager
{
    private int currentEnergyCost;
    private int energyIncrementFactorWithEachTurn;

    public EnergyCostManager(int currentEnergyCost, int energyIncrementFactorWithEachTurn)
    {
        this.currentEnergyCost = currentEnergyCost;
        this.energyIncrementFactorWithEachTurn = energyIncrementFactorWithEachTurn;
    }

    public void OnTurnUpdated()
    {
        this.currentEnergyCost += energyIncrementFactorWithEachTurn;
        //TODO : fire event to update UI
    }
}
