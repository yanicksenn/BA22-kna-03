namespace Runtime.Presentation
{
    public interface INavigationCondidition
    {
        bool AllowsNext(AbstractSlide slide);
        bool AllowsPrevious(AbstractSlide slide);

        void OnShowSlide(AbstractSlide slide);

        void OnHideSlide(AbstractSlide slide);
    }
}