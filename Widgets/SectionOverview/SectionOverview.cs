using ResumeBuilder.Widgets.ItemPickerControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder.Widgets.SectionOverview;

internal class SectionOverview : Control
{
    Label label1 = new Label()
    {
        Location = new Point(3, 0),
        AutoSize = true,
        Text = "Preview",
    };
    Label label2 = new Label()
    {
        Location = new Point(209, 0),
        AutoSize = true,
        Text = "Section Editor",
    };
    Label label3 = new Label()
    {
        Location = new Point(3, 0),
        AutoSize = true,
        Text = "Section Title",
    };

    Button button1 = new Button()
    {
        // LOCATION TO BE SET BY PICTUREBOX
        // SIZE TO BE SET BY PICTUREBOX
        Text = "Recompile Preview",
    };
    Button button2 = new Button()
    {
        Location = new Point(4, 47),
        Size = new Size(75, 23),
        Text = "Add",
    };
    Button button3 = new Button()
    {
        Location = new Point(85, 47),
        Size = new Size(75, 23),
        Text = "Delete",
    };

    Button button4 = new Button()
    {
        // SIZE TO BE SET BY DOCK TO PANEL
        Text = "Save Changes",
        Dock = DockStyle.Bottom,
    };

    PictureBox pictureBox1 = new PictureBox()
    {
        Location = new Point(3, 29),
        Size = new Size(200, 295),
    };

    Panel panel1 = new Panel()
    {
        Location = new Point(209, 18),
        Size = new Size(508, 309),
        BorderStyle = BorderStyle.FixedSingle,
    };

    TextBox textBox1 = new TextBox()
    {
        Location = new Point(3, 18),
        Size = new Size(157, 23),
    };

    ItemPicker itemPicker1 = new ItemPicker(null)
    {
        // LOCATION TO BE SET BY ADD / DELETE BUTTONS FOR NOW
    };

    public SectionOverview()
    {
        button1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + pictureBox1.Height + 6);
        button1.Size = new Size(pictureBox1.Width, 23);

        itemPicker1.Location = new Point(button2.Location.X, button2.Location.Y + button2.Height + 6);
        itemPicker1.Size = new Size(800, 400); // Can possibly be removed.

        panel1.Controls.AddRange(
                label3,
                textBox1,
                button4,
                itemPicker1
            );

        Controls.AddRange(
                label1,
                label2,
                button1,
                button2,
                button3,
                pictureBox1,
                panel1
            );
    }
}
