namespace Runtime.Presentation
{
    public interface INavigationInterceptor
    {
        bool AllowsNext(AbstractSlide slide);

        void OnShowSlide(AbstractSlide slide);

        void OnHideSlide(AbstractSlide slide);
    }
}