using System.Collections.Generic;

public static class DependableUtil 
{
    public static bool HasCyclicDependencies(IDependable currentDependable)
    {
        return HasCyclicDependencies(currentDependable, new HashSet<IDependable> { currentDependable });
    }
    
    private static bool HasCyclicDependencies(IDependable currentDependable, ISet<IDependable> visited)
    {
        var directDependencies = currentDependable.GetDependencies();
        if (directDependencies == null)
            return false;

        foreach (var nextDependency in directDependencies)
        {
            if (visited.Contains(nextDependency))
                return true;
            
            visited.Add(nextDependency);
            if (HasCyclicDependencies(nextDependency, visited))
                return true;
            
            visited.Remove(nextDependency);
        }

        return false;
    }
}