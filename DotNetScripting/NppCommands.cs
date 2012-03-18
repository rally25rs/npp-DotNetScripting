using System.Text;

namespace NppPluginNET
{
    /// <summary>
    /// Wrapper methods around windows messaging calls to Notepad++ and its underlying Scintilla editor.
    /// For info about each message, see:
    /// http://sourceforge.net/apps/mediawiki/notepad-plus/index.php?title=Messages_And_Notifications
    /// http://www.scintilla.org/ScintillaDoc.html
    /// </summary>
    public class NppCommands
    {
        private NppData nppData;

        public NppCommands(NppData nppData)
        {
            this.nppData = nppData;
        }

        public void MoveToLine(int line)
        {
            Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_GOTOLINE, line, 0);
        }

        public string GetLine(int line, int bufferSize)
        {
            var sb = new StringBuilder(bufferSize);
            Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_GETLINE, line, sb);
            return sb.ToString();
        }

        public void SetAnchorPosition(int position)
        {
            Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_SETANCHOR, position, 0);
        }

        public void ClearSelection()
        {
            Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_CLEARSELECTIONS, 0, 0);
        }

        public void SetSelectedText(int startPosition, int endPosition)
        {
            Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_SETSELECTION, startPosition, endPosition);
        }

        public void ReplaceSelectedText(string replacement)
        {
            Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_REPLACESEL, 0, replacement);
        }

        public int GetLineStartPosition(int line)
        {
            return (int) Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_POSITIONFROMLINE, line, 0);
        }

        /// <summary>
        /// Get the position of the ending of the line, NOT including the line end characters.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public int GetLineEndPosition(int line)
        {
            return (int) Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_GETLINEENDPOSITION, line, 0);
        }

        public int GetLineCount()
        {
            return (int) Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_GETLINECOUNT, 0, 0);
        }

        /// <summary>
        /// Get the length of a line, INCLUDING the line end characters.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public int GetLineLength(int line)
        {
            return (int) Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_LINELENGTH, line, 0);
        }

        public string GetSelectedText(int bufferSize)
        {
            var sb = new StringBuilder(bufferSize);
            Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_GETSELTEXT, 0, sb);
            return sb.ToString();
        }

        public void DeleteLine(int lineNum)
        {
            MoveToLine(lineNum);
            Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_LINEDELETE, 0, 0);
        }

        public void StartUndoAction()
        {
            Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_BEGINUNDOACTION, 0, 0);
        }

        public void EndUndoAction()
        {
            Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_ENDUNDOACTION, 0, 0);
        }

        public void UndoAction()
        {
            Win32.SendMessage(nppData._scintillaMainHandle, SciMsg.SCI_UNDO, 0, 0);
        }

        public string GetCurrentFileName()
        {
            var sb = new StringBuilder(Win32.MAX_PATH);
            Win32.SendMessage(nppData._nppHandle, NppMsg.NPPM_GETFILENAME, Win32.MAX_PATH, sb);
            return sb.ToString();
        }

        public void SwitchToFile(string name)
        {
            Win32.SendMessage(nppData._nppHandle, NppMsg.NPPM_SWITCHTOFILE, 0, name);
        }

        public void SwitchToFile(int index)
        {
            Win32.SendMessage(nppData._nppHandle, NppMsg.NPPM_ACTIVATEDOC, (int)NppMsg.MAIN_VIEW, index);
        }

        public uint GetNumberOfOpenFiles()
        {
            return (uint)Win32.SendMessage(nppData._nppHandle, NppMsg.NPPM_GETNBOPENFILES, 0, (uint)NppMsg.MAIN_VIEW) - 1; // subtracting 1 because this always seems to return a number 1 too big.
        }
    }
}