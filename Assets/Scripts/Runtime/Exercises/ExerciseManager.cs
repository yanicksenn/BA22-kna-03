using System.Linq;
using Runtime.Exercises;
using Runtime.Presentation;
using UnityEngine;

public class ExerciseManager : MonoBehaviour, INavigationInterceptor
{
    [SerializeField] private Presenter presenter;
    
    [SerializeField, Space] private EnergySource[] energySources;
    [SerializeField] private EnergyDestination[] energyDestinations;
    [SerializeField] private GameObject checkButton;

    public bool AllowsNext(AbstractSlide slide)
    {
        if (slide is not AbstractExerciseSlide exerciseSlide)
            return true;

        return CheckExercise(exerciseSlide);
    }

    public void OnShowSlide(AbstractSlide slide) { }
    public void OnHideSlide(AbstractSlide slide) { }

    private void OnEnable()
    {
        presenter.NavigationConditions.Add(this);
    }
    
    private void OnDisable()
    {
        presenter.NavigationConditions.Remove(this);
    }
    


    private bool CheckExercise(AbstractExerciseSlide exerciseSlide)
    {
        var originalEnergy0 = energySources[0].GetEnergy();
        var originalEnergy1 = energySources[1].GetEnergy();
        var originalEnergy2 = energySources[2].GetEnergy();
        var originalEnergy3 = energySources[3].GetEnergy();
        
        var truthTable = exerciseSlide.TruthTable;
        var result = true;
        
        for (var i = 0; i < 16; i++)
        {
            var testCase = GetRow(truthTable, i);
            
            var source0 = testCase[0];
            var source1 = testCase[1];
            var source2 = testCase[2];
            var source3 = testCase[3];

            var destinationA = testCase[4];
            var destinationB = testCase[5];
            var destinationC = testCase[6];
            var destinationD = testCase[7];

            energySources[0].setCurrent(source0);
            energySources[1].setCurrent(source1);
            energySources[2].setCurrent(source2);
            energySources[3].setCurrent(source3);

            if (CheckDestinationEnergy(energyDestinations[0], destinationA)
                && CheckDestinationEnergy(energyDestinations[1], destinationB)
                && CheckDestinationEnergy(energyDestinations[2], destinationC)
                && CheckDestinationEnergy(energyDestinations[3], destinationD)) 
                continue;
            
            result = false;
            break;
        }
        
        // energySources[0].setCurrent(originalEnergy0);
        // energySources[1].setCurrent(originalEnergy1);
        // energySources[2].setCurrent(originalEnergy2);
        // energySources[3].setCurrent(originalEnergy3);
        
        return result;
    }
    
    private int[] GetRow(int[,] matrix, int rowNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(1))
            .Select(x => matrix[rowNumber, x])
            .ToArray();
    }

    private static bool CheckDestinationEnergy(EnergyDestination dest, int test)
    {
        if (test == 9)
            return true;

        if (dest.GetEnergy() == EnergyType.True && test == 1)
            return true;

        if (dest.GetEnergy() == EnergyType.False && test == 0)
            return true;

        return false;
    }
}
