
/*
 * Build with SharpToJs Compiler
 * Author: Vito Domenico Tagliente
 */


CanvasEngine.Graphics.Renderer2 = function(device, GraphicDevice){

	this.Device;
	this.style = "fill";
	this.color = "black";

	Object.defineProperty( this, 'Context', {
		get: function()
		{
			return this.Device.Context;
		}
	} );

	this.Begin = function()
	{
		this.Context.beginPath(  );
	}

	this.Save = function()
	{
		this.Context.save(  );
	}

	this.Restore = function()
	{
		this.Context.restore(  );
	}

	this.End = function()
	{
		if ( this.style == "fill" )
		{
			this.Context.fill(  );
			return;
		}

		this.Context.stroke(  );
	}

	this.Rect = function(point2, Point2, width, height)
	{
		if ( this.style == "fill" )
		{
			this.Context.fillRect( point2.x, point2.y, width, height );
			return;
		}

		this.Context.strokeRect( point2.x, point2.y, width, height );
	}

	// Constructor

	this.Device = device;


}



