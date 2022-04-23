using System.Collections.Generic;

public static class DependableUtil
{
    public static bool HasCyclicDependencies(IDependable dependable)
    {
        return HasCyclicDependencies(dependable, new HashSet<IDependable>());
    }
    
    private static bool HasCyclicDependencies(IDependable dependable, ISet<IDependable> cache)
    {
        if (cache.Contains(dependable))
            return true;
        
        cache.Add(dependable);
        var directDependencies = dependable.GetDependencies();
        if (directDependencies == null)
            return false;

        foreach (var dependency in directDependencies)
        {
            if (HasCyclicDependencies(dependency,cache))
                return true;
        }

        return false;
    }
}