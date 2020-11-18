using System;
using System.Collections.Generic;
using CoreGraphics;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.ControlGallery.iOS;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;
using static Xamarin.Forms.Controls.Issues.Issue9660;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]

namespace Xamarin.Forms.ControlGallery.iOS
{
	class CustomMKAnnotationView : MKAnnotationView
	{
		public string Name { get; set; }

		public string TimeStamp { get; set; }

		public CustomMKAnnotationView(IMKAnnotation annotation, string id) : base(annotation, id)
		{
		}
	}

	class CustomMapRenderer : MapRenderer
	{
		//  List<CustomPin> customPins;

		protected override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
		{
			if (annotation is MKUserLocation)
				return null;

			var customPin = GetCustomPin(annotation as MKPointAnnotation);

			if (customPin == null)
				return null;

			MKAnnotationView annotationView = mapView.DequeueReusableAnnotation(customPin.MarkerId.ToString());
			if (annotationView == null)
			{
				annotationView = new CustomMKAnnotationView(annotation, customPin.Name);
				switch (customPin.Address)
				{
					case "#FF808080":
						annotationView.Image = UIImage.FromFile("pin.png");
						break;

					case "#FF00FF00":
						annotationView.Image = UIImage.FromFile("pin0.png");
						break;

					case "#FFFF0000":
						annotationView.Image = UIImage.FromFile("pin1.png");
						break;

					case "#FF0000FF":
						annotationView.Image = UIImage.FromFile("pin2.png");
						break;

					case "#FF00FFFF":
						annotationView.Image = UIImage.FromFile("pin3.png");
						break;

					case "#FFFF00FF":
						annotationView.Image = UIImage.FromFile("pin4.png");
						break;

					case "#FFFFFF00":
						annotationView.Image = UIImage.FromFile("pin5.png");
						break;

					case "#FFFF8000":
						annotationView.Image = UIImage.FromFile("pin6.png");
						break;

					case "#FF00C5FF":
						annotationView.Image = UIImage.FromFile("pin7.png");
						break;

					case "#FFAF00FF":
						annotationView.Image = UIImage.FromFile("pin8.png");
						break;

					case "Waypoint":
						annotationView.Image = UIImage.FromFile("Waypoint.png");
						break;

				}

				annotationView.CenterOffset = new CGPoint(0, -10);
				customPin.Address = customPin.TimeStamp;
				((CustomMKAnnotationView)annotationView).Name = customPin.Name;
				((CustomMKAnnotationView)annotationView).TimeStamp = customPin.TimeStamp;
			}
			annotationView.CanShowCallout = true;

			return annotationView;

		}

		CustomPin GetCustomPin(MKPointAnnotation annotation)
		{
			var position = new Position(annotation.Coordinate.Latitude, annotation.Coordinate.Longitude);
			foreach (var pin in (Element as CustomMap).CustomPins)
			{
				if (pin.Position == position)
				{
					return pin;
				}
			}

			return null;
		}
	}
}
