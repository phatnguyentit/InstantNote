using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Navigation;
using InstantNote.Enums;
using InstantNote.Services;

namespace InstantNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NoteStoreServices _noteStoreServices;

        public MainWindow()
        {
            InitializeComponent();
            _noteStoreServices = new NoteStoreServices();
        }

        private void TxtContent_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Store note and close
                ExecuteCommand(NoteCommand.Save);
                Close();
            }
        }

        private void ExecuteCommand(NoteCommand command)
        {
            switch (command)
            {
                case NoteCommand.Save:
                    _noteStoreServices.SaveNote(TxtTitle.Text, TxtContent.Text);
                    break;

                case NoteCommand.GetLastOne:
                    _noteStoreServices.GetNotes(1);
                    break;

                case NoteCommand.GetLastFive:
                    break;

                
            }
        }
    }

    
}
