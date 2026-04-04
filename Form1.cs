using ResumeBuilder.Widgets.ListBoxTree;
using System.Diagnostics;
using System.Text.Json;

namespace ResumeBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TestEntryObject();
            Button resetButton = new Button()
            {
                Text = "Reset",
                Location = new Point(3, 303),
            };
            resetButton.Click += resetButton_Click;
            homeTabPage.Controls.Add(resetButton);

            homeTabPage.Controls.Add(
                new ListBoxTree( 
                    "Title test", 
                    new LinkedList<object>(
                        [
                            "section1", 
                            "entry1",
                            "entry2",
                            "section2", 
                            "entry1",
                            "entry2",
                            "entry3"
                        ]
                    ) 
                )
            );
        }

        public void TestEntryObject()
        {
            Entry autofillEntry = Autofill.GenerateEntry();
            Debug.WriteLine(JsonSerializer.Serialize(autofillEntry, new JsonSerializerOptions { WriteIndented = true }));
        }

        void resetButton_Click(object? sender, EventArgs e)
        {
        }
    }
}
