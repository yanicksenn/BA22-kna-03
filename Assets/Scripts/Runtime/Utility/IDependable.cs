using System.Collections.Generic;

public interface IDependable
{
    IEnumerable<IDependable> GetDependencies();
}