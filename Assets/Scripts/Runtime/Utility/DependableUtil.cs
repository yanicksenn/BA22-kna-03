using System.Collections.Generic;

public static class DependableUtil
{
    public static bool HasCyclicDependencies(IDependable currentDependable)
    {
        return HasCyclicDependencies(currentDependable, currentDependable, true);
    }
    
    private static bool HasCyclicDependencies(IDependable currentDependable, IDependable originalDependable, bool firstCall)
    {
        if (!firstCall && currentDependable == originalDependable)
            return true;

        var directDependencies = currentDependable.GetDependencies();
        if (directDependencies == null)
            return false;

        foreach (var nextDependency in directDependencies)
            if (HasCyclicDependencies(nextDependency, originalDependable, false))
                return true;

        return false;
    }
}