namespace WinFormsCalculator;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    protected override void OnFormClosing(FormClosingEventArgs eventArgs)
    {
        var result = MessageBox.Show("Действительно закрыть?", "",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result != DialogResult.Yes)
            eventArgs.Cancel = true;
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {

    }
}