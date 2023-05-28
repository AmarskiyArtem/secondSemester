namespace CatchTheButton;

/// <summary>
/// Catch a button game
/// </summary>
public partial class GameFrom : Form
{
    private Random random = new();

    /// <summary>
    /// Form constructor
    /// </summary>
    public GameFrom()
    {
        InitializeComponent();
    }

    private void button_MouseMove(object sender, MouseEventArgs e)
    {
        var possiblePosition = new Point(random.Next(this.Width - button.Width - 100), 
            random.Next(this.Height - button.Height - 100));
        while (Math.Abs(Control.MousePosition.X - possiblePosition.X) < 150
            || Math.Abs(Control.MousePosition.Y - possiblePosition.Y) < 100)
        {
            possiblePosition = new Point(random.Next(this.Width - button.Width - 100),
            random.Next(this.Height - button.Height - 100));
        }
        button.Location = possiblePosition;
    }

    private void button_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
