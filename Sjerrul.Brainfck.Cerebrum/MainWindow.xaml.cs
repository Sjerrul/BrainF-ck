using Sjerrul.BrainFck.Machine;
using Sjerrul.BrainFck.Machine.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sjerrul.Brainfck.Cerebrum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            var output = new MemoryOutput();
            var tape = new Tape();

            BrainfuckMachine machine = new BrainfuckMachine(output, tape);

            try
            {
                string input = textInput.Text;
                machine.Run(input);
                textOutput.Text = output.ToString();
                txtTape.Text = tape.ToString();
            }
            catch(Exception ex)
            {
                textOutput.Text = $"Invalid Program: {ex.Message}";
            }
           
        }
    }
}
