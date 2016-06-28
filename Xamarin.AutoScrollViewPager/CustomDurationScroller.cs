using System;
using Android.Widget;
using Android.Content;
using Android.Views.Animations;

namespace Xamarin.AutoScrollViewPager
{
	public class CustomDurationScroller:Scroller
	{
		private double scrollFactor = 1;

		public CustomDurationScroller (Context context) : base (context)
		{
		}

		public CustomDurationScroller (Context context, IInterpolator interpolator) : base (context, interpolator)
		{
		}

		/// <summary>
		/// Set the factor by which the duration will change
		/// </summary>
		/// <param name="scrollFactor">Scroll factor.</param>
		public void SetScrollDurationFactor (double scrollFactor)
		{
			this.scrollFactor = scrollFactor;
		}

		public override void StartScroll (int startX, int startY, int dx, int dy, int duration)
		{
			base.StartScroll (startX, startY, dx, dy, (int)(duration * scrollFactor));
		}
	}
}

