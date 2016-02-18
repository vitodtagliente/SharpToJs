
/*
 * Build with SharpToJs Compiler
 * Author: Vito Domenico Tagliente
 */

var CanvasEngine = CanvasEngine || {};
CanvasEngine.Graphics = CanvasEngine.Graphics || {};

CanvasEngine.Graphics.GraphicDevice = function(canvas_id){

	this.canvas = null;
	this.context = null;
	var fullscreen = false;

	Object.defineProperty( this, 'Fullscreen', {
		get: function()
		{
			return fullscreen;
		}
,		set: function( value )
		{
			fullscreen = value;
			if ( fullscreen )
				this.Resize( window.innerWidth, window.innerHeight );
		}
	} );

	Object.defineProperty( this, 'Width', {
		get: function()
		{
			return this.canvas.width;
		}
	} );

	Object.defineProperty( this, 'Height', {
		get: function()
		{
			return this.canvas.height;
		}
	} );
	var deviceReady = false;
	var lastClearColor = "#000";

	this.OnResize = function()
	{
	}

	this.Resize = function(width, height)
	{
		this.canvas.width = width;
		this.canvas.heigth = height;
	}

	this.Test = function()
	{
		if ( true )
		{
			if ( true )
				if ( 8 > 9 )
					echo( true );;
		}

		else
			this.canvas.check(  );
	}

	this.Clear = function(color)
	{
		if ( deviceReady )
		{
			if ( color != null )
				lastClearColor = color;
			this.context.fillStyle = lastClearColor;
			this.context.fillRect( 0, 0, this.Width, this.Height );
		}

	}

	// Constructor

	this.canvas = document.getElementById( canvas_id );
	if ( this.canvas != null )
	{
		this.context = this.canvas.getContext( "2d" );
		fullscreen = false;
	}

	if ( this.context != null )
		deviceReady = true;
	else
		console.log( "Unable to initializate context 2d" );
	var bindThis = this;


}



