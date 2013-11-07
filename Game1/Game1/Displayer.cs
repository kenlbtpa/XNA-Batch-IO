using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO; 

namespace Game1
{

    class BufChar
    {
        private char _character;
        private Color _color;
        public char Character
        {
            get { return _character; }
            set { _character = value; }
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        BufChar(char character, Color color) { _character = character; _color = color; }
    }

    class Buffer
    {

        private static SpriteFont DEFAULTFONT; 
        private static Color DEFAULTCOLOR = Color.Black; 

        private int POSX; 
        private int POSY; 
        private int BUFFERWIDTH;
        private int BUFFERHEIGHT;

        private SpriteBatch _spriteBatch; 

        private List<Tuple<string, Color, SpriteFont>> bufferData;

        private bool _display;

        public SpriteBatch SpriteBatch { get { return _spriteBatch; } set { _spriteBatch = value; } }

        public int X { get { return POSX; } set { POSX = value; } }
        public int Y { get { return POSY; } set { POSY = value; } }

        public int Width {get { return BUFFERWIDTH; } set { BUFFERWIDTH = value; }}
        public int Height { get { return BUFFERHEIGHT; } set { BUFFERHEIGHT = value; } }
        public bool Display { get { return _display; } set { _display = value; } }
        public int Count { get { return bufferData.Count; } } // Returns Count of bufferData. 

        public Tuple<string, Color, SpriteFont> this[int index]
        {
            get { return bufferData[index]; }
            set { bufferData[index] = value; }
        }

        public bool AppendString(string text)
        {
            try
            {
                bufferData.Add( new Tuple<string, Color, SpriteFont>(  text, DEFAULTCOLOR, DEFAULTFONT ) ); 
            }
            catch (Exception e)
            {
                return false; 
            }
            return true; 
        }

        /** Factory Function to Create Buffer from String **/ 
        public bool AppendString(string data, Color color, SpriteFont font)
        {
            try
            {
                bufferData.Add(new Tuple<string, Color, SpriteFont>(data, color, font)); 
            }
            catch (Exception e)
            {
                return false; 
            }
            return true; 
        }

        public bool RemoveAt(int index)
        {
            try
            {
                bufferData.RemoveAt(index);
            }
            catch (Exception e)
            {
                return false; 
            }
            return true; 
        }

        public bool InsertAt(int index, string data, Color color, SpriteFont font)
        {
            try
            {
                bufferData.Insert(index, new Tuple<string, Color, SpriteFont>(data, color, font));
            }
            catch (Exception e)
            {
                return false; 
            }
            return true; 
        }
        
        /** Drws the Buffer **/ 
        public bool Draw() 
        {
            try
            {
                foreach (Tuple<string, Color, SpriteFont> textData in bufferData)
                {
                    SpriteBatch.DrawString(textData.Item3, textData.Item1, new Vector2(0, 0), textData.Item2) ;  
                }
            }
            catch (Exception e)
            {
                return false; 
            }
            return true; 
        }

        /** Creates a Buffer with -1 width and -1 height (Negative Height means ignore width and height constraints). **/ 
        public Buffer( int x, int y, ref SpriteBatch spriteBatch , ref SpriteFont defaultFont )
        {
            POSX = x;
            POSY = y;
            BUFFERWIDTH = -1;
            BUFFERHEIGHT = -1;
            bufferData = new List<Tuple<string, Color, SpriteFont>>();
            _display = false;
            _spriteBatch = spriteBatch;
            DEFAULTFONT = defaultFont; 
        }

        /** Creates a Buffer with specified height and width **/ 
        public Buffer(int x, int y, int bufferWidth, int bufferHeight , ref SpriteBatch spriteBatch, ref SpriteFont defaultFont) 
        {
            POSX = x;
            POSY = y; 
            BUFFERWIDTH = bufferWidth;
            BUFFERHEIGHT = bufferHeight;
            bufferData = new List<Tuple<string, Color, SpriteFont>>();
            _display = false;
            _spriteBatch = spriteBatch; 
            DEFAULTFONT = defaultFont; 
        }
    }

    public class Displayer
    {
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private int _width;
        private int _height;

        private Dictionary< string , Buffer > masterBuffer; 
        /** The MasterBuffer is a list of Buffers. All Buffers are contained here.  **/ 
        /** MasterBuffer begins empty. Each Buffer can bet set to show or not. **/
        /** Each Buffer is given a name, this name must be unique. **/
        /** The Buffers themselves will be given the opportunity to be seton or off. If on, display, if off, don't display. **/ 

        /** Main Display Function 
         * Continously outputs text as long as buffer is not empty. 
         * Requires spriteBatch.Begin() and spriteBatch.End() to be called elsewhere. 
         **/ 

        /** Special Buffers:
         *  Prompt: 
         *      An empty prompt buffer is set by default. The empty prompt will be of 0 width and 0 height, and no data. 
         *      
         **/

        public bool display()
        {
            try
            {       
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false; 
            }
            return true; 
        }

        public string GenerateBufferName()
        {
            int i; 
            for (i = 1; masterBuffer.ContainsKey("Buffer" + i); i++)
            {
            }

            return "Buffer" + i;
        }



        public List<string> BufferNames
        {
            get { List<string> names = new List<string>(); for (int i = 0; i < masterBuffer.Count; i++) { names.Add(masterBuffer.Keys.ElementAt(i)); } 
                return names; 
            }
        }

        public bool AddBuffer(string name)
        {
            return AddBuffer(name, 0, 0, 0, 0); 
        }

        public bool AddBuffer(string name, int x, int y, int bufferWidth, int bufferHeight)
        {
            if (!masterBuffer.ContainsKey(name))
            {
                masterBuffer.Add( name, new Buffer( x, y, bufferWidth , bufferHeight , ref _spriteBatch , ref _font ) ); 
                return true; 
            }
            return false; 
        }


        public bool prompt(string promptstring, string[] possibleresponses, ref string result, Color color)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString()); 
                return false; 
            }
            return true; 
        }

        public Displayer(ref SpriteBatch spriteBatch, ref SpriteFont font, int WIDTH, int HEIGHT)
        {
            _spriteBatch = spriteBatch;
            _font = font;
            _width = WIDTH;
            _height = HEIGHT;

            masterBuffer = new Dictionary<string, Buffer>();
            AddBuffer("prompt", (int)(WIDTH * 0.1) , (int) (HEIGHT * 0.1) , (int)(WIDTH * 0.8) , (int)(HEIGHT * 0.8) ); // basic prompt buffer. 

        }
    }
}
