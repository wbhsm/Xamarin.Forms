namespace Xamarin.Platform
{
	public static class BoxViewExtensions
	{
		public static void UpdateColor(this NativeBoxView nativeView, IBox boxView)
		{
			nativeView.Color = boxView.Color;
		}

		public static void UpdateCornerRadius(this NativeBoxView nativeView, IBox boxView)
		{
			nativeView.CornerRadius = boxView.CornerRadius;
		}
	}
}
