using System;
using SharpToJs;

namespace CanvasEngine.Graphics
{
	public class Renderer2
	{
		public GraphicDevice Device;
		public string style = "fill";
		public string color = "black";
		
		public JsNative Context {
			get {
				return Device.context;
			}
		}
		
		public Renderer2(GraphicDevice device)
		{
			Device = device;
		}
		
		public void Begin()
		{
			Context.beginPath()
		}
		
		public void Save()
		{
			Context.save();
		}
		
		public void Restore()
		{
			Context.restore();
		}
		
		public void End()
		{
			if( style == "fill" ){
				Context.fill();
				return;
			}
			Context.stroke();
		}
		
		public void Rect( Point2 point2, int width, int height )
		{
			if(style == "fill"){
				Context.fillRect( point2.x, point2.y, width, height );
				return;
			}
			Context.strokeRect( point2.x, point2.y, width, height );
		}
		
	}
}