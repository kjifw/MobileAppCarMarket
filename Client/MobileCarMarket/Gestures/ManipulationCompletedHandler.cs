namespace MobileCarMarket.Gestures
{
    using System;
    using Windows.UI.Xaml.Input;

    using Helpers;
    
    public class ManipulationCompletedHandler
    {
        public void Execute(ref bool swipeLeft, ref bool swipeRight, Type swipeLeftPage, Type swipeRightPage, ManipulationCompletedRoutedEventArgs e)
        {
            if (swipeLeft == true || swipeRight == true)
            {
                e.Handled = true;

                bool process = false;
                Type navigatePage = null;

                if (swipeLeft == true && swipeLeftPage != null)
                {
                    process = true;
                    navigatePage = swipeLeftPage;
                }

                if (swipeRight == true && swipeRightPage != null)
                {
                    process = true;
                    navigatePage = swipeRightPage;
                }

                if (process == true && navigatePage != null)
                {
                    new NavigationService().Navigate(navigatePage);
                }

                swipeLeft = false;
                swipeRight = false;
            }
        }
    }
}
