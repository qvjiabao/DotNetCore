using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QJB.Shared.Core
{
    public class PageProperty<T>
    {
        private int _pageIndex;

        public int PageIndex
        {
            get { return _pageIndex == 0 ? 1 : _pageIndex; }
            set { _pageIndex = value; }
        }

        private int _pageSize;

        public int PageSize
        {
            get { return _pageSize == 0 ? 10 : _pageSize; }
            set { _pageSize = value; }
        }

        public int Total { get; set; }

        public bool Loading { get; set; }

        public List<T> GridData { get; set; }

    }
}
