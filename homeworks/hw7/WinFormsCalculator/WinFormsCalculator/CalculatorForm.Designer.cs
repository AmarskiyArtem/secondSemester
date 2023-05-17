namespace WinFormsCalculator;

partial class CalculatorForm
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
        tableLayoutPanel1 = new TableLayoutPanel();
        clearButton = new Button();
        multiplicationButton = new Button();
        divisionButton = new Button();
        sighButton = new Button();
        sevenButton = new Button();
        eightButton = new Button();
        nineButton = new Button();
        fourButton = new Button();
        fiveButton = new Button();
        sixButton = new Button();
        substructionButton = new Button();
        zeroButton = new Button();
        oneButton = new Button();
        twoButton = new Button();
        threeButton = new Button();
        additionButton = new Button();
        equalButton = new Button();
        result = new Label();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tableLayoutPanel1.ColumnCount = 4;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.Controls.Add(clearButton, 0, 1);
        tableLayoutPanel1.Controls.Add(multiplicationButton, 3, 2);
        tableLayoutPanel1.Controls.Add(divisionButton, 3, 1);
        tableLayoutPanel1.Controls.Add(sighButton, 2, 1);
        tableLayoutPanel1.Controls.Add(sevenButton, 0, 2);
        tableLayoutPanel1.Controls.Add(eightButton, 1, 2);
        tableLayoutPanel1.Controls.Add(nineButton, 2, 2);
        tableLayoutPanel1.Controls.Add(fourButton, 0, 3);
        tableLayoutPanel1.Controls.Add(fiveButton, 1, 3);
        tableLayoutPanel1.Controls.Add(sixButton, 2, 3);
        tableLayoutPanel1.Controls.Add(substructionButton, 3, 3);
        tableLayoutPanel1.Controls.Add(zeroButton, 0, 5);
        tableLayoutPanel1.Controls.Add(oneButton, 0, 4);
        tableLayoutPanel1.Controls.Add(twoButton, 1, 4);
        tableLayoutPanel1.Controls.Add(threeButton, 2, 4);
        tableLayoutPanel1.Controls.Add(additionButton, 3, 4);
        tableLayoutPanel1.Controls.Add(equalButton, 3, 5);
        tableLayoutPanel1.Controls.Add(result, 0, 0);
        tableLayoutPanel1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 6;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 27F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14F));
        tableLayoutPanel1.Size = new Size(457, 485);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // clearButton
        // 
        tableLayoutPanel1.SetColumnSpan(clearButton, 2);
        clearButton.Dock = DockStyle.Fill;
        clearButton.Location = new Point(3, 146);
        clearButton.Name = "clearButton";
        clearButton.Size = new Size(220, 63);
        clearButton.TabIndex = 1;
        clearButton.Text = "C";
        clearButton.TextImageRelation = TextImageRelation.ImageAboveText;
        clearButton.UseVisualStyleBackColor = true;
        clearButton.Click += ClearClick;
        // 
        // multiplicationButton
        // 
        multiplicationButton.Dock = DockStyle.Fill;
        multiplicationButton.Location = new Point(347, 215);
        multiplicationButton.Name = "multiplicationButton";
        multiplicationButton.Size = new Size(107, 61);
        multiplicationButton.TabIndex = 4;
        multiplicationButton.Text = "x";
        multiplicationButton.UseVisualStyleBackColor = true;
        multiplicationButton.Click += OperationClick;
        // 
        // divisionButton
        // 
        divisionButton.Dock = DockStyle.Fill;
        divisionButton.Location = new Point(347, 146);
        divisionButton.Name = "divisionButton";
        divisionButton.Size = new Size(107, 63);
        divisionButton.TabIndex = 3;
        divisionButton.Text = "÷";
        divisionButton.UseVisualStyleBackColor = true;
        divisionButton.Click += OperationClick;
        // 
        // sighButton
        // 
        sighButton.Dock = DockStyle.Fill;
        sighButton.Location = new Point(229, 146);
        sighButton.Name = "sighButton";
        sighButton.Size = new Size(112, 63);
        sighButton.TabIndex = 2;
        sighButton.Text = "+/-";
        sighButton.UseVisualStyleBackColor = true;
        sighButton.Click += SignClick;
        // 
        // sevenButton
        // 
        sevenButton.Dock = DockStyle.Fill;
        sevenButton.Location = new Point(3, 215);
        sevenButton.Name = "sevenButton";
        sevenButton.Size = new Size(106, 61);
        sevenButton.TabIndex = 5;
        sevenButton.Text = "7";
        sevenButton.UseVisualStyleBackColor = true;
        sevenButton.Click += NumberClick;
        // 
        // eightButton
        // 
        eightButton.Dock = DockStyle.Fill;
        eightButton.Location = new Point(115, 215);
        eightButton.Name = "eightButton";
        eightButton.Size = new Size(108, 61);
        eightButton.TabIndex = 6;
        eightButton.Text = "8";
        eightButton.UseVisualStyleBackColor = true;
        eightButton.Click += NumberClick;
        // 
        // nineButton
        // 
        nineButton.Dock = DockStyle.Fill;
        nineButton.Location = new Point(229, 215);
        nineButton.Name = "nineButton";
        nineButton.Size = new Size(112, 61);
        nineButton.TabIndex = 7;
        nineButton.Text = "9";
        nineButton.UseVisualStyleBackColor = true;
        nineButton.Click += NumberClick;
        // 
        // fourButton
        // 
        fourButton.Dock = DockStyle.Fill;
        fourButton.Location = new Point(3, 282);
        fourButton.Name = "fourButton";
        fourButton.Size = new Size(106, 65);
        fourButton.TabIndex = 8;
        fourButton.Text = "4";
        fourButton.UseVisualStyleBackColor = true;
        fourButton.Click += NumberClick;
        // 
        // fiveButton
        // 
        fiveButton.Dock = DockStyle.Fill;
        fiveButton.Location = new Point(115, 282);
        fiveButton.Name = "fiveButton";
        fiveButton.Size = new Size(108, 65);
        fiveButton.TabIndex = 9;
        fiveButton.Text = "5";
        fiveButton.UseVisualStyleBackColor = true;
        fiveButton.Click += NumberClick;
        // 
        // sixButton
        // 
        sixButton.Dock = DockStyle.Fill;
        sixButton.Location = new Point(229, 282);
        sixButton.Name = "sixButton";
        sixButton.Size = new Size(112, 65);
        sixButton.TabIndex = 10;
        sixButton.Text = "6";
        sixButton.UseVisualStyleBackColor = true;
        sixButton.Click += NumberClick;
        // 
        // substructionButton
        // 
        substructionButton.Dock = DockStyle.Fill;
        substructionButton.Location = new Point(347, 282);
        substructionButton.Name = "substructionButton";
        substructionButton.Size = new Size(107, 65);
        substructionButton.TabIndex = 11;
        substructionButton.Text = "-";
        substructionButton.UseVisualStyleBackColor = true;
        substructionButton.Click += OperationClick;
        // 
        // zeroButton
        // 
        tableLayoutPanel1.SetColumnSpan(zeroButton, 3);
        zeroButton.Dock = DockStyle.Fill;
        zeroButton.Location = new Point(3, 423);
        zeroButton.Name = "zeroButton";
        zeroButton.Size = new Size(338, 59);
        zeroButton.TabIndex = 12;
        zeroButton.Text = "0";
        zeroButton.UseVisualStyleBackColor = true;
        zeroButton.Click += NumberClick;
        // 
        // oneButton
        // 
        oneButton.Dock = DockStyle.Fill;
        oneButton.Location = new Point(3, 353);
        oneButton.Name = "oneButton";
        oneButton.Size = new Size(106, 64);
        oneButton.TabIndex = 13;
        oneButton.Text = "1";
        oneButton.UseVisualStyleBackColor = true;
        oneButton.Click += NumberClick;
        // 
        // twoButton
        // 
        twoButton.Dock = DockStyle.Fill;
        twoButton.Location = new Point(115, 353);
        twoButton.Name = "twoButton";
        twoButton.Size = new Size(108, 64);
        twoButton.TabIndex = 14;
        twoButton.Text = "2";
        twoButton.UseVisualStyleBackColor = true;
        twoButton.Click += NumberClick;
        // 
        // threeButton
        // 
        threeButton.Dock = DockStyle.Fill;
        threeButton.Location = new Point(229, 353);
        threeButton.Name = "threeButton";
        threeButton.Size = new Size(112, 64);
        threeButton.TabIndex = 15;
        threeButton.Text = "3";
        threeButton.UseVisualStyleBackColor = true;
        threeButton.Click += NumberClick;
        // 
        // additionButton
        // 
        additionButton.Dock = DockStyle.Fill;
        additionButton.Location = new Point(347, 353);
        additionButton.Name = "additionButton";
        additionButton.Size = new Size(107, 64);
        additionButton.TabIndex = 16;
        additionButton.Text = "+";
        additionButton.UseVisualStyleBackColor = true;
        additionButton.Click += OperationClick;
        // 
        // equalButton
        // 
        equalButton.Dock = DockStyle.Fill;
        equalButton.Location = new Point(347, 423);
        equalButton.Name = "equalButton";
        equalButton.Size = new Size(107, 59);
        equalButton.TabIndex = 17;
        equalButton.Text = "=";
        equalButton.UseVisualStyleBackColor = true;
        equalButton.Click += EqualClick;
        // 
        // result
        // 
        result.AutoSize = true;
        tableLayoutPanel1.SetColumnSpan(result, 4);
        result.Dock = DockStyle.Fill;
        result.Location = new Point(3, 0);
        result.Name = "result";
        result.Size = new Size(451, 143);
        result.TabIndex = 18;
        result.Text = "0";
        result.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
        result.TextAlign = ContentAlignment.BottomRight;

        // 
        // CalculatorForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(456, 482);
        Controls.Add(tableLayoutPanel1);
        MinimumSize = new Size(400, 400);
        Name = "CalculatorForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Calculator";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Button clearButton;
    private Button multiplicationButton;
    private Button divisionButton;
    private Button sighButton;
    private Button sevenButton;
    private Button eightButton;
    private Button nineButton;
    private Button fourButton;
    private Button fiveButton;
    private Button sixButton;
    private Button substructionButton;
    private Button zeroButton;
    private Button oneButton;
    private Button twoButton;
    private Button threeButton;
    private Button additionButton;
    private Button equalButton;
    private Label result;
}
