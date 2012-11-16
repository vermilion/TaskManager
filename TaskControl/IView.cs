using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace TaskControl
{
    public interface IView
    {
        /// <summary>
        /// Main forms tabcontrol
        /// </summary>
        TabControl GetTabControl { get; }

        /// <summary>
        /// Allows to get list of tasks
        /// </summary>
        IEnumerable<Data> DataList { get; }

        /// <summary>
        /// Allows to get history list
        /// </summary>
        IEnumerable<History> HistoryList { get; }
    }
}