using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thornton.Scheduler
{
    public partial class MacroBuilder : Form
    {
        public MacroBuilder()
        {
            InitializeComponent();
            Bind();
        }

        private void lstDay_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void Bind()
        {
            lstDay.DisplayMember = "Text";
            lstDay.ValueMember = "Date";

            List<DayName> days = new List<DayName>();
            days.Add(new DayName() { Date = DateTime.Now, Text = "Now(Today)" });
            var values = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();
            var DaysCount = 1;
            foreach (var val in values)
            {
                var nextDay = DateTime.Now.Next(val);
                days.Add(new DayName() { Date = nextDay, Text = "Next " + val, DaysCount = DaysCount++ });
            }

            var DaysCountP = -1;
            foreach (var val in values)
            {
                var prevDay = DateTime.Now.Previous(val);
                days.Add(new DayName() { Date = prevDay, Text = "Previous " + val, DaysCount = DaysCountP-- });
            }

            lstDay.DataSource = days;

            var macros = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Macros.txt");
            string[] splitted = macros.Split(new string[] { "~~" }, StringSplitOptions.RemoveEmptyEntries);
            List<Offset> offsets = new List<Offset>();
            foreach (var line in splitted)
            {
                string[] item = line.Split(new char[] { '~' }, StringSplitOptions.RemoveEmptyEntries);
                if (item.Length == 3)
                {
                    var offset = new Offset();
                    offset.Value = item[0].Trim();
                    offset.Text = offset.Value + " - " + item[1].Trim();
                    offset.HelpText = item[2].Trim();

                    offsets.Add(offset);
                }
            }

            lstOffset.DataSource = offsets;
            lstOffset.DisplayMember = "Text";
            lstOffset.ValueMember = "Value";
        }

        private void MacroBuilder_Load(object sender, EventArgs e)
        {

        }

        // Class variable to keep track of which row is currently selected:
        int hoveredIndex = -1;
        private void lstCars_MouseMove(object sender, MouseEventArgs e)
        {
            // See which row is currently under the mouse:
            int newHoveredIndex = lstOffset.IndexFromPoint(e.Location);

            // If the row has changed since last moving the mouse:
            if (hoveredIndex != newHoveredIndex)
            {
                // Change the variable for the next timw we move the mouse:
                hoveredIndex = newHoveredIndex;

                // If over a row showing data (rather than blank space):
                if (hoveredIndex > -1)
                {
                    //Set tooltip text for the row now under the mouse:
                    tt1.Active = false;
                    tt1.SetToolTip(lstOffset, ((Offset)lstOffset.Items[hoveredIndex]).HelpText);
                    tt1.Active = true;
                }
            }
        }

        public string MacroText
        {
            get
            {
                //return string.Join(" ", tlMacroList.Tags.ToArray());
                return lblMacroExpression.Text;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    //original file name
                    String sourcestring = value.Contains("{") == false ? value : (value.StartsWith("{") ? value.Remove(value.IndexOf("{"), value.IndexOf("} ") - value.IndexOf("{") + 2) : value.Remove(value.IndexOf(" {"), value.IndexOf("}") - value.IndexOf("{") + 2));
                    txtOutputFileName.Text = sourcestring;
                    if (value.StartsWith("{"))
                    {
                        chkAppendType.Checked = false;
                    }
                    else
                    {
                        chkAppendType.Checked = true;
                    }

                    //get text between the tags
                    Regex regex = new Regex("[{]{1}[-]*[^{-]+[}]{1}");
                    var v = regex.Match(value);
                    string s = v.Groups[0].ToString();
                    string[] splitted = s.Replace("{", "").Replace("}", "").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    if (splitted.Count() > 1)
                    {
                        int count = Convert.ToInt32(splitted[0]);
                        var item = lstDay.Items.Cast<DayName>().Where(x => x.DaysCount == count).First();
                        if (item != null)
                        {
                            lstDay.SelectedIndex = lstDay.Items.IndexOf(item);
                        }

                        string expression = splitted[1];

                        string[] tags = expression.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        tags.ToList().ForEach(x =>
                        {
                            tlMacroList.AddTag(x);
                        });
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstOffset_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lstOffset.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                var offset = (Offset)lstOffset.Items[index];
                tlMacroList.AddTag(offset.Value);
            }
        }

        private void lstOffset_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        readonly static Uri SomeBaseUri = new Uri("C:\\");
        static string GetFileNameFromUrl(string url)
        {
            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
                uri = new Uri(SomeBaseUri, url);

            return Path.GetFileNameWithoutExtension(uri.LocalPath);
        }

        static string GetFileExtensionFromUrl(string url)
        {
            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
                uri = new Uri(SomeBaseUri, url);

            return Path.GetExtension(uri.LocalPath);
        }

        private void tlMacroList_TagAdded(object source, EventArgs args)
        {
            if (lstDay.SelectedItem != null)
            {
                string FileName = GetFileNameFromUrl(txtOutputFileName.Text);
                string extension = GetFileExtensionFromUrl(txtOutputFileName.Text);

                var macro = string.Empty;
                var macroExpression = string.Empty;
                var dt = ((DayName)lstDay.SelectedItem).Date;
                foreach (var tag in tlMacroList.Tags)
                {
                    string expression = tag.Replace("\"", "");
                    macro += dt.ToString(expression) + " ";
                    macroExpression += expression + " ";
                }

                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    macro = macro.Replace(c, '-');
                    macroExpression = macroExpression.Replace(c, '-');
                }
                macro = macro.Replace(',', ' ');
                macroExpression = macroExpression.Replace(',', ' ');

                macro = macro.Trim();
                var daysCount = ((DayName)lstDay.SelectedItem).DaysCount;
                macroExpression = "{" + daysCount + ":" + macroExpression.Trim() + "}";

                //refresh text of macro output
                if (chkAppendType.Checked)
                {
                    lblMacroResult.Text = (FileName + " " + macro).Trim() + extension;
                    lblMacroExpression.Text = (FileName + " " + macroExpression).Trim() + extension;
                }
                else
                {
                    lblMacroResult.Text = (macro + " " + FileName).Trim() + extension;
                    lblMacroExpression.Text = (macroExpression + " " + FileName).Trim() + extension;
                }
            }
            else
            {
                MessageBox.Show("Please select item from list");
            }
        }

        private void txtOutputFileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
    public class DayName
    {
        public int DaysCount { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }

    public class Offset
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public string HelpText { get; set; }
    }
}
