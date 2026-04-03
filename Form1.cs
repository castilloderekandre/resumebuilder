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
            LinkedList<object> testData = new();
            testData.AddFirst("section");
            testData.AddLast("entry");
            homeTabPage.Controls.Add(new ListBoxTree("Title test", testData));
        }

        public void TestEntryObject()
        {
            Entry autofillEntry = Autofill.GenerateEntry();
            Debug.WriteLine(JsonSerializer.Serialize(autofillEntry, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
