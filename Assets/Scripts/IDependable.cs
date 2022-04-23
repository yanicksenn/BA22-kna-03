using System.Collections.Generic;

public interface IDependable
{
    IEnumerable<IDependable> GetDirectDependencies();
    
    bool HasCyclicDependencies()
    {
        return HasCyclicDependencies(new HashSet<IDependable>());
    }
    
    private bool HasCyclicDependencies(ISet<IDependable> cache)
    {
        if (cache.Contains(this))
            return true;

        var directDependencies = GetDirectDependencies();
        if (directDependencies == null)
            return false;

        foreach (var dependency in directDependencies)
        {
            cache.Add(dependency);
            if (HasCyclicDependencies(cache))
                return true;
        }

        return false;
    }
}