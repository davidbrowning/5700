This version of the Forest drawing program makes the following enhancements:

	- Addition on an undo feature
	- Addition of a redo feaure

Also, for any future versions, it was decided the system will NOT be extended to allow multiple drawings to be open at the same time.  So, because they will only ever be one drawing, the Drawing class has been converted to a singleton.  Furthermore, since there is only one drawing, there only needs to be one invoker, and the Invoker class has been converted to an singleton.  These changes simplified the CommandFactory and Command classes.