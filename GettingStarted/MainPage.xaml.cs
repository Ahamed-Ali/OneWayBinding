

using Microsoft.Maui.Graphics.Text;

namespace GettingStarted;

public partial class MainPage : ContentPage
{
    private string entryText = "This is draw Text" ;
    public string EntryText
    {
        get { return entryText; }
        set
        {
            entryText = value; OnPropertyChanged(nameof(EntryText));
        }
    }
    public MainPage()
	{
		InitializeComponent();	
        this.BindingContext = this;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (this.EntryText == "This is draw Text")
        {
            this.EntryText = "Change Text";
        }
        else
        {
            this.EntryText = "This is draw Text";
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }
}


public class CustomDrawing : GraphicsView, IDrawable
{
    public CustomDrawing()
    {
       Drawable = this;
    }

    public static readonly BindableProperty NewTextProperty = BindableProperty.Create(nameof(NewText), typeof(string), typeof(CustomDrawing), string.Empty, BindingMode.TwoWay, null, OnNewTextPropertyChanged);

    private static void OnNewTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {

        CustomDrawing customControl = bindable as CustomDrawing;
        customControl.NewText = (string)newValue;
        customControl.Invalidate();
    }

    public string NewText
    {
        get { return (string)GetValue(NewTextProperty); }
        set { SetValue(NewTextProperty, value); }

    }
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.SaveState();
        canvas.FontColor = Colors.Blue;
        canvas.FontSize = 18;
        canvas.DrawString(this.NewText, 10, 10, 100, 100, HorizontalAlignment.Center, VerticalAlignment.Center);
        canvas.RestoreState();
    }
}