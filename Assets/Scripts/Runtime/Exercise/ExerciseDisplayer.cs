using TMPro;
using UnityEngine;

[ExecuteAlways]
public class ExerciseDisplayer : MonoBehaviour
{
    [SerializeField] private ExerciseList exerciseList;
    [SerializeField] private TMP_Text exerciseName;
    [SerializeField] private TMP_Text exerciseNumber;
    [SerializeField] private TMP_Text exerciseDescription;

    private void Update()
    {
        if(exerciseList != null && exerciseDescription != null && exerciseName != null && exerciseNumber != null)
            DisplayExercise();
    }
    
    private void DisplayExercise()
    {
        var exercise = exerciseList.CurrentExercise;
        if (exercise == null)
        {
            exerciseDescription.text = "You're done!";
            exerciseName.text = "Congratulations!";
            exerciseNumber.text = "";
        }
        else
        {
            exerciseDescription.text = exercise.ExerciseDescription;
            exerciseName.text = exercise.ExerciseName;
            exerciseNumber.text = $"{exercise.ExerciseNumber} / {exerciseList.Count()}";
        }
    }

}

