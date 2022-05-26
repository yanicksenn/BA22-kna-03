using System.Collections.Generic;
using UnityEngine;

public static class DependableUtil 
{
    public static bool HasCyclicDependencies(IDependable currentDependable)
    {
        return HasCyclicDependencies(currentDependable, new HashSet<IDependable>(), true);
    }
    
    private static bool HasCyclicDependencies(IDependable currentDependable, ISet<IDependable> visited, bool firstCall)
    {
        if (!firstCall && visited.Contains(currentDependable))
            return true;

        var directDependencies = currentDependable.GetDependencies();
        if (directDependencies == null)
            return false;
        
        visited.Add(currentDependable);
        
        foreach (var nextDependency in directDependencies)
            if (HasCyclicDependencies(nextDependency, visited, false))
                return true;

        return false;
    }
}