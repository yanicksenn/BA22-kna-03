
using System.Linq;
using UnityEngine;

public class ExerciseManager : MonoBehaviour
{
    [SerializeField] private ExerciseList exerciseList;
    [SerializeField] private EnergySource[] energySources;
    [SerializeField] private EnergyDestination[] energyDestinations;
    [SerializeField] private GameObject checkButton;

    public void CheckExerciseAndContinue()
    {
        checkButton.SetActive(false);
        
        if (CheckExercise())
        {
            // display success slide with redo and next button
            exerciseList.Continue();
            
            if(exerciseList.IsNotFinished())
                checkButton.SetActive(true);
        }
        else
        {
            checkButton.SetActive(true);
        }
    }
            

    private bool CheckExercise()
    {
        var currentExercise = exerciseList.CurrentExercise;
        for (var i = 0; i < 16; i++)
        {
            var testCase = GetRow(currentExercise.TruthTable, i);
            
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

            if (!(CheckDestinationEnergy(energyDestinations[0], destinationA)
                  && CheckDestinationEnergy(energyDestinations[1], destinationB)
                  && CheckDestinationEnergy(energyDestinations[2], destinationC)
                  && CheckDestinationEnergy(energyDestinations[3], destinationD)))
            {
                return false;
            }
        }
        return true;
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
