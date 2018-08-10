using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using InstantNote.Enums;
using InstantNote.Models;
using InstantNote.Services;

namespace InstantNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NoteServices _noteServices;
        private NoteListWindow _noteList;
        private List<Note> _notes;

        public MainWindow()
        {
            InitializeComponent();
            TxtTitle.Focus();
            _noteServices = new NoteServices();
            _notes = new List<Note>();
        }

        private void TxtContent_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ExecuteCommand(NoteCommand.Save);
                Close();
            }
        }

        private void MainWindow_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (((int)e.Key) > 89 && ((int)e.Key) < 100)
            {
                var data = string.Empty;
                switch (e.Key)
                {
                    case Key.F1:
                        ExecuteCommand(NoteCommand.GetToday);
                        break;

                    case Key.F2:
                        ExecuteCommand(NoteCommand.GetLastTwo);
                        break;

                    case Key.F5:
                        ExecuteCommand(NoteCommand.GetLastFive);
                        break;
                }

                _noteList = new NoteListWindow();
                _noteList.txtData.Text = FormatData();
                _noteList.Show();
            }
        }

        private void ExecuteCommand(NoteCommand command)
        {
            switch (command)
            {
                case NoteCommand.Save:
                    _noteServices.SaveNote(TxtTitle.Text, TxtContent.Text);
                    break;

                case NoteCommand.GetToday:
                case NoteCommand.GetLastTwo:
                case NoteCommand.GetLastFive:
                    _notes = _noteServices.GetNotes((short)command);
                    break;
            }
        }

        private string FormatData()
        {
            _notes = _notes.OrderByDescending(x => x.DateTime).ToList();
            var stringBuilder = new StringBuilder();
            foreach (var note in _notes)
            {
                stringBuilder.Append($"{note.DateTime.ToString(Constants.DateTimeFormat)}   ##   {note.Title}   ##   {note.Content}\n");
            }
            return stringBuilder.ToString();
        }

        private void TxtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(TxtTitle.Text))
                TxtContent.Focus();
        }
    }


}
