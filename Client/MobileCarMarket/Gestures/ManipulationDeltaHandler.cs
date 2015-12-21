namespace MobileCarMarket.Gestures
{
    using System;
    using Windows.UI.Xaml.Input;

    public class ManipulationDeltaHandler
    {
        public void Execute(object sender, ManipulationDeltaRoutedEventArgs e, ref bool swipeLeft, ref bool swipeRight)
        {
            var x = e.Cumulative.Translation.X;
            var y = e.Cumulative.Translation.Y;

            var xAb = Math.Abs(x);
            var yAb = Math.Abs(y);

            swipeLeft = false;
            swipeRight = false;

            // Ensure that the horizontal scroll is greater than the 
            // vertical scroll amount. 
            // In case the user swipes diagonally, ensure that the 
            // horizontal scroll is at least 5x bigger than the vertical
            // scroll to eliminate any accidental changes.

            if ((xAb > 10) && (xAb > (5 * yAb)))
            {
                if (x < y)
                {
                    e.Handled = true;
                    swipeLeft = false;
                    swipeRight = true;
                }
                else if (x > y)
                {
                    e.Handled = true;
                    swipeLeft = true;
                    swipeRight = false;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
