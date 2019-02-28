using System.Collections;
using System.Windows.Forms;

namespace ConThing {
	public class ColumnSorter : IComparer {
		private int colNumber;
		private SortOrder sortOrder;

		public ColumnSorter(int colNumber,
			SortOrder sortOrder) {
			this.colNumber = colNumber;
			this.sortOrder = sortOrder;
		}

		// Compare two ListViewItems.
		public int Compare(object x, object y) {
			// Get the objects as ListViewItems.
			ListViewItem itemX = x as ListViewItem;
			ListViewItem itemY = y as ListViewItem;

			return itemX.SubItems[colNumber].Text.CompareTo(itemY.SubItems[colNumber].Text) 
				* (sortOrder == SortOrder.Ascending ? 1 : -1);
		}
	}
}
