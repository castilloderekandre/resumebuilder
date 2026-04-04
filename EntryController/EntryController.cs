using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder.EntryController
{
    internal class EntryController : Control
    {
        Label label1 = new()
        {
            Text = "Title",
            Location = new Point(3, 3),
            AutoSize = true,
        };
        Label label2 = new()
        {
            Text = "Start Date",
            Location = new Point(3, 20),
            AutoSize = true,
        };
        Label label3 = new()
        {
            Text = "End Date",
            Location = new Point(3, 40),
            AutoSize = true,
        };
        Label label4 = new()
        {
            Text = "Organization",
            Location = new Point(3, 80),
            AutoSize = true,
        };
        Label label5 = new()
        {
            Text = "Address",
            Location = new Point(3, 100),
            AutoSize = true,
        };
        Label label6 = new()
        {
            Text = "Body",
            Location = new Point(3, 120),
            AutoSize = true,
        };

        TextBox textbox1 = new();
        TextBox textbox2 = new();
        TextBox textbox3 = new();

        RichTextBox richTextBox1 = new();

        DateTimePicker dateTimePicker1 = new();
        DateTimePicker dateTimePicker2 = new();

        GroupBox groupBox1 = new();

        CheckBox checkBox1 = new();
        CheckBox checkBox2 = new();
        CheckBox checkBox3 = new();
        CheckBox checkBox4 = new();
    }
}
