using System;
using Xamarin.Platform;

namespace Xamarin.Forms
{
	public partial class Stepper : IStepper
	{
		void IRange.ValueChanged()
		{
			throw new NotImplementedException();
		}
	}
}