using System.Windows;
using System.Windows.Input;
using InstantNote.Enums;
using InstantNote.Services;

namespace InstantNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NoteServices _noteServices;

        public MainWindow()
        {
            InitializeComponent();
            TxtTitle.Focus();
            _noteServices = new NoteServices();
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
                    _noteServices.SaveNote(TxtTitle.Text, TxtContent.Text);
                    break;

                case NoteCommand.GetLastDay:
                    var note = _noteServices.GetNotes(1);
                    break;

                case NoteCommand.GetLastFive:
                    break;
            }
        }

        private void MainWindow_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                ExecuteCommand(NoteCommand.GetLastFive);
            }
        }
    }


}
