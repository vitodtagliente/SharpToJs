using System;
using SharpToJs;

namespace CanvasEngine.Graphics
{   
    public class GraphicDevice : MonoBehaviour
    {
        public JsNative canvas;
        public JsNative context;
        
        bool fullscreen;
        public bool Fullscreen
        {   
            get { return fullscreen; }
            set { 
                fullscreen = value; 
                if(fullscreen)
                    Resize(0,0, JsNative("window").innerWidth, JsNative("window").innerHeight);
            }
        }
        
        public int Width
        {
            get { return canvas.width; }
        }
        
        public int Heigth
        {   
            get { return canvas.height; }
        }
        
        bool deviceReady = false;
        string lastClearColor = "#000";
    
        public GraphicDevice(string canvas_id)
        {
            canvas = JsNative("document").getElementById(canvas_id);
            if(canvas != null)
            {
                context = canvas.getContext("2d");
                fullscreen = false;
            }
            
            if(context != null)
                deviceReady = true;
            else JsNative("console").log( "Unable to initializate context 2d" );
            
            var bindThis = this;
        }
        
        public void Foo()
        {
            for(int i = 0; i < A.count; i++)
                debug(i);
                
            do {
                int i = 0;
                i = 9 + 5;
            }
            while(i < 9);
            
            while(true)
            {
                i+=9;
            }
            
            foreach(int a in GetChildren())
            {
                a.id = 7;
            }
        }
        
        public void OnResize(){}
        
        public void Resize(int width, int height)
        {
            canvas.width = width;
            canvas.heigth = height;
        }
        
        public void Clear()
        {   
            Clear(lastClearColor);
        }
        
        public void Clear(string color)
        {
            if(deviceReady)
            {
                lastClearColor = color;
                context.fillStyle = lastClearColor;
                context.fillRect(0, 0, Width, Height);
            }
        }
    }
}