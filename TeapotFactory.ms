global TeapotFactory
(
	struct TeapotFactoryOps
	(

		fn OnButtonClickedFrom str zahl =
		(
			print str
			print (zahl as string)
		),
		
		fn OnButtonClicked  =
		(
			if selection.count >= 1 then return #(selection[1].name)
			#("")
		),
		
		fn Run =
		(
			 root = pathconfig.removePathLeaf  (getthisscriptfilename())
			 dlllocation = pathConfig.appendPath root @"TeapotFactoryMaxPlugin\bin\Debug\TeapotFactoryMaxPlugin.dll"
			 assemblyBytes = (dotnetClass "System.IO.File").ReadAllBytes dlllocation
			 myAssembly = (dotnetClass "System.Reflection.Assembly").Load assemblyBytes
			 entryClass = myAssembly.GetType("TeapotFactoryMaxPlugin.EntryPoint")
			 entryPointInstance = (dotNetClass "System.Activator").CreateInstance entryClass
			 entryPointInstance.Execute ""
		)
	)
	TeapotFactory = TeapotFactoryOps()
	TeapotFactory.Run()
	Ok
)
 