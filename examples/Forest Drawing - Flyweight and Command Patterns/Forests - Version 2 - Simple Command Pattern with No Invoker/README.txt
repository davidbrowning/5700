This version of the Forest drawing program makes the following enhancements:

	-	Decouple the GUI from the drawing components using a simple Command pattern (one without an invoker)
	-	Convert the TreeFactory to a singleton
	-	Other minor improvement

Adding the Command layer makes takes the control logic out of the GUI and put it in a place that is more easily tested.  Also, the GUI’s logic is simpler.  However, the real motivation for added the extra Command layer will become evident later when we add an Invoker and an Undo feature.