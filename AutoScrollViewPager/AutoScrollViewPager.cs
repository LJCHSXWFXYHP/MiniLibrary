using System;
using Android.Support.V4.View;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;
using JException = Java.Lang.Exception;

namespace Xamarin.AutoScrollViewPager
{
	public class AutoScrollViewPager:ViewPager
	{
		public static readonly int DEFAULT_INTERVAL = 1500;

		public static readonly int LEFT = 0;
		public static readonly int RIGHT = 1;

		/** do nothing when sliding at the last or first item **/
		public static readonly int SLIDE_BORDER_MODE_NONE = 0;
		/** cycle when sliding at the last or first item **/
		public static readonly int SLIDE_BORDER_MODE_CYCLE = 1;
		/** deliver event to parent when sliding at the last or first item **/
		public static readonly int SLIDE_BORDER_MODE_TO_PARENT = 2;

		/// <summary>
		/// auto scroll time in milliseconds
		/// </summary>
		/// <value>The interval.</value>
		public long Interval {
			get;
			set;
		}=DEFAULT_INTERVAL;

		/// <summary>
		/// auto scroll direction
		/// </summary>
		/// <value>The direction.</value>
		public int Direction {
			get;
			set;
		}=RIGHT;

		/// <summary>
		/// whether automatic cycle when auto scroll reaching the last or first item, default is true
		/// </summary>
		/// <value><c>true</c> if this instance is cycle; otherwise, <c>false</c>.</value>
		public bool IsCycle {
			get;
			set;
		}=true;

		/// <summary>
		/// whether stop auto scroll when touching, default is true
		/// </summary>
		/// <value><c>true</c> if stop scroll when touch; otherwise, <c>false</c>.</value>
		public bool StopScrollWhenTouch {
			get;
			set;
		}=true;


		/// <summary>
		/// how to process when sliding at the last or first item
		/// </summary>
		/// <value>The slide border mode.</value>
		public int SlideBorderMode {
			set;
			get;
		}= SLIDE_BORDER_MODE_NONE;

		/// <summary>
		///  whether animating when auto scroll at the last or first item
		/// </summary>
		/// <value><c>true</c> if this instance is border animation; otherwise, <c>false</c>.</value>
		public bool IsBorderAnimation {
			get;
			set;
		}= true;

		/// <summary>
		/// scroll factor for auto scroll animation, default is 1.0
		/// </summary>
		/// <value>The auto scroll factor.</value>
		public double AutoScrollFactor {
			set;
			get;
		} = 1.0;

		/// <summary>
		/// scroll factor for swipe scroll animation, default is 1.0
		/// </summary>
		/// <value>The swipe scroll factor.</value>
		public double SwipeScrollFactor {
			get;
			set;
		}=1.0;

		private Handler handler;
		private bool isAutoScroll = false;
		private bool isStopByTouch = false;
		private float touchX = 0f, downX = 0f;
		private CustomDurationScroller scroller = null;

		public const int SCROLL_WHAT = 0;


		public AutoScrollViewPager (Context context) : base (context)
		{
			init ();
		}

		public AutoScrollViewPager (Context context, Android.Util.IAttributeSet paramAttributeSet)
			: base (context, paramAttributeSet)
		{
			init ();
		}

		private void init ()
		{
			handler = new MyHandler (this);
			SetViewPagerScroller ();
		}

		/// <summary>
		/// start auto scroll, first scroll delay time is Interval property
		/// </summary>
		public void StartAutoScroll ()
		{
			isAutoScroll = true;
			SendScrollMessage ((long)(Interval + scroller.Duration / AutoScrollFactor * SwipeScrollFactor));
		}

		/// <summary>
		/// Starts the auto scroll.
		/// </summary>
		/// <param name="delayTimeInMills">delayTimeInMills first scroll delay time</param>
		public void StartAutoScroll (int delayTimeInMills)
		{
			isAutoScroll = true;
			SendScrollMessage (delayTimeInMills);
		}

		/// <summary>
		/// Stops the auto scroll.
		/// </summary>
		public void StopAutoScroll ()
		{
			isAutoScroll = false;
			handler.RemoveMessages (SCROLL_WHAT);
		}

		private void SendScrollMessage (long delayTimeInMills)
		{
			//remove messages before, keeps one message is running at most 
			handler.RemoveMessages (SCROLL_WHAT);
			handler.SendEmptyMessageDelayed (SCROLL_WHAT, delayTimeInMills);
		}



