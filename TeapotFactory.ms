global TeapotFactory
(
	struct TeapotFactoryOps
	(
		maxportal = undefined,
		
		
		--// C# -> MaxScript
		fn CreateTeapot =
		(
			--// this function will be called from the C# . Now u can control the behavior of the C# App with maxscript
			print "Called from C#!"
			Teapot()
		),
		
		
		--// MaxScript -> C#
		fn CallBackToStaticMethod = 
		(		
			--// this function shows how to call  - from maxscript - to a static method  inside the static MaxPortal class in C#
			local method = maxportal.GetMethod("TeapotCreatedFeedback")
			method.Invoke undefined undefined
		),
		
		
		--// MaxScript -> C#
		fn OpenMainWindow =
		(
			local method = maxportal.GetMethod("OpenMainWindow")
			method.Invoke undefined undefined
		),
		
		
		fn LoadMaxPortal =
		(
			local root = pathconfig.removePathLeaf  (getthisscriptfilename())
			local dlllocation = pathConfig.appendPath root @"TeapotFactoryMaxPlugin\bin\Debug\TeapotFactoryMaxPlugin.dll"
			local assemblyBytes = (dotnetClass "System.IO.File").ReadAllBytes dlllocation
			local myAssembly = (dotnetClass "System.Reflection.Assembly").Load assemblyBytes
			this.maxportal = myAssembly.GetType("TeapotFactoryMaxPlugin.MaxPortal")	
		),
		
		
		fn Run =
		(			
			LoadMaxPortal()
			OpenMainWindow()
		)
		
	)
	TeapotFactory = TeapotFactoryOps()
	TeapotFactory.Run()
	Ok
)


------

fn callbackfunction =
(
	thenodecreated = callbacks.notificationParam()
	if classof thenodecreated == Teapot then 
		TeapotFactory.CallBackToStaticMethod()
)
callbacks.removeScripts  #nodeCreated id:#nodeCreatedMaybeTeapot
callbacks.addScript #nodeCreated "callbackfunction()" id:#nodeCreatedMaybeTeapot
