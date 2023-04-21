namespace WinFormsCalculator;

partial class Form1
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
        panel1 = new Panel();
        panel2 = new Panel();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Dock = DockStyle.Top;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(386, 55);
        panel1.TabIndex = 0;
        panel1.Paint += panel1_Paint;
        // 
        // panel2
        // 
        panel2.Dock = DockStyle.Top;
        panel2.Location = new Point(0, 55);
        panel2.Name = "panel2";
        panel2.Size = new Size(386, 55);
        panel2.TabIndex = 0;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(386, 498);
        Controls.Add(panel2);
        Controls.Add(panel1);
        MinimumSize = new Size(264, 470);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Calculator";
        ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private Panel panel2;
}