using System.Reflection;
using System.Runtime.CompilerServices;
using Mono.Addins;

[assembly: Addin("google_the_crop", "1.1", Category = "Other")]
[assembly: AddinName ("Google selected part of image")]
[assembly: AddinDescription ("Google for selected part of image without any Q!")]
[assembly: AddinDependency ("Pinta", "1.6")]

// Information about this assembly is defined by the following attributes.
// Change them to the values specific to your project.

[assembly: AssemblyTitle("google_the_crop")]
[assembly: AssemblyDescription("Plugin for Pinta")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("by.styx")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("Mikhail Pabalavets")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion("1.1.*")]

// The following attributes are used to specify the signing key for the assembly,
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]
