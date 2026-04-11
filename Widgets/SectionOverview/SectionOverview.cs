using ResumeBuilder.Widgets.ItemPickerControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder.Widgets.SectionOverview;

internal class SectionOverview : Control
{
    Label label1 = new Label()
    {
        Text = "Preview",
    };
    Label label2 = new Label()
    {
        Text = "Section Editor",
    };
    Label label3 = new Label()
    {
        Text = "Section Title",
    };

    Button button1 = new Button()
    {

    };
    Button button2 = new Button()
    {

    };
    Button button3 = new Button()
    {

    };

    PictureBox pictureBox1 = new PictureBox()
    {

    };

    TextBox textBox1 = new TextBox()
    {

    };

    ItemPicker itemPicker1 = new ItemPicker(null)
    {

    };

    public SectionOverview()
    {
        Controls.AddRange(
                label1,
                label2,
                label3,
                button1,
                button2,
                button3,
                pictureBox1,
                textBox1,
                itemPicker1
            );
    }
}
