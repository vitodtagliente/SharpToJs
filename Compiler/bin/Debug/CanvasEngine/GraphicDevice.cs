using System;
using SharpToJs;

namespace CanvasEngine.Graphics
{   
    public class GraphicDevice
    {
        public JsNative canvas = null;
        public JsNative context = null;
        
        bool fullscreen = false;
        public bool Fullscreen
        {   
            get { return fullscreen; }
            set { 
                fullscreen = value; 
                if(fullscreen)
                    Resize(window.innerWidth, window.innerHeight);
            }
        }
        
        public int Width
        {
            get { return canvas.width; }
        }
        
        public int Height
        {   
            get { return canvas.height; }
        }
        
        bool deviceReady = false;
        string lastClearColor = "#000";
    
        public GraphicDevice(string canvas_id)
        {
            canvas = document.getElementById(canvas_id);
            if(canvas != null)
            {
                context = canvas.getContext("2d");
                fullscreen = false;
            }
            
            if(context != null)
                deviceReady = true;
            else console.log( "Unable to initializate context 2d" );
            
            var bindThis = this;
        }
		
        public void OnResize(){}
        
        public void Resize(int width, int height)
        {
            canvas.width = width;
            canvas.heigth = height;
        }
        
        public void Clear(string color)
        {
            if(deviceReady)
            {
				if(color != null)
					lastClearColor = color;
                context.fillStyle = lastClearColor;
                context.fillRect(0, 0, Width, Height);
            }
        }
    }
}