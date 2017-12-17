using System.Collections.Generic;

namespace AssemblyReport
{
	public class MainAssembly
	{
		public string AssemblyName { get; set; }
		public string AssemblyMark { get; set; }
		public int PhaseNumber { get; set; }
		public List<SubAssembly> SubAssemblies { get; set; }
	}
}