namespace Xamarin.Platform.Handlers
{
	public partial class BoxViewHandler : AbstractViewHandler<IBox, NativeBoxView>
	{
		protected override NativeBoxView CreateView()
		{
			return new NativeBoxView(Context);
		}

		public override void TearDown()
		{
			TypedNativeView?.Dispose();
			base.TearDown();
		}
	}
}