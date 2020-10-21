using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms
{
	public static class FormsHandlers
	{
		public static void InitHandlers()
		{
			Xamarin.Platform.Registrar.Handlers.Register(typeof(Slider), typeof(Xamarin.Platform.Handlers.SliderHandler));
			//Xamarin.Platform.Registrar.Handlers.Register(typeof(Button), typeof(Xamarin.Platform.Handlers.ButtonHandler));
			//RegistrarHandlers.Handlers.Register<Xamarin.Forms.StackLayout, Xamarin.Platform.Handlers.LayoutHandler>();
		}
	}
}
