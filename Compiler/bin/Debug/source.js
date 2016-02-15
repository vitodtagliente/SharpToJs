
/*
 * Build with SharpToJs Compiler
 * Author: Vito Domenico Tagliente
 */

var CanvasEngine.Graphics = CanvasEngine.Graphics || {};

CanvasEngine.Graphics.GraphicDevice = function(var canvas_id){

	this.canvas;
	this.context;
	var fullscreen;

	Object.defineProperty( this, 'Fullscreen', {
		get: function()
		{
			return fullscreen;
		}
		set: function( value )
		{
			fullscreen = value;
			if (fullscreen )
				Resize( 0, 0, JsNative( "window" ).innerWidth, JsNative( "window" ).innerHeight );
		}

	} );

	Object.defineProperty( this, 'Width', {
		get: function()
		{
			return canvas.width;
		}

	} );

	Object.defineProperty( this, 'Heigth', {
		get: function()
		{
			return canvas.height;
		}

	} );
	var deviceReady = false;
	var lastClearColor = "#000";

	this.Foo = function()
	{
		for(var i = 0; i < A.count; i++)
			debug( i );
		do
		{
			var i = 0;
			i = 9 + 5;
		}
		while ( i < 9 );
		while ( true )
		{
			i += 9;
		}

	}

	this.OnResize = function()
	{
	}

	this.Resize = function(var width, var height)
	{
		canvas.width = width;
		canvas.heigth = height;
	}

	this.Clear = function()
	{
		Clear( lastClearColor );
	}

	this.Clear = function(var color)
	{
		if (deviceReady )
		{
			lastClearColor = color;
			context.fillStyle = lastClearColor;
			context.fillRect( 0, 0, Width, Height );
		}

	}

	// Constructor

	canvas = JsNative( "document" ).getElementById( canvas_id );
	if (canvas !=  )
	{
		context = canvas.getContext( "2d" );
		fullscreen = false;
	}

	if (context !=  )
		deviceReady = true;
	else
		JsNative( "console" ).log( "Unable to initializate context 2d" );
	var bindThis = this;


}



