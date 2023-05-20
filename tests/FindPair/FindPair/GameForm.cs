namespace FindPairForm;

public partial class GameForm : Form
{
    public GameForm(int arg)
    {
        InitializeComponent();
        var tableLayoutPanel = new TableLayoutPanel();
        tableLayoutPanel.Dock = DockStyle.Fill;
        tableLayoutPanel.ColumnCount = arg;
        tableLayoutPanel.RowCount = arg;
        for (int row = 0; row < arg; row++)
        {
            for (int column = 0; column < arg; column++)
            {
                Button button = new Button();
                button.Text = $"Button {row * arg + column + 1}";
                button.Dock = DockStyle.Fill;
                tableLayoutPanel.Controls.Add(button, column, row);
            }
        }
        for (int i = 0; i < arg; i++)
        {
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / arg));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / arg));
        }
        Controls.Add(tableLayoutPanel);
    }


}
