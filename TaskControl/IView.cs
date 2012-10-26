using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace TaskControl
{
    public interface IView
    {
        // Dictionary<Data, List<History>> List { get; }
        TabControl GetTabControl { get; }
        IEnumerable<Data> DataList { get; }
        IEnumerable<History> HistoryList { get; }
        //DataTable Table { get; }
        /*ListView GetListView { get; }
        bool ShowClosed { get; }
        void AddUserControl(long id);*/
    }
}