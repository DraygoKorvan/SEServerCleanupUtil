using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Reflection;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using Sandbox.Common.ObjectBuilders;
using Sandbox.Common.ObjectBuilders.VRageData;

using SEModAPIExtensions.API.Plugin;
using SEModAPIExtensions.API.Plugin.Events;

using SEModAPIInternal.API.Common;
using SEModAPIInternal.API.Entity;
using SEModAPIInternal.API.Entity.Sector.SectorObject;
using SEModAPIInternal.API.Entity.Sector.SectorObject.CubeGrid;
using SEModAPIInternal.API.Entity.Sector.SectorObject.CubeGrid.CubeBlock;
using SEModAPIInternal.API.Server;
using SEModAPIInternal.Support;

using SEModAPI.API;

using VRageMath;
using VRage.Common.Utils;



namespace SEServerCleanup
{
	[Serializable()]
	public class SEServerCleanup : PluginBase
	{
		
		#region "Attributes"


		#endregion

		#region "Constructors and Initializers"

		public void Core()
		{
			Console.WriteLine("SEServerCleanup '" + Id.ToString() + "' constructed!");	
		}

		public override void Init()
		{

			Console.WriteLine("SEServerCleanup '" + Id.ToString() + "' initialized!");

		}

		#endregion

		#region "Properties"

		[Browsable(true)]
		[ReadOnly(true)]
		public string Location
		{
			get { return System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\"; }

		}
		#endregion

		#region "Methods"

		public void saveXML()
		{

			XmlSerializer x = new XmlSerializer(typeof(SEServerCleanup));
			TextWriter writer = new StreamWriter(Location + "Configuration.xml");
			x.Serialize(writer, this);
			writer.Close();

		}
		public void loadXML()
		{
			try
			{
				if (File.Exists(Location + "Configuration.xml"))
				{
					XmlSerializer x = new XmlSerializer(typeof(SEServerCleanup));
					TextReader reader = new StreamReader(Location + "Configuration.xml");
					SEServerCleanup obj = (SEServerCleanup)x.Deserialize(reader);

					reader.Close();
				}
			}
			catch (Exception ex)
			{
				LogManager.APILog.WriteLineAndConsole("Could not load configuration:" + ex.ToString());
			}

		}



		#region "EventHandlers"

		public override void Update()
		{
		
		}

		public override void Shutdown()
		{
			saveXML();

			return;
		}


		#endregion



		#endregion
	}
}
