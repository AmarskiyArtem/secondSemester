namespace CatchTheButton;

partial class GameFrom
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button = new Button();
        SuspendLayout();
        // 
        // button
        // 
        button.Location = new Point(141, 116);
        button.Name = "button";
        button.Size = new Size(150, 100);
        button.TabIndex = 0;
        button.Text = "New Quake";
        button.UseVisualStyleBackColor = true;
        button.MouseMove += button_MouseMove;
        button.Click += button_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 453);
        Controls.Add(button);
        MinimumSize = new Size(500, 500);
        Name = "GameForm";
        Text = "Catch the button game";
        ResumeLayout(false);
    }

    #endregion

    private Button button;
}
