using UnityEngine;

[CreateAssetMenu(fileName = "Exercise",menuName = "BA22/Create exercise")]
public class Exercise: ScriptableObject
{
    [SerializeField] private int exerciseNumber;
    public int ExerciseNumber => exerciseNumber;
    
    [SerializeField] private string exerciseName;
    public string ExerciseName => exerciseName;
    
    [SerializeField,TextArea] private string exerciseDescription;
    public string ExerciseDescription => exerciseDescription;

}