		/// <summary>
		/// set ViewPager scroller to change animation duration when sliding
		/// </summary>
		private void SetViewPagerScroller ()
		{
			try {
				//https://developer.xamarin.com/guides/android/advanced_topics/java_integration_overview/working_with_jni/
				IntPtr ViewPagerClass = JNIEnv.FindClass ("android/support/v4/view/ViewPager");
				IntPtr mScroller = JNIEnv.GetFieldID (ViewPagerClass, "mScroller", "Landroid/widget/Scroller;");
				//IntPtr sInterpolator = JNIEnv.GetFieldID (ViewPagerClass, "sInterpolator", "Landroid/view/animation/Interpolator;");
				scroller = new CustomDurationScroller (Context);
				JNIEnv.SetField (this.Handle, mScroller, scroller.Handle);

				//Field scrollerField = this.Class.GetField ("mScroller");
				//scrollerField.Accessible = true;
				//Field interpolatorField = this.Class.GetDeclaredField ("sInterpolator");
				//interpolatorField.Accessible = true;
				//scroller = new CustomDurationScroller (Context, (IInterpolator)interpolatorField.Get (null));
				//scrollerField.Set (this, scroller);
			} catch (JException e) {
				e.PrintStackTrace ();
			}
		}


		/// <summary>
		/// scroll only once
		/// </summary>
		public void scrollOnce ()
		{
			PagerAdapter adapter = Adapter;
			int currentItem = CurrentItem;
			int totalCount;
			if (adapter == null || (totalCount = adapter.Count) <= 1) {
				return;
			}

			int nextItem = (Direction == LEFT) ? --currentItem : ++currentItem;
			if (nextItem < 0) {
				if (IsCycle) {
					SetCurrentItem (totalCount - 1, IsBorderAnimation);
				}
			} else if (nextItem == totalCount) {
				if (IsCycle) {
					SetCurrentItem (0, IsBorderAnimation);
				}
			} else {
				SetCurrentItem (nextItem, true);
			}
		}


		public override bool DispatchTouchEvent (Android.Views.MotionEvent e)
		{
			int action = MotionEventCompat.GetActionMasked (e);

			if (StopScrollWhenTouch) {
				if ((action == (int)MotionEventActions.Down) && isAutoScroll) {
					isStopByTouch = true;
					StopAutoScroll ();
				} else if (e.Action == MotionEventActions.Up && isStopByTouch) {
					StartAutoScroll ();
				}
			}

			if (SlideBorderMode == SLIDE_BORDER_MODE_TO_PARENT || SlideBorderMode == SLIDE_BORDER_MODE_CYCLE) {
				touchX = e.GetX ();
				if (e.Action == MotionEventActions.Down) {
					downX = touchX;
				}
				int currentItem = CurrentItem;
				PagerAdapter adapter = Adapter;
				int pageCount = adapter == null ? 0 : adapter.Count;
				//current index is first one and slide to right or current index is last one and slide to left.
				//if slide border mode is to parent, then requestDisallowInterceptTouchEvent false.
				//else scroll to last one when current item is first one, scroll to first one when current item is last one.
				if ((currentItem == 0 && downX <= touchX) || (currentItem == pageCount - 1 && downX >= touchX)) {
					if (SlideBorderMode == SLIDE_BORDER_MODE_TO_PARENT) {
						Parent.RequestDisallowInterceptTouchEvent (false);
					} else {
						if (pageCount > 1) {
							SetCurrentItem (pageCount - currentItem - 1, IsBorderAnimation);
						}
						Parent.RequestDisallowInterceptTouchEvent (true);
					}
					return base.DispatchTouchEvent (e);
				}
			}
			Parent.RequestDisallowInterceptTouchEvent (true);

			return base.DispatchTouchEvent (e);
		}


		private class MyHandler : Handler
		{

			private  WeakReference<AutoScrollViewPager> bannerViewPager;

			public MyHandler (AutoScrollViewPager bannerViewPager)
			{
				this.bannerViewPager = new WeakReference<AutoScrollViewPager> (bannerViewPager);
			}


			public override void HandleMessage (Message msg)
			{
				base.HandleMessage (msg);

				switch (msg.What) {
				case SCROLL_WHAT:
					AutoScrollViewPager pager;
					if (bannerViewPager.TryGetTarget (out pager)) {
						pager.scroller.SetScrollDurationFactor (pager.AutoScrollFactor);
						pager.scrollOnce ();
						pager.scroller.SetScrollDurationFactor (pager.SwipeScrollFactor);
						pager.SendScrollMessage (pager.Interval + pager.scroller.Duration);
					}
					break;
				default:
					break;
				}
			}
		}



	}
}

