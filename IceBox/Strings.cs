using System;
using STRINGS;

namespace IceBox { 
	internal class STRINGS
	{
		public class BUILDINGS
		{
			public class PREFABS
			{
				public class ICEBOX
				{
					public static LocString NAME = UI.FormatAsLink("IceBox", "ICEBOX");

					public static LocString DESC = "Food spoilage can be slowed by ambient conditions as well as by refrigerators.";

					public static LocString EFFECT = string.Concat(new string[]
					{
						"Stores ",
						UI.FormatAsLink("Food", "FOOD"),
						" at an ideal ",
						UI.FormatAsLink("Temperature", "HEAT"),
						" to prevent spoilage."
					});

					public static LocString LOGIC_PORT = "Full/Not Full";

					public static LocString LOGIC_PORT_ACTIVE = "Sends a " + UI.FormatAsAutomationState("Green Signal", 0) + " when full";

					public static LocString LOGIC_PORT_INACTIVE = "Otherwise, sends a " + UI.FormatAsAutomationState("Red Signal", (UI.AutomationState)1);
				}
			}
		}
	}
}
