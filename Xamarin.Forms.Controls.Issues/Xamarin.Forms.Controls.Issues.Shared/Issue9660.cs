using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Maps;

#if UITEST
using Xamarin.Forms.Core.UITests;
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace Xamarin.Forms.Controls.Issues
{
#if UITEST
	[Category(UITestCategories.ManualReview)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 9660, "Xamarin.Forms.Maps Custom pins disappearing on iOS", PlatformAffected.iOS)]
	public class Issue9660 : TestContentPage // or TestFlyoutPage, etc ...
	{
		static class RouteWaypoints
		{
			public static string RouteWayPointPositions { get; set; } = "01 East Cape Lighthouse,178.5481529899814,-37.68892413267409,0,02 Bay of Plenty coast (anywhere interesting),177.5254701509655,-37.7876380739008,0,03 Motu Road (something you find interesting),177.4737611475357,-38.07831630263716,0,04 Rere Rock Slide (preferably while sliding down it),177.5900157314073,-38.53922914398245,0,05 Lake Waikaremoana,177.1054275708329,-38.76976128879194,0,06 Pou at corner of SH38 and Minginui Road [Te Whaiti],176.7816922366107,-38.58648758632847,0,07 Waiotapu Thermal Mudpool,176.3696779033531,-38.34199286155479,0,08 Centre of the North Island,175.6728880790941,-38.5252316144062,0,09 Mangamataha Bridge (the longest Timber Trail bridge),175.4826615784133,-38.6564831311359,0,10 Hobbit tunnel,174.8016152342727,-39.01988095914585,2.07386520347655,11 Te Rewa Rewa Bridge,174.1123303149498,-39.03777119959926,0,12 Cape Egmont Lighthouse,173.7550220271562,-39.27662321478341,0";
		}

		protected override void Init()
		{
			DisplayMap();
		}

		object DisplayMap()
		{
			CustomMap customMap = new CustomMap();
			customMap.MapType = MapType.Street;

			var grid = new Grid();

			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30, GridUnitType.Star) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

			grid.Children.Add(view: customMap, 0, 0);
			Grid.SetRowSpan(customMap, 5);
			Grid.SetColumnSpan(customMap, 5);


			//  route waypoints
			string waypoints = RouteWaypoints.RouteWayPointPositions;
			string[] WPLatLongs = waypoints.Split(',');

			int wi = 0;
			customMap.CustomPins = new List<CustomPin>();
			do
			{
				CustomPin pin = new CustomPin
				{
					Type = PinType.Place,
					Position = new Position(Convert.ToDouble(WPLatLongs[wi + 2]), Convert.ToDouble(WPLatLongs[wi + 1])),
					Label = WPLatLongs[wi],
					Address = "Waypoint",
					Name = "Name text",
					TimeStamp = ""
				};
				customMap.CustomPins.Add(pin);
				customMap.Pins.Add(pin);


				wi = wi + 4;
			}
			while (wi + 1 < WPLatLongs.Length);

			//Globals.RaceRoute.StrokeColor = Color.Green;
			//Globals.RaceRoute.StrokeWidth = 4;

			//customMap.MapElements.Add(RaceRoute);

			Position middle = new Position(-38.52, 176.1);
			MapSpan mapspan = new MapSpan(middle, 6, 6);
			customMap.MoveToRegion(mapspan);


			Content = grid;    //moved here for ios issue
			return null;
		}

		public class CustomMap : Map
		{
			public List<CustomPin> CustomPins { get; set; }
		}

		public class CustomPin : Pin
		{
			public string Name { get; set; }
			public string TimeStamp { get; set; }
		}
	}
}