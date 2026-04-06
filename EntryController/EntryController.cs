using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder.EntryController
{
    internal class EntryController : Control
    {
        // #### GUI #####
        Label label1 = new Label() // label 1
        {
            Location = new Point(3, 3),
            AutoSize = true,
            Text = "Title",
        };
        Label label2 = new Label() // label 2
        {
            Location = new Point(3, 48),
            AutoSize = true,
            Text = "Start Date",
        };
        Label label3 = new Label() // label 3
        {
            Location = new Point(3, 92),
            AutoSize = true,
            Text = "End Date",
        };
        Label label4 = new Label() // label 4
        {
            Location = new Point(3, 136),
            AutoSize = true,
            Text = "Organization",
        };
        Label label5 = new Label() // label 5
        {
            Location = new Point(3, 180),
            AutoSize = true,
            Text = "Address",
        };
        Label label6 = new Label() // label 6
        {
            Location = new Point(3, 224),
            AutoSize = true,
            Text = "Body",
        };
        TextBox textBox1 = new TextBox()
        {
            Size = new Size(200, 23),
            Location = new Point(3, 22)
        };
        TextBox textBox2 = new TextBox()
        {
            Size = new Size(200, 23),
            Location = new Point(3, 154),
        };
        TextBox textBox3 = new TextBox()
        {
            Size = new Size(200, 23),
            Location = new Point(3, 198)
        };

        RichTextBox richTextBox1 = new RichTextBox()
        {
            Size = new Size(200, 245),
            Location = new Point(3, 242),
        };

        DateTimePicker dateTimePicker1 = new DateTimePicker()
        {
            Location = new Point(3, 66),
        };
        DateTimePicker dateTimePicker2 = new DateTimePicker()
        {
            Location = new Point(3, 110),
        };

        GroupBox groupBox1 = new GroupBox()
        {
            Size = new Size(142, 85),
            Location = new Point(209, 52),
            Text = "Options",
        };

        CheckBox checkBox1 = new CheckBox()
        {
            Location = new Point(6, 22),
            AutoSize = true,
            Text = "Only has one date?",
        };
        CheckBox checkBox2 = new CheckBox()
        {
            Location = new Point(6, 48),
            AutoSize = true,
            Text = "Has no date?",
        };
        CheckBox checkBox3 = new CheckBox()
        {
            Location = new Point(209, 154),
            AutoSize = true,
            Text = "Has organization?",
        };
        CheckBox checkBox4 = new CheckBox()
        {
            Location = new Point(209, 198),
            AutoSize = true,
            Text = "Has address?",
        };
        // #### END GUI #####

        public EntryController()
        {
            Size = new Size(
                    groupBox1.Location.X + groupBox1.Size.Width + 6,
                    richTextBox1.Location.Y + richTextBox1.Height + 6
                );

            groupBox1.Controls.AddRange(checkBox1, checkBox2);
            Controls.AddRange(
                label1,
                label2,
                label3,
                label4,
                label5,
                label6,
                textBox1,
                textBox2,
                textBox3,
                dateTimePicker1,
                dateTimePicker2,
                richTextBox1,
                groupBox1,
                /* checkBox1 and checkBox2 added in groupBox1 */
                checkBox3,
                checkBox4
            );
        }
    }
}
