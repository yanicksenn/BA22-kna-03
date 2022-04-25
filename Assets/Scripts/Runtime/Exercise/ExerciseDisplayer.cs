using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class ExerciseDisplayer : MonoBehaviour
{
    [SerializeField] private Exercise exercise;
    [SerializeField] private TMP_Text exerciseName;
    [SerializeField] private TMP_Text exerciseNumber;
    [SerializeField] private TMP_Text exerciseDescription;

    private void displayExercise()
    {
        exerciseDescription.text = exercise.ExerciseDescription;
        exerciseName.text = exercise.ExerciseName;
        exerciseNumber.text = exercise.ExerciseNumber.ToString();
    }

    private void Update()
    {
        if(exercise != null && exerciseDescription != null && exerciseName != null && exerciseNumber != null)
            displayExercise();
    }
}

