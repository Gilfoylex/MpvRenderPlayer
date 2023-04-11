using Avalonia.Controls;
using Avalonia.Interactivity;
using MpvRenderPlayer.MPV;


namespace MpvRenderPlayer.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private MpvPlayer _player;
    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        _player = new MpvPlayer();
        var view = new MpvOpenGLView(_player);
        PlayerGrid.Children.Add(view);
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var path = _textBox.Text;
        _player.PlayUrl(path);
    }
}