using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectEuler.Problems;
using System.Reflection;

namespace ProjectEuler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static object MagicallyCreateInstance(string className)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var type = assembly.GetTypes()
                .First(t => t.Name == className);

            return Activator.CreateInstance(type);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(((ComboBox)sender).SelectedIndex);
            startButton.Enabled = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = listProblemsComboBox.SelectedIndex+1;
            IProblems problem;
            if (selectedIndex < 10)
                problem = (IProblems)MagicallyCreateInstance("Problem_0" + selectedIndex.ToString());
            else
                problem = (IProblems)MagicallyCreateInstance("Problem_" + selectedIndex.ToString());

            problem.run();

        }
    }
}
