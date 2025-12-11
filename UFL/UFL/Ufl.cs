using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace UFL;

/// <summary>
/// UghLang First Library
/// </summary>
public static class Ufl
{
    private static RenderWindow window;
    
    public static RenderWindow InitWindow(int width, int height, string title)
    {
        window = new RenderWindow(new VideoMode((uint)width, (uint)height), title);
        window.SetFramerateLimit(60);
        window.Closed += (_, _) => window.Close();
        
        return window; 
    }
    
    public static bool ShouldClose() => window.IsOpen;
    public static void DispatchEvents() => window.DispatchEvents();
    
    public static Color GetRGBA(int r, int g, int b, int alpha) => new((byte)r, (byte)g, (byte)b, (byte)alpha);
    public static Color GetRGB(int r, int g, int b) => GetRGBA(r, g, b, 255);
    
    public static void Display() => window.Display();

   

    public static void ClearColor(Color color) => window.Clear(color);
    public static void Clear() => ClearColor(Color.Black);
    
    public static void DrawShape(Shape shape, float x, float y)
    {
        shape.Position = new Vector2f(x, y);
        window.Draw(shape);
    }
    
    public static RectangleShape Rectangle(Vector2f size, Color color)
    {
        var rectangle = new RectangleShape(size)
        {
            FillColor = color
        };
        return rectangle;
    }

    public static CircleShape Circle(float radious, Color color)
    {
        var rectangle = new CircleShape(radious)
        {
            FillColor = color
        };
        return rectangle;
    }
    
    public static Vector2f VectorTwo(float x, float y) => new(x, y);
    public static Vector3f VectorThree(float x, float y, float z) => new(x, y, z);
}

public static class UflInput
{
    public static bool IsKeyPressed(string keyStr)
    {
        if(Enum.TryParse(keyStr, true, out Keyboard.Key key))
            return Keyboard.IsKeyPressed(key);
        throw new KeyNotFoundException($"Key {keyStr} not found");
    }
}