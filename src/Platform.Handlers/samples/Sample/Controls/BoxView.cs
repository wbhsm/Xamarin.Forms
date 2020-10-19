using Xamarin.Forms;
using Xamarin.Platform;

namespace Sample
{
	public class BoxView : View, IBox
	{
		public Color Color { get; set; }

		public CornerRadius CornerRadius { get; set; }
	}
}