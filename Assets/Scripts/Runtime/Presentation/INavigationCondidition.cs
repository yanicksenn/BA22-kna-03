namespace Runtime.Presentation
{
    public interface INavigationCondidition
    {
        bool AllowsNext(AbstractSlide slide);
        bool AllowsPrevious(AbstractSlide slide);
    }
}